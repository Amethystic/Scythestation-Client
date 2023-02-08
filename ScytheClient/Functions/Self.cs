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
            if (RuntimeConfig.tPose)
            {
                if (Player.prop_Player_0.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>().enabled == true)
                    Player.prop_Player_0.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>().enabled = false;
                else if (Player.prop_Player_0.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>().enabled == false)
                {
                    Player.prop_Player_0.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>().enabled = true;
                }
            }
            else
            {
                if (Player.prop_Player_0.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>().enabled == false)
                    Player.prop_Player_0.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>().enabled = true;
                else if (Player.prop_Player_0.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>().enabled == true)
                {
                    Player.prop_Player_0.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>().enabled = false;
                }
            }
        }
        public static void DefaultAVI()
        {
            MelonLogger.Msg(ConsoleColor.Blue, "[AVATAR] [REP] :D");
            PlayerWrappers.ChangeAvatar("avtr_b8a5b922-faec-460e-bc36-862518bdee8f");
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
