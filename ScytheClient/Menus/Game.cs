using ApolloCore.API.QM;
using MelonLoader;
using System;

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
            new QMSingleButton(AnotherMenu2, 2, 3f, "<color=#fa0702><b>Quick LogOut</b></color>", delegate { MelonLogger.Msg("[GC] Buh bye"); Functions.GameControls.LogOut(); }, "Logs you out lol?");
            /* Main Settings Buttons */
            /* Settings Buttons */
            new QMToggleButton(AnotherMenu2, 1, 0, "Lag yo ass out!", delegate
            { Functions.GameControls.LagGame(); MelonLogger.Msg(ConsoleColor.DarkRed, "[GC] [ON] You're now lagging ur own game (Retard)"); }, delegate
            { Functions.GameControls.UnLagGame(); MelonLogger.Msg(ConsoleColor.Green, "[GC] [OFF] U managed to not lag so badly (Quest ass man)"); }, "This fucks with ur game so badly");
            new QMSingleButton(AnotherMenu2, 2, 0, "Cap to 60", delegate { Functions.GameControls.Capto60(); MelonLogger.Msg("[GC] Capped to 60"); }, "caps to 60 (Idk lol)");
            new QMSingleButton(AnotherMenu2, 3, 0, "Cap to inf", delegate { Functions.GameControls.UnCapLol(); MelonLogger.Msg("[GC] UnCapped"); }, "frames go WHEEEEEEEE!!");
            new QMSingleButton(AnotherMenu2, 4, 0, "Get world ID", delegate { Functions.GameControls.WorldID(); }, "Grabs the world ID");
            /* Settings Buttons */
            // GAME MENU //
            MelonLogger.Msg(ConsoleColor.Green, "[MENUS] GameManager Loaded", MenuManager.C++);
        }
    }
}
