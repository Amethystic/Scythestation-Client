using System;
using MelonLoader;

namespace ScytheStation.Core.Etc
{
    internal class Etc
    {
        public static void A()
        {
            MelonLogger.Msg(ConsoleColor.Yellow, $"[VERSION] You are now on v{Main.Version}, Enjoy your time.");
        }
        public static void B()
        {
            MelonLogger.Msg(ConsoleColor.Yellow, "[MUSIC] Now playing: Custom Loading Audio");
        }
        public static void C()
        {
            MelonLogger.Msg(ConsoleColor.Blue, "[CREDITS] Thanks Scrim#0069 (Vanix / EzBase Dev), plasma#1337 (ScytheStation User [Code Helper] / Meowengine Dev), Residnt (IKFunnies Dev), And Blaze#6666 (Deob Maps / ETC) / xAstroBoy#1337 / CriticalSociety#6453 (Love u <3 / E1 Fix & Addition) / _1254 (Fly) / UrFingPoor (VRCPlates) (I edited it w/o hwid spoof [Cool knah stuff man]) / Gala (Save System) / Someone from the quest vrc modding scene (E1 Fix). Hope you have a nice day!");
        }
    }
}
