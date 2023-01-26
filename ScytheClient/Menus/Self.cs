using ApolloCore.API.QM;
using System;
using MelonLoader;
using ScytheStation.API.Utils;
using Obfuscation = System.Reflection.ObfuscationAttribute;

namespace ScytheStation.Menus
{
    internal class Self
    {
        [Obfuscation(Exclude = false)]
        public static void Init(QMTabMenu menu)
        {
            // SELF MENU //
            var AnotherMenu4 = new QMNestedButton(menu, 3, 0, "Player Controls", "Where yo movement at? - Plasma (Creds 2 rsdnt)", "Player Controls");
            new QMSingleButton(AnotherMenu4, 1, 0, "T-Pose", delegate { Functions.Self.TPOSE(); Notificator.WriteHudMessage($"[S] Asserting dominance"); }, "Assert ur dominance ig");
            new QMSingleButton(AnotherMenu4, 2, 0, "Rep ScytheStation", delegate { Functions.Self.DefaultAVI(); Notificator.WriteHudMessage($"[S] Thx for supporting"); }, "ScytheStation Time");
            new QMSingleButton(AnotherMenu4, 3, 0, "Change by ID", delegate { Functions.Self.AVIID(); Notificator.WriteHudMessage($"[S] Changing avi's"); }, "Change Avatars by ID");
            // SELF MENU //
            MelonLogger.Msg(ConsoleColor.Green, "[MENUS] LocalPlayerManager Loaded", MenuManager.C++);
        }
    }
}
