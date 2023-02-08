using System.Collections.Generic;
using VRC;
using VRC.SDKBase;
using VRC.Udon;


namespace ScytheStation.Core.Wrappers
{
    internal class WorldWrappers
    {

        public static VRC_Pickup[] vrc_Pickups;
        public static VRC_Trigger[] vrc_Triggers;
        public static void Init()
        {
            vrc_Pickups = UnityEngine.Object.FindObjectsOfType<VRC_Pickup>();
            vrc_Triggers = UnityEngine.Object.FindObjectsOfType<VRC_Trigger>();
        }
        internal static IEnumerable<Player> GetPlayers() { return PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.ToArray(); }
        public static string GetLocation() { return PlayerWrappers.LocalPlayer().GetAPIUser().location; }
        public static bool Amongunsworld() { return RoomManager.field_Internal_Static_ApiWorld_0.id == "wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"; }
        public static bool MurderWorld() { return RoomManager.field_Internal_Static_ApiWorld_0.id == "wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"; }
        public static bool KeepRunning() { return RoomManager.field_Internal_Static_ApiWorld_0.id == "wrld_987b7998-9e1f-4ac2-b428-718e20f78060"; }
        public static bool PrisonEscape() { return RoomManager.field_Internal_Static_ApiWorld_0.id == "wrld_14750dd6-26a1-4edb-ae67-cac5bcd9ed6a"; }
        public static bool TestPilots() { return RoomManager.field_Internal_Static_ApiWorld_0.id == "wrld_e4908cea-023b-4749-9ad7-a898b12996e7"; }
        public static bool Ghost() { return RoomManager.field_Internal_Static_ApiWorld_0.id == "wrld_0ec97c4f-1e84-4a3a-9e3a-fa3075b6c56d"; }
        public static bool SuperVRBalls() { return RoomManager.field_Internal_Static_ApiWorld_0.id == "wrld_ff8b4a6e-4268-4783-bc16-3103067a4be6"; }
    }
}

// made by WTFBlaze