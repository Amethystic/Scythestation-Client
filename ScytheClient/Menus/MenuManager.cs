using System;
using MelonLoader;
using UnityEngine;
using ApolloCore.API.QM;
using ScytheStation.Core.FileManager;
using ScytheStation.API.Utils;

namespace ScytheStation.Menus
{
    internal class MenuManager
    {
        public const string MenuIdent = "";
        public static QMTabMenu tabMenu;
        public static Sprite TabIcon = (Environment.CurrentDirectory + "\\ScytheStation\\Dependencies\\Images\\scythestation.png").LoadSpriteFromDisk();
        public static void Init()
        {
            MenuManager.tabMenu = new QMTabMenu($"{Main.Name} By {Main.Author}", $"{Main.N2}", MenuManager.TabIcon);
            MelonLogger.Msg(ConsoleColor.Gray, "[LOADER] Initializing Menu...");
            SecondaryMenu.Init(MenuManager.tabMenu);
            MelonLogger.Msg(ConsoleColor.Green, "[LOADER] Menu Initialized!");
            MelonLogger.WriteSpacer();
            //Call all your menus in here yes this is messy but screw you
        }
    }
}
