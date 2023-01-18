using VRC;

namespace ScytheStation.Components
{
    internal class Settings
    {
    }
    internal class MainSettings
    {
        public static bool ClickTP = false;
        public static bool flytoggle = false;
        public static bool ESPCapsules = false;
        public static bool PickupESP = false;
        public static bool Idek = false;
        public static bool LogEvents = false;
        public static bool Run = false;
        public static bool Hider = false;
    }
    public class UserStruct
    {
        public string userId { get; set; }
        public Player player { get; set; }
    }
    internal class Game
    {
        public static bool SpamGun = false;
        public static bool SpamBlind = false;
        public static bool Die = false;
    }
}
