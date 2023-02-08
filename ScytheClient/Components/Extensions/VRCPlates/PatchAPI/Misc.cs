using UnityEngine;
using VRC;

namespace VRCPlates
{
    internal static class Misc
    {
        public static float GetFrames(this Player player) => (player._playerNet.prop_Byte_0 != 0) ? Mathf.Floor(1000f / (float)player._playerNet.prop_Byte_0) : -1f;
        public static short GetPing(this Player player) => player._playerNet.field_Private_Int16_0;
        public static bool ClientDetect(this Player player) { return player.GetFrames() > 90f || player.GetPing() < 1f || player.GetPing() > 665 || player.GetPing() < 0; }

        public static string GetFramesColord(this Player player)
        {
            float fps = player.GetFrames();
            if (fps > 70) { return "<color=#59ff00>" + fps + "</color>"; }
            else if (fps > 30) { return "<color=#ff9900>" + fps + "</color>"; }
            else { return "<color=#db0000>" + fps + "</color>"; }
        }

        public static string GetPingColord(this Player player)
        {
            short ping = player.GetPing();
            if (ping > 100) { return "<color=#db0000>" + ping + "</color>"; }
            else if (ping > 70) { return "<color=#ff9900>" + ping + "</color>"; }
            else { return "<color=#59ff00>" + ping + "</color>"; }
        }

        public static string GetPlatform(this Player player)
        {
            if (player.prop_APIUser_0.IsOnMobile) { return "<color=green>QUEST</color>"; }
            else if (player.prop_VRCPlayerApi_0.IsUserInVR()) { return "<color=#CE00D5>VR</color>"; }
            else { return "<color=grey>PC</color>"; }
        }
    }
}