using MelonLoader;
using System;
using VRC;
using static ScytheStation.Core.Patch;

namespace ScytheStation.Core
{
    internal class Patches
    {
        //Do your patching here
        private static int Patch = 0;
        public static void Init()
        {
            //Where your patches are initialized IF YOU CAN'T TELL ALREADY
            MelonLogger.Msg("[LOADER] Initializing Patches...");

            EasyPatching.EasyPatchMethodPost(typeof(NetworkManager), "Method_Public_Void_Player_0", typeof(Patches), "Join");
            Patch++;
            EasyPatching.EasyPatchMethodPost(typeof(NetworkManager), "Method_Public_Void_Player_2", typeof(Patches), "Leave");
            Patch++;

            MelonLogger.Msg($"[LOADER] Patched {Patch} Patches");
        }

        private static void Join(Player param_1)
        {
            MelonLogger.Msg(ConsoleColor.Green, "[JOIN] Player: " + param_1.field_Private_APIUser_0.displayName);
        }

        private static void Leave(Player param_1)
        {
            MelonLogger.Msg(ConsoleColor.Red, "[LEFT] Player: " + param_1.field_Private_APIUser_0.displayName);
        }
    }
}
