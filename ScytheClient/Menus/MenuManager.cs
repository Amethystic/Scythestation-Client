using System;
using MelonLoader;
using UnityEngine;
using ApolloCore.API.QM;
using ScytheStation.API.Utils;

namespace ScytheStation.Menus
{
    internal class MenuManager
    {   // Call all your menus in here yes this is messy but screw you
        public const string MenuIdent = "i";
        public static Sprite TabIcon = $"{Environment.CurrentDirectory}\\ScytheStation\\Dependencies\\Images\\scythestation.png".LoadSpriteFromDisk();
        public static int C = 0;
        public static void Init()
        {
            MelonLogger.Msg(ConsoleColor.Gray, "[MENUMANAGER] Initializing Menu..."); MelonLogger.WriteSpacer();
            try
            {
                QMTabMenu tabMenu = new($"{Main.Name} By {Main.Author}", $"{Main.N2}", TabIcon);
                Ironic.Init(tabMenu);
                Game.Init(tabMenu);
                Movement.Init(tabMenu);
                Self.Init(tabMenu);
                VisualM.Init(tabMenu);
                GameWorlds.Init(tabMenu);

                MelonLogger.Msg(ConsoleColor.Green, $"[MENUMANAGER] {C} Menus Initialized!");
                MelonLogger.WriteSpacer();
            } catch { MelonLogger.Error("[MENUMANAGER] Failed to initialize Menu..."); MelonLogger.WriteSpacer(); }
        }
    }
}
