using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace LSW1DebugPatcher
{
    public class Patch
    {
        private const string PATTERN = "([0|1|2|3|4|5|6|7|8|9|A|B|C|D|E|F]{8}) : ([0|1|2|3|4|5|6|7|8|9|A|B|C|D|E|F]{2})\\|([0|1|2|3|4|5|6|7|8|9|A|B|C|D|E|F]{2})";

        public (long addr, byte apply, byte undo)[] Patches { get; }

        private Patch((long, byte, byte)[] patches)
        {
            Patches = patches;
        }

        public void Use(string path, bool apply = true)
        {
            using (var file = File.OpenWrite(path))
            {
                foreach (var patch in Patches)
                {
                    file.Seek(patch.addr, SeekOrigin.Begin);
                    file.WriteByte(apply ? patch.apply : patch.undo);
                }
            }
        }

        public static Patch ParseFromFile(string path)
        {
            var lineNum = 0;

            var patches = new List<(long, byte, byte)>();
            using (var file = File.OpenText(path))
            {
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine();
                    var matches = Regex.Match(line, PATTERN);

                    lineNum++;

                    if (matches.Success &&
                        long.TryParse(matches.Groups[1].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out long addr) &&
                        byte.TryParse(matches.Groups[2].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte apply) &&
                        byte.TryParse(matches.Groups[3].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte undo))
                    {
                        patches.Add((addr, apply, undo));
                    }
                    else
                    {
                        throw new FormatException($"Line #{lineNum} of {path} is invalid! Check program documentation for more info.");
                    }
                }
            }

            return new Patch(patches.ToArray());
        }
    }
}
