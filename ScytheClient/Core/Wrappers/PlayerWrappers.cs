using UnityEngine;
using VRC;
using VRC.Core;
using UnityEngine.XR;
using VRC.UI;
using VRC.UI.Elements.Menus;
using PageAvatar = MonoBehaviour1PublicObReObBoVeBoGaVeStBoUnique;

namespace ScytheStation.Core.Wrappers
{
    internal static class PlayerWrappers
    {
        // idk if i can unskid this but.. i can do a lil bits of shit
        public static Player GetPlayer(this VRCPlayer instance) { return instance.prop_Player_0; }
        public static APIUser GetAPIUser(this Player player) => player.prop_APIUser_0;
        public static bool SelfIsInVr() { return XRDevice.isPresent; }
        public static void Tele2MousePos() { RaycastHit[] array = Physics.RaycastAll(new Ray(Camera.main.transform.position, Camera.main.transform.forward)); if (array.Length != 0) { RaycastHit raycastHit = array[0]; VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position = raycastHit.point; } }
        public static Player LocalPlayer() { return PlayerManager.Method_Public_Static_Player_0(); }
        public static float GetFrames(this Player player) => (player._playerNet.prop_Byte_0 != 0) ? Mathf.Floor(1000f / (float)player._playerNet.prop_Byte_0) : -1f;
        public static short GetPing(this Player player) => player._playerNet.field_Private_Int16_0;

        public static string GetFramesColord(this Player player)
        {
            float fps = player.GetFrames();
            if (fps > 80)
                return "<color=green>" + fps + "</color>";
            else if (fps > 30)
                return "<color=yellow>" + fps + "</color>";
            else
                return "<color=red>" + fps + "</color>";
        }

        public static string GetPingColord(this Player player)
        {
            short ping = player.GetPing();
            if (ping > 150)
                return "<color=red>" + ping + "</color>";
            else if (ping > 75)
                return "<color=yellow>" + ping + "</color>";
            else
                return "<color=green>" + ping + "</color>";
        }

        public static string GetPlatform(this Player player)
        {
            if (player.prop_APIUser_0.IsOnMobile)
            {
                return "<color=green>Q</color>";
            }
            else if (player.prop_VRCPlayerApi_0.IsUserInVR())
            {
                return "<color=#CE00D5>VR</color>";
            }
            else
            {
                return "<color=grey>PC</color>";
            }
        }
        public static void ChangeAvatar(string AvatarID)
        {
            PageAvatar component = GameObject.Find("Screens").transform.Find("Avatar").GetComponent<PageAvatar>();
            component.field_Public_MonoBehaviourPublicSiGaRuGaAcRu4StAvObUnique_0.field_Internal_ApiAvatar_0 = new ApiAvatar
            {
                id = AvatarID
            };
            component.ChangeToSelectedAvatar();
        }
        internal static VRCPlayer GetCurrentPlayer()
        {
            return VRCPlayer.field_Internal_Static_VRCPlayer_0;
        }
    }
} // made by WTFBlaze & Scrim & Viperium