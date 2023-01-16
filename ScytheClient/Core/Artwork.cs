using System;
using MelonLoader;

namespace ScytheStation.Core
{
    internal class Artwork
    {
        public static void DrawArt()
        {
            MelonLogger.Msg(ConsoleColor.Gray, "                SCYTHE + STATION      ");
            MelonLogger.WriteSpacer();
            MelonLogger.Msg(ConsoleColor.White, "  x                       ,--.  ,--.      +        ");
            MelonLogger.Msg(ConsoleColor.White, "    ,---. ,---.,--. ,--.,-'  '-.|  ,---. ,---.     ");
            MelonLogger.Msg(ConsoleColor.Magenta, "   (  .-'| .--'x_  '  / '-.  .-'|  .-.  | .-. :    ");
            MelonLogger.Msg(ConsoleColor.Magenta, "   .-'  `) `--.  x   '    |  |  |  | |  x   --.    ");
            MelonLogger.Msg(ConsoleColor.DarkMagenta, "   `----' `---'.-'  /     `--'  `--' `--'`----'    ");
            MelonLogger.Msg(ConsoleColor.DarkMagenta, "    `           `---'                          x   ");
            MelonLogger.WriteSpacer();
            MelonLogger.Msg(ConsoleColor.Gray, "                SCYTHE + STATION      ");
            MelonLogger.Msg(ConsoleColor.Magenta, "               Scythe Innovation's   ");
        }
    }
}
