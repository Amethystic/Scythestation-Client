using VRC;

namespace ScytheStation.Components.Extensions
{
    internal static class PlayerExtensions
    {
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
                return Player.Method_Internal_Static_Player_0();
            }
        }
        public static bool IsInWorld()
        {
            return RoomManager.field_Internal_Static_ApiWorld_0 != null;
        }
    }
}
