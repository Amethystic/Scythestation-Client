using System;
using System.Threading;
using System.Diagnostics;
using MelonLoader;
using UnityEngine;
using VRC.Core;
using ScytheStation.Components.Extensions;
using ScytheStation.Core.Wrappers;
using ScytheStation.Components;
using ScytheStation.Core.FileManager;
using VRC.Udon;
using System.Collections;
using System.Collections.Generic;

namespace ScytheStation.Functions
{
    internal class GameControls
    {
        public static void ReInject()
        {
            MelonLogger.Msg(ConsoleColor.Red, "[GC] [EACMELON] ReInjecting...");
            Process.Start($"{Directories.Folder}\\Dependencies\\EacMelon.exe");
            MelonPreferences.Save();
            Settings.DiscordRPCOff();
            Process.Start("start_protected_game.exe");
            MelonLogger.Msg(ConsoleColor.Green, "[GC] [GAME] ReInjection Complete! Now Exiting the game");
            Thread.Sleep(5);
            Process.GetCurrentProcess().Kill();
        }
        public static void LagGame()
        {
            Application.targetFrameRate = 1;
        }
        public static void Capto60()
        {
            Application.targetFrameRate = 60;
        }
        public static void UnLagGame()
        {
            Application.targetFrameRate = 900;
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
            MelonPreferences.Save();
            Settings.DiscordRPCOff();
            Thread.Sleep(5);
            Process.GetCurrentProcess().Kill();
        }

        // World Bs

        public static void WorldID()
        {
            if (WorldWrappers.GetLocation() != "")
            {
                SendToClip.SetClipboard(" ```SCYTHESTATION``` \n" + WorldWrappers.GetLocation() + "\n ```SCYTHESTATION``` ");
            }
            MelonLogger.WriteSpacer();
            {
            };
            MelonLogger.Msg(ConsoleColor.Green, "SCYTHE >> World ID: " + WorldWrappers.GetLocation() + " copied to clipboard.");
        }

        // World Bs (MURDER)
        private static void Sendmurdergmj(string udonevent)
        {
            GameObject.Find("/Game Logic").GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, udonevent);
        }
        public static void forcestartMurd()
        {
            if (WorldWrappers.MurderWorld())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncStartGame");
                }
            }
        }
        public static void forceendMurd()
        {
            if (WorldWrappers.MurderWorld())
            {
                GameControls.Sendmurdergmj("SyncAbort");
            }
        }
        public static void BystanderW()
        {
            if (WorldWrappers.MurderWorld())
            {
                GameControls.Sendmurdergmj("SyncVictoryB");
            }
        }
        public static void MurderWin()
        {
            if (WorldWrappers.MurderWorld())
            {
                GameControls.Sendmurdergmj("SyncVictoryM");
            }
        }
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
        public static void closelights()
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
        public static void closewtf()
        {
            if (WorldWrappers.MurderWorld())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncClose");
                }
            }
        }

        // World Bs (AMONG US)
        public static void forcestartAmong()
        {
            if (WorldWrappers.Amongunsworld())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "Btn_Start");
                }
            }
        }
        public static void forceendAmong()
        {
            if (WorldWrappers.Amongunsworld())
            {
                GameControls.Sendmurdergmj("SyncAbort");
            }
        }
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
        public static void GiveSussy()
        {
            if (WorldWrappers.Amongunsworld())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncAssignM");
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
                }
            }
        }
        public static void RepairAll()
        {
            if (WorldWrappers.Amongunsworld())
            {
                foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                {
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncRepairComms");
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncRepairReactor");
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncRepairOxygen");
                    udonBehaviour.SendCustomNetworkEvent(0, "SyncRepairLights");
                }
            }
        }
        // Main Game World Bs
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
        public static bool Murderwallhack = false;
        public static bool doorscold = true;
    }
}
