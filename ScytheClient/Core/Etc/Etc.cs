﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ScytheStation;
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
            MelonLogger.Msg(ConsoleColor.Blue, "[CREDITS] Thanks Scrim#0069 (Vanix / EzBase Dev), plasma#1337 (ScytheStation User [Code Helper] / Meowengine Dev), Residnt (IKFunnies Dev), And Blaze#6666 (Deob Maps / ETC). Hope you have a nice day! (More will be added shortly)");
        }
        public static void D()
        {
            MelonLogger.Msg(ConsoleColor.Blue, "[DISCORD SUPPORT] Initializing and Displaying");
        }
    }
}