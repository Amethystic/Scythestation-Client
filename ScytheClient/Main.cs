using System;
using System.Diagnostics;
using System.Collections.Generic;
using MelonLoader;
using UnityEngine;
using ScytheStation.Menus;
using ScytheStation.Core;
using ScytheStation.Functions;
using ScytheStation.Core.FileManager;
using ScytheStation.Core.Etc;

[assembly: MelonInfo(typeof(ScytheStation.Main), "ScytheStation", "2.3", "Scythe Innovation's (Unpasting Process #3)")]
[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonAuthorColor(ConsoleColor.Magenta)]
[assembly: MelonColor(ConsoleColor.DarkMagenta)]

// Credits to Scrim & Lime&Pyro
// Thanks to xAstroBoy 4 helping :P
namespace ScytheStation
{
    public class Main : MelonMod
    {
        /*Public Static Strings*/

        public static string Version = "2.3";
        public static string Name = $"<color=#fc0ac0><b>ScytheStation</b></color> [v{Version}]";
        public static string Author = "Scythe Innovation's";
        public static string N2 = $"<color=#f50a70><b>S</b></color><color=#e10af5><b>c</b></color><color=#b60af5><b>y</b></color><color=#8f0af5><b>t</b></color><color=#5c0af5><b>h</b></color><color=#2d0af5><b>e</b></color> <color=#fcfcfc><b>[v{Version}]</b></color>";
        public static bool GameInitialized = false;

        /*Module Listing lol*/
        public static List<Module> Mod = new List<Module>();

        public override void OnInitializeMelon()
        {
            // Mod things b4 loading
            Etc.C();
            MelonLogger.WriteSpacer();
            Artwork.DrawArt();
            MelonUtils.SetConsoleTitle($"ScytheStation [v{Version}]");
            MelonLogger.WriteSpacer();
            Etc.A();
            MelonLogger.Msg(ConsoleColor.Gray, "___________________________________________________");
            MelonLogger.WriteSpacer();
            MelonLogger.Msg(ConsoleColor.Gray, "[LOADER] Initializing ScytheStation...");
            Directories.CreateFolders();
            Directories.ValidateFolders();
            Installer.Init();
        }
        public override void OnLateInitializeMelon()
        {
            MelonLogger.Msg(ConsoleColor.Magenta, "[GAME] Late Start :|");
        }
        public override void OnLevelWasLoaded(int sceneName)
        {
            // Scene Loads
            MelonLogger.Msg(ConsoleColor.Gray, "[GAME] Scene loaded!");
        }
        public override void OnLevelWasInitialized(int sceneName)
        {
            // Scene Initiates
            MelonLogger.Msg(ConsoleColor.Gray, "[GAME] Initializing Scene...");
        }
        public override void OnUpdate()
        {
            // Hittin up every frames phone
            Movements.OnUpdate();
            Movements.ClickTPToggle();
        }
        public override void OnGUI()
        {
            if (!GameInitialized || GameObject.Find("QuickMenuLoader") != null)
            {
                GameInitialized = true;
                new WaitForSeconds(0.259f);
                MenuManager.Init();
                MelonLogger.Msg(ConsoleColor.Gray, "[LOADER] Initiating Logs...");
                MelonLogger.WriteSpacer();
                MelonLogger.Msg(ConsoleColor.Gray, "                  Logs Initiated!                  ");
                MelonLogger.Msg(ConsoleColor.Gray, "___________________________________________________");
                MelonLogger.WriteSpacer();
            }
        }
        public override void OnApplicationQuit()
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}