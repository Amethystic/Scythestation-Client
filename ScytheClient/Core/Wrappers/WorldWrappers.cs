using System.Collections.Generic;
using VRC;
using VRC.SDKBase;
using VRC.Udon;


namespace ScytheStation.Core.Wrappers
{
    internal class WorldWrappers
    {
        // idk if i can unskid this but.. ik u grabbed from foonix ngl
        internal static IEnumerable<Player> GetPlayers() { return PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.ToArray(); }
        public static string GetLocation() { return PlayerWrappers.LocalPlayer().GetAPIUser().location; }
        public static bool Amongunsworld() { return RoomManager.field_Internal_Static_ApiWorld_0.id == "wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"; }
        public static bool MurderWorld() { return RoomManager.field_Internal_Static_ApiWorld_0.id == "wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"; }
    }
}

// made by WTFBlaze