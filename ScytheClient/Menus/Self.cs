using ApolloCore.API.QM;
using System;
using MelonLoader;
using ScytheStation.API.Utils;

namespace ScytheStation.Menus
{
    internal class Self
    {
        public static void Init(QMTabMenu menu)
        {
            // SELF MENU //
            var AnotherMenu4 = new QMNestedButton(menu, 3, 0, "Player Controls", "Where yo movement at? - Plasma (Creds 2 rsdnt)", "Player Controls");
            new QMToggleButton(AnotherMenu4, 1, 0, "T-Pose", delegate
            { Components.IKH.RuntimeConfig.tPose = true; Functions.Self.TPOSE(); MelonLogger.Msg(ConsoleColor.Blue, "[PLC] [TP] Hehe"); Notificator.WriteHudMessage($"[S] Hehe"); }, delegate
            { Components.IKH.RuntimeConfig.tPose = false; Functions.Self.TPOSE(); MelonLogger.Msg(ConsoleColor.DarkBlue, "[PLC] [TP] Aw"); Notificator.WriteHudMessage($"[S] Aw"); }, "Assert ur dominance ig");
            new QMSingleButton(AnotherMenu4, 2, 0, "Rep ScytheStation", delegate { Functions.Self.DefaultAVI(); Notificator.WriteHudMessage($"[S] Thx for supporting"); }, "ScytheStation Time");
            new QMSingleButton(AnotherMenu4, 3, 0, "Change by ID", delegate { Functions.Self.AVIID(); Notificator.WriteHudMessage($"[S] Changing avi's"); }, "Change Avatars by ID");
            // SELF MENU //
            MelonLogger.Msg(ConsoleColor.Green, "[MENUS] LocalPlayerManager Loaded", MenuManager.C++);
        }
    }
}
