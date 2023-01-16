using System;
using MelonLoader;

namespace SStationAutoLoader.Loader
{
    public class Install
    {
        public static string Mod = $"{MelonUtils.GameDirectory}\\Mods";
        public static string MOD = $"{Mod}\\ScytheStation.dll";
        public static void Init()
        {
            MelonLogger.Msg(ConsoleColor.Yellow, "Checking for updates"); UpdateManager.B(MOD);
        }
    }
}
