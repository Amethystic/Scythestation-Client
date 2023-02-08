using ApolloCore.API.QM;
using System;
using MelonLoader;
using ScytheStation.API.Utils;

namespace ScytheStation.Menus
{
    internal class VisualM
    {
        public static void Init(QMTabMenu menu)
        {
            // VISUAL MENU //
            var AnotherMenu5 = new QMNestedButton(menu, 4, 0, "Visuals", "I can see you!", "Visuals");
            new QMToggleButton(AnotherMenu5, 1, 0, "Visualize all Players", delegate
            { Components.MainSettings.ESPCapsules.Value = true; MelonLogger.Msg(ConsoleColor.Blue, "[VISUALS] ESP On"); Notificator.WriteHudMessage($"[VISUALS] I see you"); }, delegate
            { Components.MainSettings.ESPCapsules.Value = false; MelonLogger.Msg(ConsoleColor.DarkBlue, "[VISUALS] ESP Off"); Notificator.WriteHudMessage($"[VISUALS] Im blind"); }, "Highlights players with capsules");
            new QMToggleButton(AnotherMenu5, 2, 0, "Nameplates", delegate
            { Components.MainSettings.Nameplates.Value = true; MelonLogger.Msg(ConsoleColor.Blue, "[VISUALS] Rejoin to see Nameplates"); Notificator.WriteHudMessage($"[VISUALS] Rejoin to see Nameplates"); }, delegate
            { Components.MainSettings.Nameplates.Value = false; MelonLogger.Msg(ConsoleColor.DarkBlue, "[VISUALS] Rejoin to turn off Nameplates fully"); Notificator.WriteHudMessage($"[VISUALS] Rejoin to turn off Nameplates fully"); }, "Highlights players with capsules");
            new QMToggleButton(AnotherMenu5, 3, 0, "Visualize all Items", delegate
            { Components.MainSettings.IESP.Value = true; Functions.Visuals.ObjectESP.PickupESP(); MelonLogger.Msg(ConsoleColor.Blue, "[VISUALS] IESP On"); Notificator.WriteHudMessage($"[VISUALS] I see things"); }, delegate
            { Components.MainSettings.IESP.Value = false; Functions.Visuals.ObjectESP.PickupESP(); MelonLogger.Msg(ConsoleColor.DarkBlue, "[VISUALS] IESP Off"); Notificator.WriteHudMessage($"[VISUALS] Im blinded"); }, "Highlights Items with renderers");
            // VISUAL MENU //
            // CUSTOMIZATIONS // 
            var AnotherMenu6 = new QMNestedButton(AnotherMenu5, 4, 3f, "Menu Visuals", "Looks nice!", "Menu Visuals");
            new QMToggleButton(AnotherMenu6, 1, 0, "Hide button Backgrounds", delegate
            { Components.MenuCustomizationSettings.HideApiButtonBG.Value = true; Functions.Visuals.MenuCustomization.HideMenuApiButtons(); MelonLogger.Msg(ConsoleColor.Blue, "[VISUALS] Buttons BGS On"); Notificator.WriteHudMessage($"[VISUALS] Buttons BGS On"); }, delegate
            { Components.MenuCustomizationSettings.HideApiButtonBG.Value = false; Functions.Visuals.MenuCustomization.HideMenuApiButtons(); MelonLogger.Msg(ConsoleColor.DarkBlue, "[VISUALS] Buttons BGS Off"); Notificator.WriteHudMessage($"[VISUALS] Buttons BGS Off"); }, "Shows button bgs or hides them idk");
            MelonLogger.Msg(ConsoleColor.Green, "[MENUS] VisualManager Loaded", MenuManager.C++);
        }
    }
}
