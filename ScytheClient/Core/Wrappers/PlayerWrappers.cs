using UnityEngine;
using VRC;
using VRC.Core;
using UnityEngine.XR;
using VRC.UI;
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
        public static Player LocalPlayer() { return Player.Method_Internal_Static_Player_0(); }
        public static void ChangeAvatar(string AvatarID) { PageAvatar component = GameObject.Find("Screens").transform.Find("Avatar").GetComponent<PageAvatar>(); component.field_Public_MonoBehaviourPublicSiGaRuGaAcRu4StAvObUnique_0.field_Internal_ApiAvatar_0 = new ApiAvatar { id = AvatarID }; component.ChangeToSelectedAvatar(); }
    }
}

// made by WTFBlaze & Scrim & Viperium