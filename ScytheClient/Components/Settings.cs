using ScytheStation.Core.Discord;
using System.Collections.Generic;
using VRC;

namespace ScytheStation.Components
{
    internal class Settings
    {
        internal static DiscordRpc.EventHandlers eventHandlers;
        public static void DiscordRPCOn()
        {
            DiscordRpc.Initialize($"{Manager.appid}", ref eventHandlers, true, "");
        }
        public static void DiscordRPCOff()
        {
            DiscordRpc.Shutdown();
        }
    }
    internal class MainSettings
    {
        public static bool ClickTP = false;
        public static bool EventLog = false;
        public static bool LogEvent12 = false;
        public static bool LogEvent6 = false;
        public static bool LogEvent66 = false;
        public static bool LogEvent60 = false;
        public static bool LogEvent202 = false;
        public static bool LogEvent8 = false;
        public static bool LogEvent1 = false;
        public static bool SelfEventLog = false;
        public static bool RPCLog = false;
        public static bool flytoggle = false;
        public static bool AntiEventCrash = false;
        public static bool AntiShaderCrash = false;
        public static bool AntiAudioCrash = false;
        public static bool udonSpams = false;
        public static bool AntiParticleCrash = false;
        public static bool WhiteList = false;
        public static bool ESPCapsules = false;
        public static int udonEventAmount = 0;
        public static bool PickupESP = false;
        public static bool serializeEnabled = false;
        public static bool IsNetworkSounboardEnabled = false;
        public static string CustomEvent1 = "AAAAAAAAAAC7hjsA+LKdFUzFmSNUInplVz1QM9Cz59p6dmG7TsDzeETD+2Z4BudLjQfGuq7PPfRB49I596bYD3KniVmgDiE=";
        public static string CustomEvent6 = "auE2fwcCAAAABwA6MzBENDEvDgD/AAAAAAEAAAALAFNldFRpbWVyUlBDAAAAAAQIAAIKAgAJAgA8Mw==";
        public static bool E1Enabled = false;
        public static bool E6Enabled = false;
        public static bool RPCSpam = false;
        public static int Event1Count = 0;
        public static bool Idek = false;
        public static bool LogEvents = false;
        public static int Event6Count = 0;
        public static List<string> Payloads = new List<string>();
        public static List<UserStruct> vanishUsers = new List<UserStruct>();
    }
    public class UserStruct
    {
        public string userId { get; set; }
        public Player player { get; set; }
    }
}
