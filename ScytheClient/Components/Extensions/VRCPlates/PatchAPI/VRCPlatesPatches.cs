using System;
using System.Reflection;

namespace VRCPlates.Patches
{
    internal class VRCPlatesPatches
    {
        public static HarmonyLib.Harmony Harmony { get; set; }
        public static HarmonyLib.Harmony Instance = new HarmonyLib.Harmony("ScythePlates");

        [Obsolete]
        public static Harmony.HarmonyMethod GetLocalPatch(Type type, string methodName)
        {
            return new Harmony.HarmonyMethod(type.GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic));
        }
        public static void InitPatches()
        {
            try
            {
                _OnPlayer.InitOnPlayer();
            }
            catch (Exception ERR) { MelonLoader.MelonLogger.Msg(ERR.Message); }
        }
    }
}
