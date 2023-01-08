using MelonLoader;
using System.IO;
using System.Threading;

namespace SStationAutoLoader.Loader
{
    internal class Check
    {
        public static void C()
        {
            if (!File.Exists(Install.MOD))
            {
                MelonLogger.Error("Cannot locate ScytheStation.dll");
                MelonLogger.Error("Do you not have it installed or did you change DLL name?");
                Thread.Sleep(-1);
            }
        }
    }
}
