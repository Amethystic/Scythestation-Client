using System;
using MelonLoader;
using UnityEngine;
using ApolloCore.API.QM;
using ScytheStation.API.Utils;

namespace ScytheStation.Menus
{
    internal class MenuManager
    {
        // Call all your menus in here yes this is messy but screw you

        public static QMTabMenu tabMenu;
        public static Sprite TabIcon = (Environment.CurrentDirectory + "\\ScytheStation\\Dependencies\\Images\\scythestation.png").LoadSpriteFromDisk();
        public static void Init()
        {
            MelonLogger.Msg(ConsoleColor.Gray, "[LOADER] Initializing Menu...");

            MenuManager.tabMenu = new QMTabMenu($"{Main.Name} By {Main.Author}", $"{Main.N2}", MenuManager.TabIcon);

            Ironic.Init(MenuManager.tabMenu);
            Game.Init(MenuManager.tabMenu);
            Movement.Init(MenuManager.tabMenu);
            Self.Init(MenuManager.tabMenu);
            VisualM.Init(MenuManager.tabMenu);
            GameWorlds.Init(MenuManager.tabMenu);

            MelonLogger.Msg(ConsoleColor.Green, "[LOADER] Menu Initialized!");
            MelonLogger.WriteSpacer();
        }
    }
}
