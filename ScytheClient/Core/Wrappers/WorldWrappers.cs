using System.Collections.Generic;
using VRC;
using Obfuscation = System.Reflection.ObfuscationAttribute;


namespace ScytheStation.Core.Wrappers
{
    internal class WorldWrappers
    {
        [Obfuscation(Exclude = false)]
        // idk if i can unskid this but.. ik u grabbed from foonix ngl
        internal static IEnumerable<Player> GetPlayers() { return PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.ToArray(); }
        public static string GetLocation() { return PlayerWrappers.LocalPlayer().GetAPIUser().location; }
        public static bool Amongunsworld() { return RoomManager.field_Internal_Static_ApiWorld_0.id == "wrld_dd036610-a246-4f52-bf01-9d7cea3405d7"; }
        public static bool MurderWorld() { return RoomManager.field_Internal_Static_ApiWorld_0.id == "wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe"; }
        public static bool KeepRunning() { return RoomManager.field_Internal_Static_ApiWorld_0.id == "wrld_987b7998-9e1f-4ac2-b428-718e20f78060"; }
        public static bool PrisonEscape() { return RoomManager.field_Internal_Static_ApiWorld_0.id == "wrld_14750dd6-26a1-4edb-ae67-cac5bcd9ed6a"; }
    }
}

// made by WTFBlaze