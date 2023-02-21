using System;
using MelonLoader;
using VRC;
using ScytheStation.Components;
using UnityEngine;
using VRC.Core;
using ScytheStation.API.Utils;

namespace ScytheStation.Core.Patches
{
    internal static class Patches
    {
        public static APIUser _Apiuser { get; set; }
        internal static string _UserName;
        internal static int _PlayersInLobby { get; private set; }
        internal static GameObject _PlatePrefab { get; set; }
        internal static GameObject _NewPlate { get; set; }
        internal static bool NamePlatesInfo { get; private set; }
        public static void Init()
        {
            MelonLogger.Msg("[PATCH] Initializing...");

            ScytheStation.Patches.Patch.EasyPatching.EasyPatchMethodPost(typeof(NetworkManager), "Method_Public_Void_Player_0", typeof(Patches), "Join");
            ScytheStation.Patches.Patch.EasyPatching.EasyPatchMethodPost(typeof(NetworkManager), "Method_Public_Void_Player_2", typeof(Patches), "Leave");

            MelonLogger.Msg("[PATCH] Done!");
        }

        public static void Join(Player param_1)
        {
            if (MainSettings.PlayerAppearenceLog.Value)
            {
                if (_Apiuser.hasModerationPowers || _Apiuser.hasSuperPowers)
                {
                    Notificator.WriteHudMessage($"[LOGGER] MODERATOR DETECTED [{_UserName}] A moderator has entered in your lobby.");
                    MelonLogger.Msg("[LOGGER] MODERATOR DETECTED [" + _UserName + "]", "A moderator has entered in your lobby.");
                }
                else
                {
                    MelonLogger.Msg(ConsoleColor.Green, "[LOGGER] [JOIN] " + param_1.field_Private_APIUser_0.displayName);
                    Notificator.WriteHudMessage("[LOGGER] [JOIN] " + param_1.field_Private_APIUser_0.displayName);
                }
            }
        }
        public static void Leave(Player param_1)
        {
            if (MainSettings.PlayerAppearenceLog.Value)
            {
                if (_Apiuser.hasModerationPowers || _Apiuser.hasSuperPowers)
                {
                    Notificator.WriteHudMessage($"[LOGGER] MODERATOR DETECTED [{_UserName}] A moderator has left in your lobby.");
                    MelonLogger.Msg("[LOGGER] MODERATOR DETECTED [" + _UserName + "]", "A moderator has left in your lobby.");
                }
                else
                {
                    MelonLogger.Msg(ConsoleColor.Red, "[LOGGER] [LEAVE] " + param_1.field_Private_APIUser_0.displayName);
                    Notificator.WriteHudMessage("[LOGGER] [LEAVE] " + param_1.field_Private_APIUser_0.displayName);
                }
            }
        }
    }
} 
