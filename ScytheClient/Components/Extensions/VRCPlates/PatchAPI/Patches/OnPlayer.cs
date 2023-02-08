using HarmonyLib;

namespace VRCPlates.Patches
{
    internal class _OnPlayer 
    {
        public static void InitOnPlayer()
        {
            VRCPlatesPatches.Instance.Patch(typeof(NetworkManager).GetMethod(nameof(NetworkManager.Method_Public_Void_Player_0)), new HarmonyMethod(AccessTools.Method(typeof(_OnPlayer), nameof(OnPlayerJoin))));
            VRCPlatesPatches.Instance.Patch(typeof(NetworkManager).GetMethod(nameof(NetworkManager.Method_Public_Void_Player_2)), new HarmonyMethod(AccessTools.Method(typeof(_OnPlayer), nameof(OnPlayerLeave))));
        }
        public static void OnPlayerJoin(ref VRC.Player __0)
        {
            if (__0.prop_APIUser_0 == null) return;
                VRCPlateNameplates.UpdatePlayerNameplates(__0);
            return;
        }
        public static void OnPlayerLeave(ref VRC.Player __0)
        {
            if (__0.prop_APIUser_0 == null) return;
                VRCPlateNameplates.UpdatePlayerNameplates(__0);
            return;
        }
    }  
}
