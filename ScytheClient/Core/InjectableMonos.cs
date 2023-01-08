using MelonLoader;

namespace ScytheStation.Core
{
    internal class InjectableMonos
    {
        private static int MBA = 0;
        public static void Inject()
        {
            MelonLogger.Msg($"[LOADER] Initiating Monos");

            //ClassInjector.RegisterTypeInIl2Cpp<PlayerListController>();
            //MBA++;

            MelonLogger.Msg($"[LOADER] Finished Initiating {MBA} Monos(s)");
        }
    }
}
