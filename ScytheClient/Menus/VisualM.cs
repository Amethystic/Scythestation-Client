using ApolloCore.API.QM;
using System;
using MelonLoader;
using ScytheStation.API.Utils;
using Obfuscation = System.Reflection.ObfuscationAttribute;

namespace ScytheStation.Menus
{
    internal class VisualM
    {
        [Obfuscation(Exclude = false)]
        public static void Init(QMTabMenu menu)
        {
            // VISUAL MENU //
            var AnotherMenu5 = new QMNestedButton(menu, 4, 0, "Visuals", "I can see you!", "Visuals");
            new QMToggleButton(AnotherMenu5, 1, 0, "Visualize all Players", delegate
            { Components.MainSettings.ESPCapsules.Value = true; MelonLogger.Msg(ConsoleColor.Blue, "[VISUALS] ESP On"); Notificator.WriteHudMessage($"[VISUALS] I see you"); }, delegate
            { Components.MainSettings.ESPCapsules.Value = false; MelonLogger.Msg(ConsoleColor.DarkBlue, "[VISUALS] ESP Off"); Notificator.WriteHudMessage($"[VISUALS] Im blind"); }, "Highlights players with capsules");
            new QMToggleButton(AnotherMenu5, 2, 0, "Visualize all Items", delegate
            { Components.MainSettings.IESP.Value = true; MelonLogger.Msg(ConsoleColor.Blue, "[VISUALS] IESP On"); Notificator.WriteHudMessage($"[VISUALS] I see things"); }, delegate
            { Components.MainSettings.IESP.Value = false; MelonLogger.Msg(ConsoleColor.DarkBlue, "[VISUALS] IESP Off"); Notificator.WriteHudMessage($"[VISUALS] Im blinded"); }, "Highlights Items with renderers");
            // VISUAL MENU //
            MelonLogger.Msg(ConsoleColor.Green, "[MENUS] VisualManager Loaded", MenuManager.C++);
        }
    }
}
