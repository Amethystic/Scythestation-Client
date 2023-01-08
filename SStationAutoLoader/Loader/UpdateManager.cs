using MelonLoader;
using System.IO;
using System.Net;
using System.Threading;

namespace SStationAutoLoader.Loader
{
    internal class UpdateManager
    {
        public static void B(string Modlocate)
        {
            if (File.Exists(Modlocate))
            {
                try
                {
                    MelonLogger.Msg("Installing Update for ScytheStation");
                    var wc = new WebClient();
                    wc.DownloadFile("https://scythe.clan.su/ScytheStation.dll", Modlocate);
                    MelonLogger.Msg("You are now on the Latest Version");
                }
                catch { MelonLogger.Error("FAILED TO INSTALL NEW UPDATE CHECK DISCORD FOR SUPPORT OR BUGS"); Thread.Sleep(-1); }
            }
        }
    }
}
