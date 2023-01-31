using ApolloCore.API.QM;
using MelonLoader;
using System;
using ScytheStation.API.Utils;

namespace ScytheStation.Menus
{
    internal class Game
    {
        public static void Init(QMTabMenu menu)
        {
            // GAME MENU //
            /* Main Settings Buttons */
            var AnotherMenu2 = new QMNestedButton(menu, 4, 3f, "Game Controls", "This tooltip goes hard fr fr - Scrim", "Game Controls");
            new QMSingleButton(AnotherMenu2, 1, 3f, "<color=#fa0702><b>Chris Brown</b></color>", delegate { Functions.GameControls.Quit(); }, "Kills the process of the game");
            new QMSingleButton(AnotherMenu2, 2, 3f, "<color=#fa0702><b>Quick LogOut</b></color>", delegate { MelonLogger.Msg("[GC] Buh bye"); Notificator.WriteHudMessage($"[GC] Buh bye"); Functions.GameControls.LogOut(); }, "Logs you out lol?");
            new QMSingleButton(AnotherMenu2, 3, 3f, "<color=#03fc0b><b>Save Config</b></color>", delegate { MelonLogger.Msg("[GC] Config Saved"); Components.Settings2.SaveSettings(); }, "Save");
            new QMSingleButton(AnotherMenu2, 4, 3f, "<color=#fcf403><b>Load Config</b></color>", delegate { MelonLogger.Msg("[GC] Config Loaded"); Components.Settings2.LoadSettings(); }, "Load");
            new QMSingleButton(AnotherMenu2, 4, 3, "<color=#b83275><b>Open Site</b></color>", delegate { Functions.GameControls.OpenSite(); }, "Opens our site");
            /* Main Settings Buttons */
            /* Settings Buttons */
            new QMToggleButton(AnotherMenu2, 1, 0, "Lag yo ass out!", delegate
            { Functions.GameControls.LagGame(); MelonLogger.Msg(ConsoleColor.DarkGreen, "[GC] [ON] You're now lagging ur own game (Retard)"); Notificator.WriteHudMessage($"[GC] You're now lagging ur own game (Retard)"); }, delegate
            { Functions.GameControls.Capto60(); MelonLogger.Msg(ConsoleColor.Green, "[GC] [OFF] U managed to not lag so badly (Quest ass man)"); Notificator.WriteHudMessage($"[GC] U managed to not lag so badly (Quest ass man)"); }, "This fucks with ur game so badly");
            new QMSingleButton(AnotherMenu2, 2, 0, "Cap to 60", delegate { Functions.GameControls.Capto60(); MelonLogger.Msg("[GC] Capped to 60"); Notificator.WriteHudMessage($"[GC] Capped to 60 FPS"); }, "caps to 60 (Idk lol)");
            new QMSingleButton(AnotherMenu2, 3, 0, "Cap to inf", delegate { Functions.GameControls.UnCapLol(); MelonLogger.Msg("[GC] UnCapped"); Notificator.WriteHudMessage($"[GC] Fully UnCapped"); }, "frames go WHEEEEEEEE!!");
            new QMSingleButton(AnotherMenu2, 4, 0, "Get world ID", delegate { Functions.GameControls.WorldID(); Notificator.WriteHudMessage($"[GC] Yoinked W/ID"); }, "Grabs the world ID");
            new QMToggleButton(AnotherMenu2, 1, 1, "Keybinds", delegate
            { Components.MainSettings.keybinds.Value = true; MelonLogger.Msg(ConsoleColor.Green, "[GC] [BINDS] [ON] Bindings On"); Notificator.WriteHudMessage($"[GC] Bindings on"); }, delegate
            { Components.MainSettings.keybinds.Value = false; MelonLogger.Msg(ConsoleColor.DarkGreen, "[GC] [BINDS] [OFF] Bindings Off"); Notificator.WriteHudMessage($"[GC] Bindings Off"); }, "Keybind support");
            new QMToggleButton(AnotherMenu2, 2, 1, "High Priority Game", delegate
            { Components.GameCtrl.HighPrior.Value = true; MelonLogger.Msg(ConsoleColor.Green, "[GC] High Prior"); Notificator.WriteHudMessage($"[GC] High Prior"); }, delegate
            { Components.GameCtrl.HighPrior.Value = false; MelonLogger.Msg(ConsoleColor.DarkGreen, "[GC] Normal Off"); Notificator.WriteHudMessage($"[GC] Normal Prior"); }, "Messes with priority");
            new QMToggleButton(AnotherMenu2, 3, 1, "Skip HyperThread", delegate
            { Components.GameCtrl.SkitHyperThread.Value = true; MelonLogger.Msg(ConsoleColor.Green, "[GC] Hyperthread Skipped"); Notificator.WriteHudMessage($"[GC] Hyperthread Skipped"); }, delegate
            { Components.GameCtrl.SkitHyperThread.Value = false; MelonLogger.Msg(ConsoleColor.DarkGreen, "[GC] Hyperthread UnSkipped"); Notificator.WriteHudMessage($"[GC] Hyperthread UnSkipped"); }, "Messes with affinity");
            new QMToggleButton(AnotherMenu2, 4, 1, "Log Player L/J Events", delegate
            { Components.MainSettings.PlayerAppearenceLog.Value = true; MelonLogger.Msg(ConsoleColor.Green, "[GC] Started Logging"); Notificator.WriteHudMessage($"[GC] Started Logging"); }, delegate
            { Components.MainSettings.PlayerAppearenceLog.Value = false; MelonLogger.Msg(ConsoleColor.DarkGreen, "[GC] Stopped Logging"); Notificator.WriteHudMessage($"[GC] Stopped Logging"); }, "Messes with our patch's logging system");
            /* Settings Buttons */
            // GAME MENU //
            MelonLogger.Msg(ConsoleColor.Green, "[MENUS] GameManager Loaded", MenuManager.C++);
        }
    }
}
