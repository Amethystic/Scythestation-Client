using ApolloCore.API.QM;
using MelonLoader;
using System;
using ScytheStation.API.Utils;
using Obfuscation = System.Reflection.ObfuscationAttribute;

namespace ScytheStation.Menus
{
    internal class Movement
    {
        [Obfuscation(Exclude = false)]
        public static void Init(QMTabMenu menu)
        {
            // MOVEMENT MENU //
            var AnotherMenu3 = new QMNestedButton(menu, 2, 0, "Movement Controls", "Localplayer or fucking whatever idk", "Movement Controls");
            new QMToggleButton(AnotherMenu3, 1, 0, "I believe i can Fly", delegate
            { Components.MainSettings.flytoggle.Value = true; MelonLogger.Msg(ConsoleColor.Blue, "[MC] [ON] Im an angel"); Notificator.WriteHudMessage($"[MC] Im an angel"); }, delegate
            { Components.MainSettings.flytoggle.Value = false; MelonLogger.Msg(ConsoleColor.DarkBlue, "[MC] [OFF] Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex "); Notificator.WriteHudMessage($"[MC] Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex "); }, "This makes u fly lol");
            new QMToggleButton(AnotherMenu3, 2, 0, "Click TP", delegate
            { Components.MainSettings.ClickTP.Value = true; MelonLogger.Msg(ConsoleColor.Blue, "[MC] [ON] Click anywhere to teleport"); Notificator.WriteHudMessage($"[MC] Click anywhere to teleport (Supported for vr?: no)"); }, delegate
            { Components.MainSettings.ClickTP.Value = false; MelonLogger.Msg(ConsoleColor.DarkBlue, "[MC] [OFF] Ok then fuck u then"); Notificator.WriteHudMessage($"[MC] Ok then fuck you then"); }, "This makes u teleport by clicking places lol (Ctrl + Mousebutton0 (Idk neither))");
            // MOVEMENT MENU //
            MelonLogger.Msg(ConsoleColor.Green, "[MENUS] MovementManager Loaded", MenuManager.C++);
        }
    }
}
