# LSW1DebugPatcher
A lean, mean, game patching machine created for the express purpose of allowing owners of *Lego Star Wars the Video Game* to patch the game executable in a way that allows access to the legendary **Debug Menu**.

## Context

In *Lego Star Wars the Video Game* and a selection of other related *LEGO* titles, the **Debug Menu** refers to a special in-game options menu that gives the player access to various developer-exclusive facilities that were originally intended to make testing the games easier.  

For example, the menu includes a sub-menu that allows the player to **load any section of any level in the game on demand**.  

Other useful features include: 

* **Lift Player** cheat toggle. Allows the player's character to fly at a constant upward velocity at the press of a button.  
* **Go to Door** sub-menu.  Gives the player the ability to instantly teleport to key level transition points.
* **FPS Display** toggle.  Can be useful for speedrun verification.  

## How to install?

Simply follow these steps and you'll be good to go: 

1. **Make sure** you have a **working copy** of *Lego Star Wars the Video Game* installed on your PC.  <u>*TAKE NOTE OF THE INSTALLATION DIRECTORY*</u>. **Only certain releases** of the game are compatible, so check [Compatibility](#compatibility) to **make sure your copy is supported**.  If it isn't, **[open an issue](https://github.com/yodadude2003/LSW1DebugPatcher/issues) on this repo.**  
2. **Download and install** the **latest version of the [.NET 5.0 Runtime](https://dotnet.microsoft.com/download/dotnet/5.0#runtime-desktop-5.0.4)**, or SDK if you want to compile it yourself (See [Building](#building) for more info)
3. **Download** the **latest release** of LSW1DebugPatcher (https://www.chosenfewsoftware.com/Apps/LSW1_Debug_Patcher)
4. **Create a subdirectory** named `patcher` inside the **same directory** as `LegoStarwars.exe` (found in previously noted <u>*installation directory*</u>)
5. **Extract all files** from the archive file you downloaded **into this new directory** (depending on whether your game is in `Program Files`, **you may need to run your archiver as administrator/root**)
6. **Victory tastes sweet.**  Move on to the next section!

## How to use?

1. **Take another look** at the [Compatibility](#compatibility) chart, and **make note** of the **Patch File** column for **your release**.  
2. **Open** the **`patcher` directory** in your game installation folder.
3. **Drag and Drop** your release's **patch file** onto `LSW1DebugPatcher.exe`.
4. **Follow** the on-screen directions and prompts.  Directions as of `v1.0` of LSW1DebugPatcher:
   * **To enable the patch:** type `E` at the prompt and hit `Enter`
   * **To disable the patch:** type `D` at the prompt and hit `Enter`
5. **Report** any errors you receive or issues you have, **but check [here](https://github.com/yodadude2003/LSW1DebugPatcher/issues?q=is%3Aissue) first!**

## Compatibility

| Region (Publisher)     | SHA256                                                       | Patch File |
| ---------------------- | ------------------------------------------------------------ | ---------- |
| US (Giant Interactive) | 49f74d802596b72b8da24b76f98f249dfdb370d5607fa7e65e3a19beb833d473 | US.patch   |
| UK (*Unknown)          | 09cd92f15b56960795e3fe0ec045ff4d2cd51f10dca6a7d1d24e7405eb5fba55 | EU00.patch |
| PL (Cenega)            | 09cd92f15b56960795e3fe0ec045ff4d2cd51f10dca6a7d1d24e7405eb5fba55 | EU00.patch |

Note: SHA256 column contains hex encoded SHA256 hashes for each release's `LegoStarwars.exe`

**probably also Giant Interactive*

#### How to verify your release

1. **Visit** https://emn178.github.io/online-tools/sha256_checksum.html
2. **Drag and drop** your game's `LegoStarwars.exe` into the designated area
3. **Compare** the resulting **garbled mess of numbers and letters** with those found **in the above table**.
4. **If you find a match**, congrats, your release is supported.  **If your hash isn't in this table**, **[open an issue](https://github.com/yodadude2003/LSW1DebugPatcher/issues)** and **include details** (hash, where you got your version of the game, info about region if it is known, etc.)

## Building

If you'd like, you can **compile** LSW1DebugPatcher yourself **using the [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)**

1. **Download and install** the aforementioned SDK.

2. If you do not have it installed already, **download and install [Git for Windows](https://git-scm.com/download/win)**.

3. **Reboot** your machine.

4. **Anywhere you'd like** on your computer, **create a folder** where you would like to store the source code for LSW1DebugPatcher.  I personally recommend creating a folder on your desktop or in your documents named "Source Code".  

5. **Navigate to** the inside of the new folder.  Right click on the empty space in the main pane and click `Git Bash Here`.

6. At the prompt, **type the following**, one line at a time, and hit enter after each line is complete:

   ```bash
   git clone https://www.github.com/yodadude2003/LSW1DebugPatcher
   cd .\LSW1DebugPatcher\LSW1DebugPatcher\
   dotnet build -c Release
   ```

7. Open the binary output folder.  Find the folder you created and then drill down to `LSW1Patcher\LSW1Patcher\Release\net5.0\`

8. ~~vomit tastes sour~~ **Victory tastes sweet**.  Use these binaries however you like in accordance to the project's license.  

## License

This project's code and patch files are all licensed to you under the permissive MIT license.  Basically it means do whatever the f\*\*k you want with the code and binaries (share them, modify them, etc) **BUT** make sure all people who receive a copy of it also know the copyright holder (me) and have a copy of the license.  For a more exact explanation, **read the license** its literally like 2 paragraphs haha

## That's all folks!

**Compliments to the chef!** Seriously, let me know how your experience is with the tool, don't be afraid to ask questions, and keep it real, keep it you 😎
