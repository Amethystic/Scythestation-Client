using System;
using System.Diagnostics;
using System.Collections.Generic;
using MelonLoader;
using UnityEngine;
using ScytheStation.Menus;
using ScytheStation.Core;
using ScytheStation.Functions;
using System.Collections;
using System.IO;
using UnityEngine.Networking;
using ScytheStation.Core.FileManager;
using ScytheStation.Core.Etc;

[assembly: MelonInfo(typeof(ScytheStation.Main), "ScytheStation", "2.4", "Scythe Innovation's (Unpasting Process #4)")]
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

        public static string Version = "2.4";
        public static string Name = $"<color=#fc0ac0><b>ScytheStation</b></color> [v{Version}]";
        public static string Author = "Scythe Innovation's";
        public static string N2 = $"<color=#f50a70><b>S</b></color><color=#e10af5><b>c</b></color><color=#b60af5><b>y</b></color><color=#8f0af5><b>t</b></color><color=#5c0af5><b>h</b></color><color=#2d0af5><b>e</b></color> <color=#fcfcfc><b>[v{Version}]</b></color>";
        public static bool GameInitialized = false;

        /*Module Listing lol*/
        public static List<Module> Mod = new List<Module>();
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("To the station we go");
        }
        public override void OnInitializeMelon()
        {
            // Mod things b4 loading
            Etc.C();
            MelonLogger.WriteSpacer();
            MelonLogger.Msg(ConsoleColor.Gray, "---------------------------------------------------");
            Artwork.DrawArt();
            MelonUtils.SetConsoleTitle($"ScytheStation [v{Version}]");
            MelonLogger.WriteSpacer();
            Etc.A();
            MelonLogger.Msg(ConsoleColor.Gray, "---------------------------------------------------");
            MelonLogger.Msg(ConsoleColor.Gray, "|      [LOADER] Initializing ScytheStation...     |");
            MelonLogger.Msg(ConsoleColor.Gray, "---------------------------------------------------");
            Directories.CreateFolders();
            Directories.ValidateFolders();
            Installer.Init();
        }
        public override void OnLateInitializeMelon()
        {
            // Unneeded thingy dont wrry ab it ;)
            MelonLogger.Msg(ConsoleColor.Magenta, "[GAME] Late Start :|");
        }
        public override void OnGUI()
        {
            if (!GameInitialized && UnityEngine.Object.FindObjectOfType<VRC.UI.Elements.QuickMenu>() != null) 
            {
                GameInitialized = true;
                new WaitForSeconds(5.259f); //waits just incase
                MenuManager.Init();
                MelonLogger.Msg(ConsoleColor.Gray, "[LOADER] Initiating Logs...");
                MelonLogger.WriteSpacer();
                MelonLogger.Msg(ConsoleColor.Gray, "---------------------------------------------------");
                MelonLogger.Msg(ConsoleColor.Gray, "|                  Logs Initiated!                |");
                MelonLogger.Msg(ConsoleColor.Gray, "---------------------------------------------------");
                MelonLogger.WriteSpacer();
            }
        }

        public override void OnUpdate()
        {
            // Hittin up every frames phone
            Movements.OnUpdate();
            Movements.ClickTPToggle();
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            // Scene Loads
            MelonLogger.Msg(ConsoleColor.Gray, "[GAME] World loaded!");
        }
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            // Scene Initiates
            MelonCoroutines.Start(Music());
            MelonLogger.Msg(ConsoleColor.Gray, "[GAME] Initializing World...");
        }
        public IEnumerator Music()
        {
            Etc.B();
            AudioSource audioSource = new AudioSource();
            UnityWebRequest uwr = UnityWebRequest.Get("file://" + Path.Combine(Environment.CurrentDirectory, $"{Directories.Folder}\\Misc\\Loading\\Load.ogg"));
            uwr.SendWebRequest();
            while (!uwr.isDone) { yield return null; }
            AudioClip audiofile = WebRequestWWW.InternalCreateAudioClipUsingDH(uwr.downloadHandler, uwr.url, false, false, 0);
            audiofile.hideFlags += 32;
            while (audioSource == null)
            {
                GameObject gameObject = GameObject.Find("MenuContent/Popups/LoadingPopup/LoadingSound");
                audioSource = ((gameObject != null) ? gameObject.GetComponent<AudioSource>() : null);
                yield return null;
            }
            audioSource.clip = audiofile;
            audioSource.Stop();
            audioSource.volume = 0.07f;
            audioSource.Play();
            yield break;
        }
        public override void OnApplicationQuit()
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}