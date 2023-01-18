using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using MelonLoader;
using UnityEngine;
using UnityEngine.Networking;
using ScytheStation.Menus;
using ScytheStation.Core;
using ScytheStation.Core.FileManager;
using ScytheStation.Core.Etc;
using ScytheStation.Components;

[assembly: MelonInfo(typeof(ScytheStation.Main), "ScytheStation", "2.2", "Scythe Innovation's (Unpasting Process #2)")]
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

        public static string Version = "2.2";
        public static string Name = $"<color=#fc0ac0><b>ScytheStation</b></color> [v{Version}]";
        public static string Author = "Scythe Innovation's";
        public static string N2 = $"<color=#f50a70><b>S</b></color><color=#e10af5><b>c</b></color><color=#b60af5><b>y</b></color><color=#8f0af5><b>t</b></color><color=#5c0af5><b>h</b></color><color=#2d0af5><b>e</b></color> <color=#fcfcfc><b>[v{Version}]</b></color>";

        /*Module Listing lol*/

        /* From Scyt - "Unskidded :3" */
        public static List<Module> Mod = new List<Module>();

        public override void OnInitializeMelon()
        {
            // Mod things b4 loading
            Etc.C();
            MelonLogger.WriteSpacer();
            Artwork.DrawArt();
            MelonLogger.WriteSpacer();
            MelonLogger.Msg(ConsoleColor.Gray, "___________________________________________________");
            MelonLogger.Msg(ConsoleColor.Gray, "___________________________________________________");
            MelonLogger.WriteSpacer();
            MelonLogger.Msg(ConsoleColor.Gray, "[LOADER] Initializing ScytheStation...");
            Functions.GameControls.UnCapLol();
            Directories.CreateFolders();
            Installer.Init();
            Directories.ValidateFolders();
            MelonUtils.SetConsoleTitle($"ScytheStation [v{Version}]");
            Patches.Init();
            VRC.Integrations.DiscordManager.field_Private_Static_Int64_0.Equals(false);
            Settings.DiscordRPCOn();
        }

        public override void OnApplicationLateStart()
        {
            // load u faggot
            MelonCoroutines.Start(WaitForQuickMenu());
            MelonLogger.Msg(ConsoleColor.Green, "[LOADER] Initialized!");
            MelonLogger.Msg(ConsoleColor.Magenta, "[LOADER] ScytheStation Now loading...");
        }

        public override void OnUpdate()
        {
            // Hittin up every frames phone
            Functions.Movements.OnUpdate();
            Functions.Movements.ClickTPToggle();
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            // Scene Initiates
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            // Scene Loads
            MelonCoroutines.Start(WebRequest());
        }
        public IEnumerator WebRequest()
        {
            Etc.B();
            AudioSource audioSource = new AudioSource();
            AudioSource audioSource2 = new AudioSource();
            UnityWebRequest uwr = UnityWebRequest.Get("file://" + Path.Combine(Environment.CurrentDirectory, $"{Directories.Folder}\\Misc\\Loading\\Load.ogg"));
            uwr.SendWebRequest();
            while (!uwr.isDone)
            {
                yield return null;
            }
            AudioClip audiofile = WebRequestWWW.InternalCreateAudioClipUsingDH(uwr.downloadHandler, uwr.url, false, false, 0);
            audiofile.hideFlags += 32;
            while (audioSource == null)
            {
                GameObject gameObject = GameObject.Find("LoadingBackground_TealGradient_Music/LoadingSound");
                audioSource = ((gameObject != null) ? gameObject.GetComponent<AudioSource>() : null);
                yield return null;
            }
            audioSource.clip = audiofile;
            audioSource.Stop();
            audioSource.volume = 0.07f;
            audioSource.Play();
            while (audioSource2 == null)
            {
                GameObject gameObject2 = GameObject.Find("MenuContent/Popups/LoadingPopup/LoadingSound");
                audioSource2 = ((gameObject2 != null) ? gameObject2.GetComponent<AudioSource>() : null);
                yield return null;
            }
            audioSource2.clip = audiofile;
            audioSource2.Stop();
            audioSource2.volume = 0.07f;
            audioSource2.Play();
            yield break;
        }
        private static IEnumerator WaitForQuickMenu()
        {
            //Waits for the VRChat Quickmenu and then loads your menus
            while (UnityEngine.Object.FindObjectOfType<VRC.UI.Elements.QuickMenu>() == null) yield return null;
            new WaitForSeconds(0.259f); //waits just incase
            MenuManager.Init();
            MelonLogger.Msg(ConsoleColor.Gray, "[LOADER] Initiating Logs...");
            MelonLogger.WriteSpacer();
            MelonLogger.Msg(ConsoleColor.Gray, "                  Logs Initiated!                  ");
            MelonLogger.Msg(ConsoleColor.Gray, "___________________________________________________");
            MelonLogger.Msg(ConsoleColor.Gray, "___________________________________________________");
            MelonLogger.WriteSpacer();
            Etc.A();
            yield break;
        }
        public override void OnApplicationQuit()
        {
            //MelonPreferences.Save(); // Stop using this please
            Settings.DiscordRPCOff();
            Process.GetCurrentProcess().Kill();
        }
    }
}