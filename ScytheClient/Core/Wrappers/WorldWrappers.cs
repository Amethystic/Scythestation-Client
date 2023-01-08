using System.Collections.Generic;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using System;
using UnityEngine;
using VRC.Udon;


namespace ScytheStation.Core.Wrappers
{
    internal class WorldWrappers
    {
        internal static ApiWorld CurrentWorld() { return RoomManager.field_Internal_Static_ApiWorld_0; }
        internal static ApiWorldInstance CurrentInstance() { return RoomManager.field_Internal_Static_ApiWorldInstance_0; }
        internal static IEnumerable<Player> GetPlayers() { return PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.ToArray(); }
        internal static bool IsInRoom() { return RoomManager.field_Internal_Static_ApiWorld_0 != null && RoomManager.field_Internal_Static_ApiWorldInstance_0 != null; }
        internal static int GetPlayerCount() { return PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.Count; }
        internal static string GetJoinID() { return CurrentInstance().id; }
        internal static void JoinWorld(string worldID) { Networking.GoToRoom(worldID); }
        public static string GetLocation() { return PlayerWrappers.LocalPlayer().GetAPIUser().location; }
        public static bool Amongunsworld() { return RoomManager.field_Internal_Static_ApiWorld_0.id == "wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"; }
        public static bool MurderWorld() { return RoomManager.field_Internal_Static_ApiWorld_0.id == "wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"; }
        public static void Init()
        {
            WorldWrappers.vrc_Pickups = UnityEngine.Object.FindObjectsOfType<VRC_Pickup>();
            WorldWrappers.udonBehaviours = UnityEngine.Object.FindObjectsOfType<UdonBehaviour>();
            WorldWrappers.vrc_Triggers = UnityEngine.Object.FindObjectsOfType<VRC_Trigger>();
        }

        public static VRC_Pickup[] vrc_Pickups;
        public static UdonBehaviour[] udonBehaviours;
        public static VRC_Trigger[] vrc_Triggers;
    }
}

// made by WTFBlaze