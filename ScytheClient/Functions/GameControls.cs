using System;
using System.Threading;
using System.Diagnostics;
using MelonLoader;
using UnityEngine;
using VRC.Core;
using VRC;
using ScytheStation.Components.Extensions;
using ScytheStation.Core.Wrappers;
using ScytheStation.Components;
using System.Collections.Generic;
using VRC.Udon;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using VRC.SDKBase;
using System.Collections;
using VRC.Udon.Common.Interfaces;

namespace ScytheStation.Functions
{
    internal static class GameControls
    {
        public static Process mainProcess = null;
        public static bool Murderwallhack = false;
        public static bool doorscold = true;
        public static bool Murder4ExplodeLoop = false;
        //public static bool AmongUsVoteOutLoop = false;
        //public static bool KillLoop = false;
        public static bool KillallLoop = false;
        public static GameObject blindHud;
        public static GameObject flashbangHud;
        public static GameObject deathHud;
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetProcessAffinityMask(IntPtr hProcess, IntPtr dwProcessAffinityMask);
        public static void OpenSite()
        {
            Process.Start($"{Main.Site}");
            MelonLogger.Msg(ConsoleColor.Green, $"[GC] Directing to {Main.Site}");
        }
        public static void ClearCache()
        {
            Caching.CleanCache();
            ApiCache.ClearCache();
            ApiCache.ClearResponseCache();

            if (MainSettings.AutoClearCache)
            {
                try
                {
                    Caching.CleanCache();
                    ApiCache.ClearCache();
                    ApiCache.ClearResponseCache();
                    new WaitForSeconds(1000);
                }
                catch (Exception ex)
                {
                    MelonLogger.Error($"Failed to clear\n{ex}");
                }
            }
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
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "OnLocalPlayerFlashbanged");
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "OnLocalPlayerBlinded");
            }
        }
        public static void unlockminigame()
        {
            if (WorldWrappers.MurderWorld())
            {
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncUnlockMinigameComplete");
            }
        }
        public static void findclues()
        {
            if (WorldWrappers.MurderWorld())
            {
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncCluesFinished");
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "OnPlayerUnlockedClues");
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "OnCollectClue");
            }
        }
        public static void flickthelights()
        {
            List<GameObject> list = new List<GameObject>
            {
                GameObject.Find("Game Logic").transform.Find("Switch Boxes/Switchbox (0)").gameObject, GameObject.Find("Game Logic").transform.Find("Switch Boxes/Switchbox (1)").gameObject, GameObject.Find("Game Logic").transform.Find("Switch Boxes/Switchbox (2)").gameObject, GameObject.Find("Game Logic").transform.Find("Switch Boxes/Switchbox (3)").gameObject
            };
            if (WorldWrappers.MurderWorld())
            {
                foreach (GameObject gameObject in list)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SwitchDown");
                }
            }
        }
        public static void unflickthelights()
        {
            List<GameObject> list = new List<GameObject>
            {
                GameObject.Find("Game Logic").gameObject, GameObject.Find("Game Logic").transform.Find("Switch Boxes/Switchbox (1)").gameObject, GameObject.Find("Game Logic").transform.Find("Switch Boxes/Switchbox (2)").gameObject, GameObject.Find("Game Logic").transform.Find("Switch Boxes/Switchbox (3)").gameObject
            };
            if (WorldWrappers.MurderWorld())
            {
                foreach (GameObject gameObject in list)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SwitchUp");

                }
            }
        }
        public static void shootweapon()
        {
            if (WorldWrappers.MurderWorld())
            {
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncFire");
            }
        }
        public static void realeasesnake()
        {
            if (WorldWrappers.MurderWorld())
            {
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "DispenseSnake");
            }
        }
        public static void deathmatch()
        {
            if (WorldWrappers.MurderWorld())
            {
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncAssignM");
            }
        }
        public static void closedoors()
        {
            if (WorldWrappers.MurderWorld())
            {
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncClose");
            }
        }
        public static void opendoors()
        {
            if (WorldWrappers.MurderWorld())
            {
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncOpen");
            }
        }
        public static void lockdoors()
        {
            if (WorldWrappers.MurderWorld())
            {
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncLock");
            }
        }
        public static void LemmeCDem()
        {
            if (WorldWrappers.MurderWorld())
            {
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "OnLocalPlayerAssignedRole");
            }
        }
        public static void FixMurderAntiKillscreen()
        {
            if (Game.AntiKS)
            {
                if (WorldWrappers.MurderWorld())
                {
                    CacheAnnoyingGameObjects();
                    bool flag = blindHud != null;
                    if (flag)
                    {
                        blindHud.active = false;
                    }
                    bool flag2 = flashbangHud != null;
                    if (flag2)
                    {
                        flashbangHud.active = false;
                    }
                    bool flag3 = deathHud != null;
                    if (flag3)
                    {
                        deathHud.active = false;
                    }
                }
                if (WorldWrappers.Amongunsworld())
                {
                    CacheAnnoyingGameObjects();
                    bool flag3 = deathHud != null;
                    if (flag3)
                    {
                        deathHud.active = false;
                    }
                }
            }
        }
        // World Bs (AMONG US)
        public static void ejecteveryone()
        {
            if (WorldWrappers.Amongunsworld())
            {
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncVotedOut");
            }
        }
        public static void ShowAllRoles()
        {
            if (WorldWrappers.Amongunsworld())
            {
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "OnLocalPlayerAssignedRole");
            }
        }
        public static void ShutTheFuckUp()
        {
            if (WorldWrappers.Amongunsworld())
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncCloseVoting");
        }
        public static void ShutTheFuckUpV2()
        {
            if (WorldWrappers.Amongunsworld())
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "Btn_SkipVoting");
        }
        public static void GiveSussyAll()
        {
            if (WorldWrappers.Amongunsworld())
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncAssignM");
        }
        public static void GiveNonSussyAll()
        {
            if (WorldWrappers.Amongunsworld())
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncAssignB");
        }
        public static void sabotageeverything()
        {
            if (WorldWrappers.Amongunsworld())
            {
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncDoSabotageComms");
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncDoSabotageReactor");
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncDoSabotageOxygen");
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncDoSabotageLights");
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncDoSabotageDoorsCafeteria");
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncDoSabotageDoorsLower");
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncDoSabotageDoorsStorage");
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncDoSabotageDoorsMedbay");
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncDoSabotageDoorsUpper");
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncDoSabotageDoorsSecurity");
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncDoSabotageDoorsElectrical");
            }
        }
        public static void RepairAll()
        {
            if (WorldWrappers.Amongunsworld())
            {
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "CancelAllSabotage");
            }
        }
        public static void EmergencyMeeting()
        {
            if (WorldWrappers.Amongunsworld())
            {
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncMeeting");
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "StartMeeting");
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "EmergencyMeeting");
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncEmergencyMeeting");
            }
        }
        public static void AllTasksComplete()
        {
            if (WorldWrappers.Amongunsworld())
            {
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "OnLocalPlayerCompletedTask");
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
            if (WorldWrappers.MurderWorld())
            {
                blindHud = GameObject.Find("Game Logic/Player HUD/Blind HUD Anim");
                flashbangHud = GameObject.Find("Game Logic/Player HUD/Flashbang HUD Anim");
                deathHud = GameObject.Find("Game Logic/Player HUD/Death HUD Anim");
            }
            if (WorldWrappers.Amongunsworld())
            {
                deathHud = GameObject.Find("Game Logic/Player HUD/Death HUD Anim");
            }
        }
        public static void KillAll()
        {
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "KillLocalPlayer");
        }
        public static void FS()
        {
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "Btn_Start");
        }
        public static void FE()
        {
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncAbort");
        }
        public static void AssignSelfMurder()
        {
            string value = VRCPlayer.field_Internal_Static_VRCPlayer_0.gameObject.GetComponent<VRCPlayer>()._player.ToString();
            for (int i = 0; i < 24; i++)
            {
                string text = "Player Node (" + i.ToString() + ")";
                if (GameObject.Find("Game Logic/Game Canvas/Game In Progress/Player List/Player List Group/Player Entry (" + i.ToString() + ")/Player Name Text").GetComponent<Text>().text.Equals(value))
                {
                    MelonLogger.Msg($"{text}");
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
                    MelonLogger.Msg($"{text}");
                    GameObject.Find(text).GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncAssignB");
                }
            }
        }
        public static void Win()
        {
            GameObject gameObject = GameObject.Find("Game Logic");
            if (gameObject.name.Contains("Game Logic"))
            {
                gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncVictoryB");
            }
        }
        public static void OtherWin()
        {
            GameObject gameObject = GameObject.Find("Game Logic");
            if (gameObject.name.Contains("Game Logic"))
            {
                gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncVictoryM");
            }
        }
        // Selective
        public static void KillAPlayer()
        {
            TargeteEvent("KillLocalPlayer", IUserExtension.GetCurrentlySelectedPlayer());
        }
        public static void VotePlayerOut()
        {
            TargeteEvent("SyncVotedOut", IUserExtension.GetCurrentlySelectedPlayer());
        }
        public static void Murder4ExplodeTarget()
        {
            var gameobject = GameObject.Find("Frag (0)");
            Networking.LocalPlayer.TakeOwnership(gameobject);
            gameobject.transform.position = IUserExtension.GetCurrentlySelectedPlayer().transform.position;
            gameobject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "Explode");
        }
        public static IEnumerator Murder4LoopExplodeTarget()
        {
            if (WorldWrappers.MurderWorld())
            {
                var gameobject = GameObject.Find("Frag (0)");
                while (Murder4ExplodeLoop)
                {
                    Networking.LocalPlayer.TakeOwnership(gameobject);
                    gameobject.transform.position = IUserExtension.GetCurrentlySelectedPlayer().transform.position;
                    gameobject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "Explode");
                    yield return new WaitForSeconds(0.1f);
                }
                yield break;
            }
        }
        //public static IEnumerator AmongUsVoteOutAllLoopTarget()
        //{
        //    if (WorldWrappers.Amongunsworld())
        //    {
        //        var gameobject = GameObject.Find("Game Logic");
        //        while (AmongUsVoteOutLoop)
        //        {
        //            if (gameobject.name.Contains("Game Logic"))
        //            {
        //                Networking.LocalPlayer.TakeOwnership(gameobject); gameobject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncVotedOut");
        //                yield return new WaitForSeconds(0.1f);
        //            }
        //        }
        //        yield break;
        //    }
        //}
        public static IEnumerator Killallloop()
        {
            var gameobject = GameObject.Find("Game Logic");
            while (KillallLoop)
            {
                if (gameobject.name.Contains("Game Logic"))
                {
                    Networking.LocalPlayer.TakeOwnership(gameobject); gameobject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "KillLocalPlayer");
                    yield return new WaitForSeconds(0.1f);
                }
            }
            yield break;
        }
        public static void Murder4TargetFlash()
        {
                TargeteEvent("SyncFlashbang", IUserExtension.GetCurrentlySelectedPlayer());
        }
        public static void TargetAssignB()
        {
                TargeteEvent("SyncAssignB", IUserExtension.GetCurrentlySelectedPlayer());
        }

        public static void TargetAssignM()
        {
                TargeteEvent("SyncAssignM", IUserExtension.GetCurrentlySelectedPlayer());
        }

        public static void TargetAssignD()
        {
                TargeteEvent("SyncAssignD", IUserExtension.GetCurrentlySelectedPlayer());
        }

        public static void TargetWinnerM()
        {
                TargeteEvent("SyncVictoryM", IUserExtension.GetCurrentlySelectedPlayer());
        }
        public static void TargetWinnerB()
        {
                TargeteEvent("SyncVictoryB", IUserExtension.GetCurrentlySelectedPlayer());
        }

        public static void TargetFinishClues()
        {
                TargeteEvent("SyncCluesFinished", IUserExtension.GetCurrentlySelectedPlayer());
        }
        public static void TargeteEvent(string udonevent, Player player)
        {
            GameObject gameObject = GameObject.Find("Player Nodes");
            foreach (Transform componentsInChild in gameObject.GetComponentsInChildren<Transform>())
            {
                if (componentsInChild.name != gameObject.name)
                    componentsInChild.gameObject.Udonsend(udonevent, player);
            }
        }
        public static void SetEventOwner(this GameObject gameObject, Player player)
        {
            if (!(gameObject.GrabOwner() != player))
                return;
            Networking.SetOwner(player.field_Private_VRCPlayerApi_0, gameObject);
        }
        public static void Udonsend(this GameObject gameObject, string udonEvent, Player player = null, bool componetcheck = false)
        {
            UdonBehaviour component = gameObject.GetComponent<UdonBehaviour>();
            if (!(player != null))
            {
                if (componetcheck)
                    return;
                if (player == VRCPlayer.field_Internal_Static_VRCPlayer_0._player)
                    component.SendCustomEvent(udonEvent);
                else
                    component.SendCustomNetworkEvent(0, udonEvent);
            }
            else
            {
                gameObject.SetEventOwner(player);
                component.SendCustomNetworkEvent(NetworkEventTarget.Owner, udonEvent);
            }
        }
        public static Player GrabOwner(this GameObject gameObject)
        {
            foreach (Player player in PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0)
            {
                if (player.field_Private_VRCPlayerApi_0.IsOwner(gameObject))
                    return player;
            }
            return null;
        }
    }
}
