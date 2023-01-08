using System;
using System.Net;
using System.Threading.Tasks;
using MelonLoader;
using ScytheStation.Core.Wrappers;
using ScytheStation.Components.IKH;
using ScytheStation.Components.Extensions;
using UnityEngine;
using HarmonyLib;
using VRC;
using VRC.Core;

namespace ScytheStation.Functions
{
    internal class Self
    {
        private static string backupID;
        public static void TPOSE()
        {
            if (RuntimeConfig.tPose = true)
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
            }
            MelonLogger.Msg(ConsoleColor.Red, "[AVATAR] [ERROR] Failed to send ID");
        }
        //public static void NONECK()
        //{
        //    if (RuntimeConfig.noNeck = true)
        //    {
        //        MelonLogger.Msg(ConsoleColor.Blue, "[PLC] [NON] Hehe");
        //    }
        //    else
        //    {
        //        RuntimeConfig.noNeck = false;
        //        MelonLogger.Msg(ConsoleColor.DarkBlue, "[PLC] [NON] Aw");
        //    }
        //}
        //public static void LeftArm()
        //{
        //    if (RuntimeConfig.leftArm = true)
        //    {
        //        MelonLogger.Msg(ConsoleColor.Blue, "[PLC] [LARM] Hehe");
        //    }
        //    else
        //    {
        //        RuntimeConfig.leftArm = false;
        //        MelonLogger.Msg(ConsoleColor.DarkBlue, "[PLC] [LARM] Aw");
        //    }
        //}
        //public static void RightArm()
        //{
        //    if (RuntimeConfig.rightArm = true)
        //    {
        //        MelonLogger.Msg(ConsoleColor.Blue, "[PLC] [RARM] Hehe");
        //    }
        //    else
        //    {
        //        RuntimeConfig.rightArm = false;
        //        MelonLogger.Msg(ConsoleColor.DarkBlue, "[PLC] [RARM] Aw");
        //    }
        //}
        //public static void TwistedBody()
        //{
        //    if (RuntimeConfig.twist = true)
        //    {
        //        MelonLogger.Msg(ConsoleColor.Blue, "[PLC] [TWIST] Hehe");
        //    }
        //    else
        //    {
        //        RuntimeConfig.twist = false;
        //        MelonLogger.Msg(ConsoleColor.DarkBlue, "[PLC] [TWIST] Aw");
        //    }
        //}
        //public static void FuckedChest()
        //{
        //    if (RuntimeConfig.noChest = true)
        //    {
        //        MelonLogger.Msg(ConsoleColor.Blue, "[PLC] [NCHEST] Hehe");
        //    }
        //    else
        //    {
        //        RuntimeConfig.noChest = false;
        //        MelonLogger.Msg(ConsoleColor.DarkBlue, "[PLC] [NCHEST] Aw");
        //    }
        //}
    }
}
