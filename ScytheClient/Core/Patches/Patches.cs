using System;
using MelonLoader;
using VRC;
using ScytheStation.Components;
using ScytheStation.API.Utils;

namespace ScytheStation.Core.Patches
{
    internal class Patches
    {
        public static void Init()
        {
            //Where your patches are initialized IF YOU CAN'T TELL ALREADY
            MelonLogger.Msg("[PATCH] Initializing...");

            ScytheStation.Patches.Patch.EasyPatching.EasyPatchMethodPost(typeof(NetworkManager), "Method_Public_Void_Player_0", typeof(Patches), "Join");
            ScytheStation.Patches.Patch.EasyPatching.EasyPatchMethodPost(typeof(NetworkManager), "Method_Public_Void_Player_2", typeof(Patches), "Leave");

            MelonLogger.Msg("[PATCH] Done!");
        }

        public static void Join(Player param_1)
        {
            if (MainSettings.PlayerAppearenceLog.Value)
            {
                MelonLogger.Msg(ConsoleColor.Green, "[LOGGER] [JOIN] " + param_1.field_Private_APIUser_0.displayName);
                Notificator.WriteHudMessage("[LOGGER] [JOIN] " + param_1.field_Private_APIUser_0.displayName);
            }
            else
            {
                MelonLogger.Msg(ConsoleColor.Red, "[LOGGER] Stopped logging");
                Notificator.WriteHudMessage("[LOGGER] Stopped logging Player L/J Events");
            }
        }

        public static void Leave(Player param_1)
        {
            if (MainSettings.PlayerAppearenceLog.Value)
            {
                MelonLogger.Msg(ConsoleColor.Red, "[LOGGER] [LEAVE] " + param_1.field_Private_APIUser_0.displayName);
                Notificator.WriteHudMessage("[LOGGER] [LEAVE] " + param_1.field_Private_APIUser_0.displayName);
            }
            else { }
        }
    }
}
