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
    }
} // made by WTFBlaze & Scrim & Viperium