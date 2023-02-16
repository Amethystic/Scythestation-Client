using System;
using MelonLoader;
using ScytheStation.Core.Wrappers;
using ScytheStation.Components.IKH;
using ScytheStation.Components.Extensions;
using UnityEngine;
using VRC;

namespace ScytheStation.Functions
{
    internal class Self
    {
        public static void TPOSE()
        {
            if (RuntimeConfig.tPose == true)
            {
                MelonLogger.Msg(ConsoleColor.Blue, "[PLC] [TP] Hehe");
                Animator field_Internal_Animator_ = Player.Method_Internal_Static_Player_0()._vrcplayer.field_Internal_Animator_0;
                field_Internal_Animator_.enabled = !field_Internal_Animator_.enabled;
            }
            else
            {
                MelonLogger.Msg(ConsoleColor.DarkBlue, "[PLC] [TP] Aw");
                RuntimeConfig.tPose = false;
            }
        }
        public static void DefaultAVI()
        {
            MelonLogger.Msg(ConsoleColor.Blue, "[AVATAR] [REP] :D");
            PlayerWrappers.ChangeAvatar("avtr_23a69f06-1311-442f-986c-bbe520bef6a3");
        }
        public static void AVIID()
        {
            MelonLogger.Msg(ConsoleColor.Yellow, "[AVATAR] [NOTICE] Make sure to have an avatar ID copied to your clipboard!");

            if (SendToClip.GetClipboard().StartsWith("avtr"))
            {
                PlayerWrappers.ChangeAvatar(SendToClip.GetClipboard());
                MelonLogger.Msg(ConsoleColor.Green, "[AVATAR] Changed By ID");
                return;
            } MelonLogger.Msg(ConsoleColor.Red, "[AVATAR] [ERROR] Failed to send ID");
        }
    }
}
