using MelonLoader;
using System.IO;
using System.Net;

namespace ScytheStation.Core.FileManager
{
    internal class Installer
    {
        private static int FCOUNT2 = 0;
        public static void Init()
        {
            MelonLogger.Msg("[LOADER] Checking for required files...");
            if (!File.Exists($"{Directories.Folder}\\Dependencies\\discord-rpc.dll"))
            {
                try
                {
                    var wc = new WebClient();
                    wc.DownloadFile("https://scythe.clan.su/discord-rpc.dll", $"{Directories.Folder}\\Dependencies\\discord-rpc.dll");
                    FCOUNT2++;
                }
                catch { }
            }
            if (!File.Exists($"{Directories.Folder}\\Misc\\Loading\\Load.ogg"))
            {
                try
                {
                    var wc = new WebClient();
                    wc.DownloadFile("https://scythe.clan.su/Load.ogg", $"{Directories.Folder}\\Misc\\Loading\\Load.ogg");
                    FCOUNT2++;
                }
                catch { }
            }
            if (!File.Exists($"{Directories.Folder}\\Dependencies\\Images\\scythestation.png"))
            {
                try
                {
                    var wc = new WebClient();
                    wc.DownloadFile("https://scythe.clan.su/scythestation.png", $"{Directories.Folder}\\Dependencies\\Images\\scythestation.png");
                    FCOUNT2++;
                }
                catch { }
            }
            if (!File.Exists($"{Directories.Folder}\\Dependencies\\EacMelon.exe"))
            {
                try
                {
                    var wc = new WebClient();
                    wc.DownloadFile("https://thats.gg/download/vrchat/EacMelon.exe", $"{Directories.Folder}\\Dependencies\\EacMelon.exe");
                    FCOUNT2++;
                }
                catch { }
            }
            if (!File.Exists($"{Directories.GDir}\\Mods\\ScytheStation.dll"))
            {
                try
                {
                    var wc = new WebClient();
                    wc.DownloadFile("https://scythe.clan.su/ScytheStation.dll", $"{Directories.GDir}\\Mods\\ScytheStation.dll");
                    FCOUNT2++;
                }
                catch { }
            }
            MelonLogger.Msg($"[LOADER] Recieved {FCOUNT2} Required Files");
        }
    }
}
