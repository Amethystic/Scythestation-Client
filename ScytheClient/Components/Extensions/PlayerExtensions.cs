using APIUtils = ApolloCore.API.APIUtils;
using VRC;
using VRC.UI.Elements.Menus;
using Obfuscation = System.Reflection.ObfuscationAttribute;

namespace ScytheStation.Components.Extensions
{
    internal static class PlayerExtensions
    {
        [Obfuscation(Exclude = false)]
        public static VRCPlayer LocalVRCPlayer
        {
            get
            {
                return VRCPlayer.field_Internal_Static_VRCPlayer_0;
            }
        }
        public static Player LocalPlayer
        {
            get
            {
                return PlayerManager.Method_Public_Static_Player_0();
            }
        }
        public static bool IsInWorld()
        {
            return RoomManager.field_Internal_Static_ApiWorld_0 != null;
        }
    }
    internal static class IUserExtension
    {
        public static Player SelectedVRCPlayer() => APIUtils.GetUserInterface().transform.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_SelectedUser_Local").GetComponentInChildren<SelectedUserMenuQM>().field_Private_IUser_0.prop_String_0.ReturnUserID();
        public static Player ReturnUserID(this string User)
        {
            foreach (Player player in PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0)
            {
                if (player.field_Private_APIUser_0.id == User)
                {
                    return player;
                }
            }
            return null;
        }
    }
}
