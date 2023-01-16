using System;
using SStationAutoLoader.Loader;
using MelonLoader;

// Nothing i can change here but the check had 2 go
[assembly: MelonInfo(typeof(SStationAutoLoader.Main), "ScytheUpdater (UNSKIDDED EDITION BY PEEBO29)", "1", "Scyt")]
[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonColor(ConsoleColor.DarkMagenta)]
[assembly: MelonPriority(0)]

namespace SStationAutoLoader
{
    internal class Main : MelonPlugin
    {
        public override void OnPreInitialization() { MelonLogger.Msg(ConsoleColor.DarkYellow, "Initializing AutoUpdater..."); Install.Init(); }
        public override void OnApplicationEarlyStart() { MelonLogger.Msg(ConsoleColor.Yellow, "[XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX]"); }
    }
}
