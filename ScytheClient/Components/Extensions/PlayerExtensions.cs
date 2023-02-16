using APIUtils = ApolloCore.API.APIUtils;
using VRC;
using VRC.UI.Elements.Menus;
using Obfuscation = System.Reflection.ObfuscationAttribute;
using UnityEngine;
using Il2CppSystem.Collections.Generic;

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
        internal static Player GetCurrentlySelectedPlayer()
        {
            APIUtils.GetUserInterface();
            if (GameObject.Find("CanvasGroup/Container/Window/QMParent/Menu_SelectedUser_Local").GetComponentInChildren<SelectedUserMenuQM>() == null)
            {
                return null;
            }
            return GetPlayerFromIDInLobby(GameObject.Find("CanvasGroup/Container/Window/QMParent/Menu_SelectedUser_Local").gameObject.GetComponentInChildren<SelectedUserMenuQM>().field_Private_InterfacePublicAbstractStCoStBoObSt1BoSi1Unique_0.prop_String_0);
        }
        internal static List<Player> GetAllPlayers()
        {
            // Make sure the PlayerManager exists first.
            if (PlayerManager.field_Private_Static_PlayerManager_0 == null)
            {
                return null;
            }

            return PlayerManager.field_Private_Static_PlayerManager_0?.field_Private_List_1_Player_0;
        }
        internal static Player GetPlayerFromIDInLobby(string id)
        {
            List<Player> all_player = GetAllPlayers();

            foreach (var player in all_player)
            {
                if (player != null && player.prop_APIUser_0 != null)
                {
                    if (player.prop_APIUser_0.id == id)
                    {
                        return player;
                    }
                }
            }

            return null;
        }
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
