using System;
using SStationAutoLoader.Loader;
using MelonLoader;

[assembly: MelonInfo(typeof(SStationAutoLoader.Main), "ScytheUpdater", "0", "Scyt")]
[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonColor(ConsoleColor.DarkMagenta)]

namespace SStationAutoLoader
{
    internal class Main : MelonPlugin
    {
        public override void OnPreInitialization()
        {
            MelonLogger.Msg(ConsoleColor.DarkYellow, "Initializing AutoUpdater...");
            Check.C();
            Install.Init();
            MelonLogger.Msg(ConsoleColor.Green, "Finished Initializing");
        }

        public override void OnApplicationEarlyStart()
        {
            MelonLogger.Msg(ConsoleColor.Yellow, "[Credits to Scrim for AutoLoader From NitroEngine <3]");
        }
    }
}
