using System.IO;
using System;
using MelonLoader;

namespace ScytheStation.Core.FileManager
{
    internal class Directories
    {
        public static string GDir = Environment.CurrentDirectory;
        public static string MDir = $"{GDir}\\Mods";
        public static string Folder = $"{GDir}\\ScytheStation";
        public static string PDir = $"{GDir}\\Plugins";
        private static int FCount = 0;

        public static void CreateFolders()
        {
            MelonLogger.Msg("[LOADER] Creating Folders...");

            // Main
            if (!Directory.Exists(Folder)) { Directory.CreateDirectory(Folder); FCount++; }

            // Etc
            if (!Directory.Exists($"{Folder}\\Configs")) { Directory.CreateDirectory($"{Folder}\\Configs"); FCount++; }
            if (!Directory.Exists($"{Folder}\\Dependencies")) { Directory.CreateDirectory($"{Folder}\\Dependencies"); FCount++; }
            if (!Directory.Exists($"{Folder}\\Misc")) { Directory.CreateDirectory($"{Folder}\\Misc"); FCount++; }
            if (!Directory.Exists($"{Folder}\\Loading")) { Directory.CreateDirectory($"{Folder}\\Misc\\Loading"); FCount++; }
            if (!Directory.Exists($"{Folder}\\Images")) { Directory.CreateDirectory($"{Folder}\\Dependencies\\Images"); FCount++; }
        }
        public static void ValidateFolders() { if (FCount != 0) { MelonLogger.Msg($"[LOADER] Created {FCount} Folders!"); } }
    }
}
