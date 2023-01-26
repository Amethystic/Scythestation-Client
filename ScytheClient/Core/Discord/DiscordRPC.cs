using System;
using ScytheStation.Core.FileManager;
using Obfuscation = System.Reflection.ObfuscationAttribute;

namespace ScytheStation.Core.Discord
{
    internal static class Manager
    {
        [Obfuscation(Exclude = false)]
        internal static DiscordRpc.RichPresence presence;
        internal static DiscordRpc.EventHandlers eventHandlers;

        public static string RPC = Environment.CurrentDirectory + $"{Directories.MDir}\\Dependencies\\discord-rpc.dll";
        public static string appid = "981033663301029949";
        public static string CREDITS = $"ScytheStation {Main.Version}";
        public static string GAMEIMGAE = "scythestation";
        public static string RPCTEXT = $"VRChat";
        public static string GAMEIMGAE2 = "scyt";
        public static string RPCTEXT2 = "";
        public static string STATE = $"";

        internal static void InitRPC()
        {
            eventHandlers = default;
            eventHandlers.errorCallback = delegate (int code, string message) { };
            presence.state = STATE;
            presence.details = RPCTEXT;
            presence.largeImageKey = GAMEIMGAE;
            presence.largeImageText = CREDITS;
            presence.smallImageKey = GAMEIMGAE2;
            presence.smallImageText = RPCTEXT2;
            presence.partySize = 0;
            presence.partyMax = 0;
            presence.startTimestamp = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            presence.partyId = Guid.NewGuid().ToString();
            presence.spectateSecret = "";
            try
            {
                DiscordRpc.Initialize($"{appid}", ref eventHandlers, true, "");
                DiscordRpc.UpdatePresence(ref presence);
            }
            catch { }
        }
    }
}
