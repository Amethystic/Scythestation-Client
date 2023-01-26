using UnityEngine;
using VRC;
using VRC.Core;
using UnityEngine.XR;
using VRC.UI;
using VRC.UI.Elements.Menus;
using Obfuscation = System.Reflection.ObfuscationAttribute;

namespace ScytheStation.Core.Wrappers
{
    internal static class PlayerWrappers
    {
        [Obfuscation(Exclude = false)]
        // idk if i can unskid this but.. i can do a lil bits of shit
        public static Player GetPlayer(this VRCPlayer instance) { return instance.prop_Player_0; }
        public static APIUser GetAPIUser(this Player player) => player.prop_APIUser_0;
        public static bool SelfIsInVr() { return XRDevice.isPresent; }
        public static void Tele2MousePos() { RaycastHit[] array = Physics.RaycastAll(new Ray(Camera.main.transform.position, Camera.main.transform.forward)); if (array.Length != 0) { RaycastHit raycastHit = array[0]; VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position = raycastHit.point; } }
        public static Player LocalPlayer() { return Player.Method_Internal_Static_Player_0(); }
        public static void ChangeAvatar(string AvatarID)
        {
            PageAvatar component = GameObject.Find("Screens").transform.Find("Avatar").GetComponent<PageAvatar>();
            component.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar
            {
                id = AvatarID
            };
            component.ChangeToSelectedAvatar();
        }
        public static IUser GetSelectedUser(this SelectedUserMenuQM selectMenu)
        {
            return selectMenu.field_Private_IUser_0;
        }
        internal static VRCPlayer GetCurrentPlayer()
        {
            return VRCPlayer.field_Internal_Static_VRCPlayer_0;
        }
        public static float GetFPS(this Player player) => (player._playerNet.prop_Byte_0 != 0) ? Mathf.Floor(1000f / (float)player._playerNet.prop_Byte_0) : -1f;
        public static short GetPing(this Player player) => player._playerNet.field_Private_Int16_0;
        public static Color GetTrustColor(this VRC.Player player) => VRCPlayer.Method_Public_Static_Color_APIUser_0(player.GetAPIUser());
    }
    internal static class StatusColors
    {
        public static string FPSColor(this Player player)
        {
            float fps = player.GetFPS();
            if (fps > 70) { return "<color=#59ff00>" + fps + "</color>"; }
            else if (fps > 30) { return "<color=#ff9900>" + fps + "</color>"; }
            else { return "<color=#db0000>" + fps + "</color>"; }
        }

        public static string PINGColor(this Player player)
        {
            short ping = player.GetPing();
            if (ping > 100) { return "<color=#db0000>" + ping + "</color>"; }
            else if (ping > 70) { return "<color=#ff9900>" + ping + "</color>"; }
            else { return "<color=#59ff00>" + ping + "</color>"; }
        }
    }
} // made by WTFBlaze & Scrim & Viperium