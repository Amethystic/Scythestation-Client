using MelonLoader;
using System.IO;
using System.Net;
using System.Threading;

namespace SStationAutoLoader.Loader
{
    internal class UpdateManager
    {
        public static void B(string Modlocate) { MelonLogger.Msg("Installing Update for ScytheStation"); if (File.Exists(Modlocate)) { try { var wc = new WebClient(); wc.DownloadFile("https://scythe.clan.su/ScytheStation.dll", Modlocate); MelonLogger.Msg("You are now on the Latest Version"); } catch { MelonLogger.Error("Did a fucky"); Thread.Sleep(-1); } }}
    }
}
