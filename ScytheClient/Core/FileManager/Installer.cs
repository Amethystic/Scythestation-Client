using MelonLoader;
using System.IO;
using System.Net;
using Obfuscation = System.Reflection.ObfuscationAttribute;

namespace ScytheStation.Core.FileManager
{
    internal class Installer
    {
        [Obfuscation(Exclude = false)]
        private static int FCOUNT2 = 0;
        public static void Init()
        {
            MelonLogger.Msg("[LOADER] Checking for required files...");
            // Needed
            if (!File.Exists($"{Directories.Folder}\\Dependencies\\discord-rpc.dll")) { try { var wc = new WebClient(); wc.DownloadFile("https://scythe.clan.su/discord-rpc.dll", $"{Directories.Folder}\\Dependencies\\discord-rpc.dll"); FCOUNT2++; } catch { MelonLogger.Error($"[BL] Failed to download a ScytheStation required file"); } }
            if (!File.Exists($"{Directories.Folder}\\Misc\\Loading\\Load.ogg")) { try { var wc = new WebClient(); wc.DownloadFile("https://scythe.clan.su/Load.ogg", $"{Directories.Folder}\\Misc\\Loading\\Load.ogg"); FCOUNT2++; } catch { MelonLogger.Error($"[BL] Failed to download a ScytheStation required file"); } }
            if (!File.Exists($"{Directories.Folder}\\Dependencies\\Images\\scythestation.png")) { try { var wc = new WebClient(); wc.DownloadFile("https://scythe.clan.su/scythestation.png", $"{Directories.Folder}\\Dependencies\\Images\\scythestation.png"); FCOUNT2++; } catch { MelonLogger.Error($"[BL] Failed to download a ScytheStation required file"); } }
            if (!File.Exists($"{Directories.Folder}\\Dependencies\\Images\\M1.png")) { try { var wc = new WebClient(); wc.DownloadFile("https://scythe.clan.su/M1.png", $"{Directories.Folder}\\Dependencies\\Images\\M1.png"); FCOUNT2++; } catch { MelonLogger.Error($"[BL] Failed to download a ScytheStation required file"); } }
            if (!File.Exists($"{Directories.Folder}\\Dependencies\\Images\\M2.png")) { try { var wc = new WebClient(); wc.DownloadFile("https://scythe.clan.su/M2.png", $"{Directories.Folder}\\Dependencies\\Images\\M2.png"); FCOUNT2++; } catch { MelonLogger.Error($"[BL] Failed to download a ScytheStation required file"); } }
            if (!File.Exists($"{Directories.MDir}\\VRCPlates.dll")) { try { var wc = new WebClient(); wc.DownloadFile("https://scythe.clan.su/VRCPlates.dll", $"{Directories.MDir}\\VRCPlates.dll"); FCOUNT2++; } catch { MelonLogger.Error($"[BL] Failed to download a ScytheStation required file"); } }

            // Stylizations
            try { var wc = new WebClient(); wc.DownloadFile("https://scythe.clan.su/SplashScreen.png", $"{Directories.GDir}\\EasyAntiCheat\\SplashScreen.png"); FCOUNT2++; } catch { MelonLogger.Error("[BL] Failed to download a ScytheStation required file"); }
            try { var wc = new WebClient(); wc.DownloadFile("https://scythe.clan.su/Config.cfg", $"{Directories.GDir}\\UserData\\MelonStartScreen\\Config.cfg"); FCOUNT2++; } catch { MelonLogger.Error("[BL] Failed to download a ScytheStation required file"); }
            try { var wc = new WebClient(); wc.DownloadFile("https://scythe.clan.su/Background.png", $"{Directories.GDir}\\UserData\\MelonStartScreen\\Themes\\ScytheStation\\Background.png"); FCOUNT2++; } catch { MelonLogger.Error("[BL] Failed to download a ScytheStation required file"); }
            try { var wc = new WebClient(); wc.DownloadFile("https://scythe.clan.su/Background.cfg", $"{Directories.GDir}\\UserData\\MelonStartScreen\\Themes\\ScytheStation\\Background.cfg"); FCOUNT2++; } catch { MelonLogger.Error("[BL] Failed to download a ScytheStation required file"); }
            try { var wc = new WebClient(); wc.DownloadFile("https://scythe.clan.su/LoadingImage.cfg", $"{Directories.GDir}\\UserData\\MelonStartScreen\\Themes\\ScytheStation\\LoadingImage.cfg"); FCOUNT2++; } catch { MelonLogger.Error("[BL] Failed to download a ScytheStation required file"); }
            try { var wc = new WebClient(); wc.DownloadFile("https://scythe.clan.su/LogoImage.cfg", $"{Directories.GDir}\\UserData\\MelonStartScreen\\Themes\\ScytheStation\\LogoImage.cfg"); FCOUNT2++; } catch { MelonLogger.Error("[BL] Failed to download a ScytheStation required file"); }
            try { var wc = new WebClient(); wc.DownloadFile("https://scythe.clan.su/ProgressBar.cfg", $"{Directories.GDir}\\UserData\\MelonStartScreen\\Themes\\ScytheStation\\ProgressBar.cfg"); FCOUNT2++; } catch { MelonLogger.Error("[BL] Failed to download a ScytheStation required file"); }
            try { var wc = new WebClient(); wc.DownloadFile("https://scythe.clan.su/ProgressText.cfg", $"{Directories.GDir}\\UserData\\MelonStartScreen\\Themes\\ScytheStation\\ProgressText.cfg"); FCOUNT2++; } catch { MelonLogger.Error("[BL] Failed to download a ScytheStation required file"); }
            try { var wc = new WebClient(); wc.DownloadFile("https://scythe.clan.su/VersionText.cfg", $"{Directories.GDir}\\UserData\\MelonStartScreen\\Themes\\ScytheStation\\VersionText.cfg"); FCOUNT2++; } catch { MelonLogger.Error("[BL] Failed to download a ScytheStation required file"); }
            MelonLogger.Msg($"[LOADER] Recieved {FCOUNT2} Required Files");
        }
    }
}
