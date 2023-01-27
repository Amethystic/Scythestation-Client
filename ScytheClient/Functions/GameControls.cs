using System;
using System.Threading;
using System.Diagnostics;
using MelonLoader;
using UnityEngine;
using Obfuscation = System.Reflection.ObfuscationAttribute;
using VRC.Core;
using ScytheStation.Components.Extensions;
using ScytheStation.Core.Wrappers;
using ScytheStation.Components;
using System.Collections.Generic;
using VRC.Udon;
using System.Runtime.InteropServices;
using UnityEngine.UI;


namespace ScytheStation.Functions
{
    internal class GameControls
    {
        [Obfuscation(Exclude = false)]
        public static Process mainProcess = null;
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetProcessAffinityMask(IntPtr hProcess, IntPtr dwProcessAffinityMask);
        public static void OpenSite()
        {
            Process.Start($"{Main.Site}");
            MelonLogger.Msg(ConsoleColor.Green, $"[GC] Directing to {Main.Site}");
        }
        public static void LagGame()
        {
            Application.targetFrameRate = 1;
        }
        public static void Capto60()
        {
            Application.targetFrameRate = 60;
        }
        public static void UnCapLol()
        {
            Application.targetFrameRate = 900;
        }
        public static void LogOut()
        {
            APIUser.Logout();
        }
        public static void Quit()
        {
            Thread.Sleep(5);
            Process.GetCurrentProcess().Kill();
        }
        public static void ChangeGameProcessPriority()
        {
            if (GameCtrl.HighPrior == true)
            {
                mainProcess.PriorityClass = ProcessPriorityClass.High;
            }
            else
            {
                mainProcess.PriorityClass = ProcessPriorityClass.Normal;
            }
        }
        public static void ChangeGameCoreAffinity()
        {
            long num = 0L;
            int num2 = Environment.ProcessorCount - 1;
            int num3 = (!GameCtrl.SkitHyperThread) ? 1 : 2;
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                bool flag = num2 <= 0;
                if (flag)
                {
                    break;
                }
                num |= 1L << num2;
                num2 -= num3;
            }
            SetProcessAffinityMask(mainProcess.Handle, new IntPtr(num));
        }
        // World Bs
        public static bool Murderwallhack = false;
        public static bool doorscold = true;
        private static GameObject blindHud;
        private static GameObject flashbangHud;
        private static GameObject deathHud;
        public static void WorldID()
        {
            if (WorldWrappers.GetLocation() != "")
            {
                SendToClip.SetClipboard(" ```SCYTHESTATION``` \n" + WorldWrappers.GetLocation() + "\n ```SCYTHESTATION``` ");
            }
            MelonLogger.WriteSpacer();
            { }; MelonLogger.Msg(ConsoleColor.Green, "SCYTHE >> World ID: " + WorldWrappers.GetLocation() + " copied to clipboard.");
        }

        // World Bs (MURDER)
        public static void blindall()
        {
            if (WorldWrappers.MurderWorld())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "OnLocalPlayerFlashbanged");
                    udonBehaviour.SendCustomNetworkEvent(0, "OnLocalPlayerBlinded");
                }
            }
        }
        public static void unlockminigame()
        {
            foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
            {
                udonBehaviour.SendCustomNetworkEvent(0, "SyncUnlockMinigameComplete");
            }
        }
        public static void findclues()
        {
            if (WorldWrappers.MurderWorld())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncCluesFinished");
                    udonBehaviour.SendCustomNetworkEvent(0, "OnPlayerUnlockedClues");
                    udonBehaviour.SendCustomNetworkEvent(0, "OnCollectClue");
                }
            }
        }
        public static void flickthelights()
        {
            List<GameObject> list = new List<GameObject>
            {
                GameObject.Find("Game Logic").transform.Find("Switch Boxes/Switchbox (0)").gameObject, GameObject.Find("Game Logic").transform.Find("Switch Boxes/Switchbox (1)").gameObject, GameObject.Find("Game Logic").transform.Find("Switch Boxes/Switchbox (2)").gameObject, GameObject.Find("Game Logic").transform.Find("Switch Boxes/Switchbox (3)").gameObject
            };
            foreach (GameObject gameObject in list)
            {
                gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SwitchDown");
            }
        }
        public static void unflickthelights()
        {
            List<GameObject> list = new List<GameObject>
            {
                GameObject.Find("Game Logic").transform.Find("Switch Boxes/Switchbox (0)").gameObject, GameObject.Find("Game Logic").transform.Find("Switch Boxes/Switchbox (1)").gameObject, GameObject.Find("Game Logic").transform.Find("Switch Boxes/Switchbox (2)").gameObject, GameObject.Find("Game Logic").transform.Find("Switch Boxes/Switchbox (3)").gameObject
            };
            foreach (GameObject gameObject in list)
            {
                gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SwitchUp");
            }
        }
        public static void shootweapon()
        {
            GameObject.Find("/Game Logic").transform.Find("Weapons/Revolver").gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncFire");
        }
        public static void realeasesnake()
        {
            GameObject.Find("/Game Logic").transform.Find("Snakes/SnakeDispenser").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "DispenseSnake");
        }
        public static void deathmatch()
        {
            if (WorldWrappers.MurderWorld())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncAssignM");
                }
            }
        }
        public static void closedoors()
        {
            if (WorldWrappers.MurderWorld())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncClose");
                }
            }
        }
        public static void opendoors()
        {
            if (WorldWrappers.MurderWorld())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncOpen");
                }
            }
        }
        public static void lockdoors()
        {
            if (WorldWrappers.MurderWorld())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncLock");
                }
            }
        }
        public static void LemmeCDem()
        {
            if (WorldWrappers.MurderWorld())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "OnLocalPlayerAssignedRole");
                }
            }
        }
        public static void FixMurderAntiKillscreen(bool Toggle)
        {
            if (Game.AntiKS == true)
            {
                if (WorldWrappers.MurderWorld())
                {
                    CacheAnnoyingGameObjects();
                    bool flag = blindHud != null;
                    if (flag)
                    {
                        blindHud.transform.localScale = (Toggle ? new Vector3(0f, 0f, 0f) : new Vector3(1f, 1f, 1f));
                        blindHud.active = false;
                    }
                    bool flag2 = flashbangHud != null;
                    if (flag2)
                    {
                        flashbangHud.transform.localScale = (Toggle ? new Vector3(0f, 0f, 0f) : new Vector3(1f, 1f, 1f));
                        flashbangHud.active = false;
                    }
                    bool flag3 = deathHud != null;
                    if (flag3)
                    {
                        deathHud.transform.localScale = (Toggle ? new Vector3(0f, 0f, 0f) : new Vector3(1f, 1f, 1f));
                        deathHud.active = false;
                    }
                }
            }
            else
            {
                Game.AntiKS.Value = false;
            }
        }
        public static void ShowAllRoles()
        {
            GameObject gameObject = GameObject.Find("Game Logic");
            if (gameObject)
            {
                gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "OnLocalPlayerAssignedRole");
            }
        }
        // World Bs (AMONG US)
        public static void ejecteveryone()
        {
            if (WorldWrappers.Amongunsworld())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncVotedOut");
                }
            }
        }
        public static void ShutTheFuckUp()
        {
            if (WorldWrappers.Amongunsworld())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncCloseVoting");
                }
            }
        }
        public static void ShutTheFuckUpV2()
        {
            if (WorldWrappers.Amongunsworld())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "Btn_SkipVoting");
                }
            }
        }
        public static void GiveSussyAll()
        {
            if (WorldWrappers.Amongunsworld())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncAssignM");
                }
            }
        }
        public static void GiveNonSussyAll()
        {
            if (WorldWrappers.Amongunsworld())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncAssignB");
                }
            }
        }
        public static void sabotageeverything()
        {
            if (WorldWrappers.Amongunsworld())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncDoSabotageComms");
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncDoSabotageReactor");
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncDoSabotageOxygen");
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncDoSabotageLights");
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncDoSabotageDoorsCafeteria");
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncDoSabotageDoorsLower");
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncDoSabotageDoorsStorage");
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncDoSabotageDoorsMedbay");
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncDoSabotageDoorsUpper");
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncDoSabotageDoorsSecurity");
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncDoSabotageDoorsElectrical");
                }
            }
        }
        public static void RepairAll()
        {
            if (WorldWrappers.Amongunsworld())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "CancelAllSabotage");
                }
            }
        }
        public static void EmergencyMeeting()
        {
            GameObject gameObject = GameObject.Find("Game Logic");
            if (gameObject)
            {
                gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncMeeting");
                gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "StartMeeting");
                gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "EmergencyMeeting");
                gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncEmergencyMeeting");
            }
        }
        public static void AllTasksComplete()
        {
            GameObject gameObject = GameObject.Find("Game Logic");
            if (gameObject)
            {
                gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "OnLocalPlayerCompletedTask");
            }
        }
        // Keep Running
        public static void BreakGame()
        {
            if (WorldWrappers.KeepRunning())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "heartbeatFail");
                }
            }
        }
        public static void FixGame()
        {
            if (WorldWrappers.KeepRunning())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "heartbeatResume");
                }
            }
        }
        public static void StartRunGame()
        {
            if (WorldWrappers.KeepRunning())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "StartButtonCallback");
                }
            }
        }
        public static void EndRunGame()
        {
            if (WorldWrappers.KeepRunning())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "AbortGameButtonCallback");
                }
            }
        }
        public static void Darkness()
        {
            if (WorldWrappers.KeepRunning())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "PPCB_BloomDarken");
                }
            }
        }
        public static void Brightness()
        {
            if (WorldWrappers.KeepRunning())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "PPCB_Bloom");
                }
            }
        }
        public static void RespawnAll()
        {
            if (WorldWrappers.KeepRunning())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "respawnSelf");
                }
            }
        }
        public static void DoSomethingWithnewtarget()
        {
            if (WorldWrappers.KeepRunning())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "UNE_FetchNewTarget");
                }
            }
        }
        // Main Game World Bs
        public static void CacheAnnoyingGameObjects()
        {
            blindHud = GameObject.Find("Game Logic/Player HUD/Blind HUD Anim");
            flashbangHud = GameObject.Find("Game Logic/Player HUD/Flashbang HUD Anim");
            deathHud = GameObject.Find("Game Logic/Player HUD/Death HUD Anim");
        }
        public static void KillAll()
        {
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                if (gameObject.name.Contains("Game Logic"))
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "KillLocalPlayer");
                }
            }
        }
        public static void FS()
        {
            foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
            {
                udonBehaviour.SendCustomNetworkEvent(0, "Btn_Start");
            }
        }
        public static void FE()
        {
            foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
            {
                udonBehaviour.SendCustomNetworkEvent(0, "SyncAbort");
            }
        }
        public static void AssignSelfMurder()
        {
            string value = VRCPlayer.field_Internal_Static_VRCPlayer_0.gameObject.GetComponent<VRCPlayer>()._player.ToString();
            for (int i = 0; i < 24; i++)
            {
                string text = "Player Node (" + i.ToString() + ")";
                if (GameObject.Find("Game Logic/Game Canvas/Game In Progress/Player List/Player List Group/Player Entry (" + i.ToString() + ")/Player Name Text").GetComponent<Text>().text.Equals(value))
                {
                    GameObject.Find(text).GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncAssignM");
                }
            }
        }
        public static void AssignSelfBystander()
        {
            string value = VRCPlayer.field_Internal_Static_VRCPlayer_0.gameObject.GetComponent<VRCPlayer>()._player.ToString();
            for (int i = 0; i < 24; i++)
            {
                string text = "Player Node (" + i.ToString() + ")";
                if (GameObject.Find("Game Logic/Game Canvas/Game In Progress/Player List/Player List Group/Player Entry (" + i.ToString() + ")/Player Name Text").GetComponent<Text>().text.Equals(value))
                {
                    MelonLogger.Msg(text);
                    GameObject.Find(text).GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncAssignB");
                }
            }
        }
        public static void Win()
        {
            GameObject gameObject = GameObject.Find("Game Logic");
            if (gameObject)
            {
                gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncVictoryB");
            }
        }
        public static void OtherWin()
        {
            GameObject gameObject = GameObject.Find("Game Logic");
            if (gameObject)
            {
                gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncVictoryM");
            }
        }
    }
}
