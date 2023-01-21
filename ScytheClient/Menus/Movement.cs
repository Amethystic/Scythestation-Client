using ApolloCore.API.QM;
using MelonLoader;
using System;

namespace ScytheStation.Menus
{
    internal class Movement
    {
        public static void Init(QMTabMenu menu)
        {
            // MOVEMENT MENU //
            var AnotherMenu3 = new QMNestedButton(menu, 2, 0, "Movement Controls", "Localplayer or fucking whatever idk", "Movement Controls");
            new QMToggleButton(AnotherMenu3, 1, 0, "SpeedRunner time", delegate
            { Functions.Movements.SpeedRunToggle(); MelonLogger.Msg(ConsoleColor.Blue, "[MC] [ON] You're too fast"); }, delegate
            { Functions.Movements.SpeedRunToggle(); MelonLogger.Msg(ConsoleColor.DarkBlue, "[MC] [OFF] U too slow"); }, "This fucks with ur speed");
            new QMToggleButton(AnotherMenu3, 2, 0, "I believe i can Fly", delegate
            { Functions.Movements.FlyOn(); MelonLogger.Msg(ConsoleColor.Blue, "[MC] [ON] Im an angel"); }, delegate
            { Functions.Movements.FlyOff(); MelonLogger.Msg(ConsoleColor.DarkBlue, "[MC] [OFF] Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex "); }, "This makes u fly lol");
            new QMToggleButton(AnotherMenu3, 3, 0, "Click TP", delegate
            { Functions.Movements.ClickTPToggle(); MelonLogger.Msg(ConsoleColor.Blue, "[MC] [ON] Click anywhere to teleport"); }, delegate
            { Functions.Movements.ClickTPToggle(); MelonLogger.Msg(ConsoleColor.DarkBlue, "[MC] [OFF] Ok then fuck u then"); }, "This makes u teleport by clicking places lol (Ctrl + Mousebutton0 (Idk neither))");
            // MOVEMENT MENU //
            MelonLogger.Msg(ConsoleColor.Green, "[MENUS] MovementManager Loaded", MenuManager.C++);
        }
    }
}
