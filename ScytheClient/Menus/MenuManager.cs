using System;
using MelonLoader;
using Sprite = UnityEngine.Sprite;
using ApolloCore.API.QM;
using ScytheStation.API.Utils;

namespace ScytheStation.Menus
{
    internal class MenuManager
    {   // Call all your menus in here yes this is messy but screw you
        public const string MenuIdent = "i";
        public static Sprite TabIcon = $"{Environment.CurrentDirectory}\\ScytheStation\\Dependencies\\Images\\scythestation.png".LoadSpriteFromDisk();
        public static int C = 0;
        public static int S = 0;
        public static void Init()
        {
            MelonLogger.Msg(ConsoleColor.Gray, "[MENUMANAGER] Initializing VRMenu..."); MelonLogger.WriteSpacer();
            try
            {
                QMTabMenu tabMenu = new($"{Main.Name} By {Main.Author}", $"{Main.N2}", TabIcon);
                Ironic.Init(tabMenu);
                Game.Init(tabMenu);
                Movement.Init(tabMenu);
                Self.Init(tabMenu);
                VisualM.Init(tabMenu);
                GameWorlds.Init(tabMenu);
                ExploitMenu.Init(tabMenu);
                MelonLogger.Msg(ConsoleColor.Green, $"[MENUMANAGER] Section 1 of {C} VRMenuItems's Initialized!"); MelonLogger.WriteSpacer();
            } catch { MelonLogger.Error("[MENUMANAGER] Failed to initialize VRMenu... (You might have a possible chance of crashing)"); MelonLogger.WriteSpacer(); }

            MelonLogger.Msg(ConsoleColor.Gray, "[MENUMANAGER] Initializing VRMenuSelectable..."); MelonLogger.WriteSpacer();
            try
            {
                QMNestedButton Usermenu = new("Menu_SelectedUser_Local", 1.5f, -0.6f, $"{Main.N2}", $"", $"{Main.N2}", true);
                GameWorldsSelective.Init(Usermenu);
                TargetExploitMenu.Init(Usermenu);
                MelonLogger.Msg(ConsoleColor.Green, $"[MENUMANAGER] Section 2 of {S} VRMenuItems's Initialized!"); MelonLogger.WriteSpacer();
            } catch { MelonLogger.Error("[MENUMANAGER] Failed to initialize VRMenuSelectable... (You might have a possible chance of crashing)"); MelonLogger.WriteSpacer(); }
        }
    }
}