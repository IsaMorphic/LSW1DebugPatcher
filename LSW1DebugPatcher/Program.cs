using System;
using System.IO;

namespace LSW1DebugPatcher
{
    class Program
    {
        const string EXE_NAME = "LegoStarwars.exe";
        const string DEFAULT_PATCH = ".\\EU00.patch";

        static void Main(string[] args)
        {
            string descPath;
            if (args.Length < 1)
                descPath = DEFAULT_PATCH;
            else
                descPath = args[0];

            Console.WriteLine("Creating backup of game exe...");
            File.Copy($"..\\{EXE_NAME}", $".\\{EXE_NAME}.backup", true);

            Console.WriteLine($"Parsing patch file: {descPath}");
            Patch patch;
            try
            {
                patch = Patch.ParseFromFile(descPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            bool? apply = null;
            Console.WriteLine("Would you like to enable or disable the patch? (E/D)");
            do
            {
                var resp = Console.ReadLine().ToUpperInvariant();

                if (resp == "E")
                    apply = true;
                else if (resp == "D")
                    apply = false;

                if (!apply.HasValue)
                    Console.WriteLine("Please enter 'E' if you would like to enable the patch, or 'D' if you would like to disable it.");
            }
            while (!apply.HasValue);

            try
            {
                patch.Use($"..\\{EXE_NAME}", apply.Value);
            }
            catch
            {
                Console.WriteLine("Patching failed!!! Restoring backup exe...");
                File.Copy($".\\{EXE_NAME}.backup", $"..\\{EXE_NAME}", true);
            }

            Console.WriteLine("All operations have completed successfully.");
        }
    }
}
