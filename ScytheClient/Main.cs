using System;
using System.Diagnostics;
using System.Collections.Generic;
using MelonLoader;
using UnityEngine;
using ScytheStation.Menus;
using ScytheStation.Components;
using ScytheStation.Core;
using ScytheStation.Functions;
using System.IO;
using System.Collections;
using UnityEngine.Networking;
using ScytheStation.Core.FileManager;
using ScytheStation.Core.Etc;
using VRC.Integrations;
using System.Runtime.InteropServices;
using ExitGames.Client.Photon;
using UnhollowerRuntimeLib;
using VRCPlates.Patches;
using NetworkSanity.Core;
using Photon.Realtime;
using VRCPlates;
using UnhollowerBaseLib;
using VRC.Core;
using ScytheStation.Components.Extensions;

[assembly: MelonInfo(typeof(ScytheStation.Main), "ScytheStation", "2.8", "Scythe Innovation's (Unpasting Process #4)")]
[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonAuthorColor(ConsoleColor.Magenta)]
[assembly: MelonColor(ConsoleColor.DarkMagenta)]

// Credits to Scrim & Lime&Pyro & pocketnone & Requi
// Thanks to xAstroBoy 4 helping :P
namespace ScytheStation
{
    public class Main : MelonMod
    {
        /*Public Static Strings*/
        public new static HarmonyLib.Harmony Harmony { get; private set; }
        public static string Version = "2.8";
        public static string Name = $"<color=#fc0ac0><b>ScytheStation</b></color> [v{Version}]";
        public static string Author = "Scythe Innovation's";
        public static string N2 = $"<color=#f50a70><b>S</b></color><color=#e10af5><b>c</b></color><color=#b60af5><b>y</b></color><color=#8f0af5><b>t</b></color><color=#5c0af5><b>h</b></color><color=#2d0af5><b>e</b></color> <color=#fcfcfc><b>[v{Version}]</b></color>";
        public static bool GameInitialized = false;
        public static string MusicLocation = $"{Directories.Folder}\\Misc\\Loading\\Load.ogg";
        internal const string Nameinitials = "ScytheStation";
        internal static string Directory = Path.Combine(System.IO.Directory.GetCurrentDirectory(), Nameinitials);
        internal delegate void EventDelegate(IntPtr thisPtr, IntPtr eventDataPtr, IntPtr nativeMethodInfo);
        internal readonly List<object> _ourPinnedDelegates = new();
        internal static readonly List<ISanitizer> Sanitizers = new List<ISanitizer>();
        public static string Site = "https://scythestation.6ph1nx1s4.repl.co/";

        /*Module Listing lol*/
        public static List<Module> Mod = new List<Module>();
#pragma warning disable CS0672 // Member overrides obsolete member

        public override void OnApplicationStart()
#pragma warning restore CS0672 // Member overrides obsolete member
        {
            // Unneeded thingy dont wrry ab it ;)
            MelonLogger.Msg("[GAME START] To the station we go");
            Harmony = HarmonyInstance;
            IEnumerable<Type> types;
            try
            {
                types = MelonAssembly.Assembly.GetExportedTypes();
            }
            finally
            {
            }
            foreach (var t in types)
            {
                if (t.IsAbstract)
                    continue;
                if (!typeof(ISanitizer).IsAssignableFrom(t))
                    continue;

                var sanitizer = Activator.CreateInstance(t) as ISanitizer;
                Sanitizers.Add(sanitizer);
                MelonLogger.Msg($"[NS INTERGRATION] Added new Sanitizer: {t.Name}");
            }
            unsafe
            {
                var originalMethodPtr = *(IntPtr*)(IntPtr)UnhollowerUtils.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(typeof(LoadBalancingClient).GetMethod(nameof(LoadBalancingClient.OnEvent))).GetValue(null);

                EventDelegate originalDelegate = null;

                void OnEventDelegate(IntPtr thisPtr, IntPtr eventDataPtr, IntPtr nativeMethodInfo)
                {
                    if (eventDataPtr == IntPtr.Zero)
                    {
                        originalDelegate(thisPtr, eventDataPtr, nativeMethodInfo);
                        return;
                    }

                    try
                    {
                        var eventData = new EventData(eventDataPtr);
                        if (OnEventPatch(new LoadBalancingClient(thisPtr), eventData))
                            originalDelegate(thisPtr, eventDataPtr, nativeMethodInfo);
                    }
                    catch (Exception ex)
                    {
                        originalDelegate(thisPtr, eventDataPtr, nativeMethodInfo);
                        MelonLogger.Error(ex.Message);
                    }
                }

                var patchDelegate = new EventDelegate(OnEventDelegate);
                _ourPinnedDelegates.Add(patchDelegate);

                MelonUtils.NativeHookAttach((IntPtr)(&originalMethodPtr), Marshal.GetFunctionPointerForDelegate(patchDelegate));
                originalDelegate = Marshal.GetDelegateForFunctionPointer<EventDelegate>(originalMethodPtr);
            }
            unsafe
            {
                var originalMethodPtr = *(IntPtr*)(IntPtr)UnhollowerUtils.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(typeof(VRCNetworkingClient).GetMethod(nameof(VRCNetworkingClient.OnEvent))).GetValue(null);

                EventDelegate originalDelegate = null;

                void OnEventDelegate(IntPtr thisPtr, IntPtr eventDataPtr, IntPtr nativeMethodInfo)
                {
                    if (eventDataPtr == IntPtr.Zero)
                    {
                        originalDelegate(thisPtr, eventDataPtr, nativeMethodInfo);
                        return;
                    }

                    var eventData = new EventData(eventDataPtr);
                    if (VRCNetworkingClientOnPhotonEvent(eventData))
                        originalDelegate(thisPtr, eventDataPtr, nativeMethodInfo);
                }

                var patchDelegate = new EventDelegate(OnEventDelegate);
                _ourPinnedDelegates.Add(patchDelegate);

                MelonUtils.NativeHookAttach((IntPtr)(&originalMethodPtr), Marshal.GetFunctionPointerForDelegate(patchDelegate));
                originalDelegate = Marshal.GetDelegateForFunctionPointer<EventDelegate>(originalMethodPtr);
            }
        }
        public static bool OnEventPatch(LoadBalancingClient loadBalancingClient, EventData eventData)
        {
            foreach (var sanitizer in Sanitizers)
            {
                if (sanitizer.OnPhotonEvent(loadBalancingClient, eventData))
                    return false;
            }
            return true;
        }
        public static bool VRCNetworkingClientOnPhotonEvent(EventData eventData)
        {
            foreach (var sanitizer in Sanitizers)
            {
                if (sanitizer.VRCNetworkingClientOnPhotonEvent(eventData))
                    return false;
            }
            return true;
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
            MelonLogger.Msg(ConsoleColor.Gray, "-----------------------------------------------------");
            MelonLogger.Msg(ConsoleColor.Gray, "|      [LOADER] Initializing ScytheStation...       |");
            MelonLogger.Msg(ConsoleColor.Gray, "-----------------------------------------------------");
            Directories.CreateFolders();
            Directories.ValidateFolders();
            Installer.Init();
            Core.Patches.Patches.Init();
            VRCPlatesPatches.InitPatches();
            Core.Discord.Manager.InitRPC();
            ClassInjector.RegisterTypeInIl2Cpp<CustomNameplate>();
            DiscordSettings.Discord();
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
                new WaitForSeconds(0.7f); //waits just incase
                MenuManager.Init();
                Settings.Load();
                Settings.StartAutosave();
                MelonLogger.Msg(ConsoleColor.Gray, "[LOADER] Initiating Logs...");
                MelonLogger.WriteSpacer();
                MelonLogger.Msg(ConsoleColor.Gray, "-----------------------------------------------------");
                MelonLogger.Msg(ConsoleColor.Gray, "|                  Logs Initiated!                  |");
                MelonLogger.Msg(ConsoleColor.Gray, "-----------------------------------------------------");
                MelonLogger.WriteSpacer();
            }
        }
        public override void OnUpdate()
        {
            // Hittin up every frames phone
            try
            {
                Movements.OnUpdate();
            }
            catch (Exception ex) { MelonLogger.Error($"\n------------------------------------------------------------------------------------------------------\n[OnUpdate Error | Fly (IGNORE THIS ERROR, IT WORKS FINE)]\n{ex}\n------------------------------------------------------------------------------------------------------"); }
            try
            {
                Movements.ClickTPToggle();
            }
            catch (Exception ex) { MelonLogger.Error($"\n------------------------------------------------------------------------------------------------------\n[OnUpdate Error | ClickTP (IGNORE THIS ERROR, IT WORKS FINE)]\n{ex}\n------------------------------------------------------------------------------------------------------"); }
            try
            {
                Visuals.ESPToggle();
            }
            catch (Exception ex) { MelonLogger.Error($"\n------------------------------------------------------------------------------------------------------\n[OnUpdate Error | ESP (IGNORE THIS ERROR, IT WORKS FINE)]\n{ex}\n------------------------------------------------------------------------------------------------------"); }
            try
            {
                Settings2.BindingSupport();
            }
            catch (Exception ex) { MelonLogger.Error($"\n------------------------------------------------------------------------------------------------------\n[OnUpdate Error | Binding Support (IGNORE THIS ERROR, IT WORKS FINE)]\n{ex}\n------------------------------------------------------------------------------------------------------"); }
            if (Exploits.ItemOrbitToggle == true)
            {
                Exploits.ItemOrbit(IUserExtension.GetCurrentlySelectedPlayer());
            }
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            // Scene Loads
            MelonLogger.Msg(ConsoleColor.Gray, "[GAME] World loaded!");
        }
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            // Scene Initiates
            MelonLogger.Msg(ConsoleColor.Gray, "[GAME] Initializing World...");
            DiscordManager.field_Private_Static_Int64_0.Equals(false);
            try
            {
                MelonCoroutines.Start(Music());
            }
            catch(Exception ex) { MelonLogger.Error($"\n------------------------------------------------------------------------------------------------------\n[OnSceneWasInitialized Error | Music (IGNORE THIS ERROR, IT WORKS FINE)]\n{ex}\n------------------------------------------------------------------------------------------------------"); }
        }
        public IEnumerator Music()
        {
            AudioSource audioSource = new AudioSource();
            UnityWebRequest uwr = UnityWebRequest.Get("file://" + $"{MusicLocation}");
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
            // Quit Fix
            Settings.StopAutosave();
            Settings.Save();
            DiscordSettings.Discord2();
            Process.GetCurrentProcess().Kill();
        }
    }
}