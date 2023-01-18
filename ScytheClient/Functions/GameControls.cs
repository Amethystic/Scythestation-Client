using System;
using System.Threading;
using System.Diagnostics;
using MelonLoader;
using UnityEngine;
using VRC.Core;
using ScytheStation.Components.Extensions;
using ScytheStation.Core.Wrappers;
using ScytheStation.Components;
using VRC.Udon;
using System.Collections.Generic;

namespace ScytheStation.Functions
{
    internal class GameControls
    {
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
            Thread.Sleep(5);
            Process.GetCurrentProcess().Kill();
        }

        // World Bs
        public static bool Murderwallhack = false;
        public static bool doorscold = true;
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
        public static void BystanderWin()
        {
            foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
            {
                udonBehaviour.SendCustomNetworkEvent(0, "SyncVictoryB");
            }
        }
        public static void MurderWin()
        {
            foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
            {
                udonBehaviour.SendCustomNetworkEvent(0, "SyncVictoryM");
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
        public static void SpamGun()
        {
            if (WorldWrappers.MurderWorld())
            {
                Game.SpamGun = true;
                // Peebo29 [From https://www.tutorialsteacher.com/csharp/csharp-for-loop]
                if (Game.SpamGun == true)
                {
                    int Loop = 0;
                    foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                    {
                        if (Loop < 100)
                        {
                            GameObject.Find("/Game Logic").transform.Find("Weapons/Revolver").gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncFire");
                            Loop++;
                        } else { break; }
                    }
                } else if (Game.SpamGun == false) { Game.SpamGun = false; }
            }
        }
        public static void SpamBlind()
        {
            if (WorldWrappers.MurderWorld())
            {
                Game.SpamBlind = true;
                // By Peebo29 [From https://www.tutorialsteacher.com/csharp/csharp-for-loop]
                if (Game.SpamBlind == true)
                {
                    int Loop = 0;
                    foreach (UdonBehaviour udonBehaviour in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                    {
                        if (Loop < 100)
                        {
                            udonBehaviour.SendCustomNetworkEvent(0, "OnLocalPlayerFlashbanged");
                            udonBehaviour.SendCustomNetworkEvent(0, "OnLocalPlayerBlinded");
                            Loop++;
                        } else { break; }
                    }
                } else if (Game.SpamBlind == false) { Game.SpamBlind = false; }
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
    }
}
