using System;
using MelonLoader;

namespace SStationAutoLoader.Loader
{
    public class Install
    {
        public static string ModLoc = $"{MelonUtils.GameDirectory}\\Mods";
        public static string MOD = $"{ModLoc}\\ScytheStation.dll";
        public static void Init()
        {
            MelonLogger.Msg(ConsoleColor.Yellow, "Checking for updates");
            UpdateManager.B(MOD);
            MelonLogger.Msg(ConsoleColor.Green, "Done!");
        }
    }
}
