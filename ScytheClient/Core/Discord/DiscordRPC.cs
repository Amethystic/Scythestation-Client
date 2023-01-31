using System;
using ScytheStation.Core.FileManager;
using VRC.Core;
using VRC;
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
        internal static void UpdateWorld()
        {
            var world = RoomManager.field_Internal_Static_ApiWorld_0;
            var instance = RoomManager.field_Internal_Static_ApiWorldInstance_0;
            switch (instance.type)
            {
                default:
                    presence.state = "Changing Worlds...";
                    presence.partyId = Guid.NewGuid().ToString();
                    presence.partyMax = 1;
                    presence.partySize = 1;
                    break;

                case InstanceAccessType.Public:
                    presence.state = $"[Public] {world.name}";
                    break;

                case InstanceAccessType.FriendsOfGuests:
                    presence.state = $"[Friends+] {world.name}";
                    break;

                case InstanceAccessType.FriendsOnly:
                    presence.state = $"[Friends] {world.name}";
                    break;

                case InstanceAccessType.InvitePlus:
                    presence.state = $"[Invite+] {world.name}";
                    break;

                case InstanceAccessType.InviteOnly:
                    presence.state = $"[Invite] {world.name}";
                    break;

                case InstanceAccessType.Group:
                    presence.state = $"[Group] {world.name}";
                    break;

                case InstanceAccessType.GroupPlus:
                    presence.state = $"[Group+] {world.name}";
                    break;
            }
            presence.partyId = instance.id;
            presence.partyMax = world.capacity;
            presence.partySize = PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.Count;
            DiscordRpc.UpdatePresence(ref presence);
        }

        internal static void UpdatePlayerCount()
        {
            presence.partySize = PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.Count;
            DiscordRpc.UpdatePresence(ref presence);
        }
    }
}
