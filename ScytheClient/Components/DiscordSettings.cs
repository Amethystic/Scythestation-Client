﻿using VRC;
using ScytheStation.Core.Discord;
using MelonLoader;
using System;
using UnityEngine;
using static ScytheStation.Components.Settings;

namespace ScytheStation.Components
{
    internal class DiscordSettings
    {
        internal static DiscordRpc.EventHandlers eventHandlers;
        public static void Discord()
        {
            DiscordRpc.Initialize($"{Manager.appid}", ref eventHandlers, true, "");
            MelonLogger.Msg(ConsoleColor.Blue, "[DISCORD SUPPORT] Initialized RPC");
        }
        public static void Discord2()
        {
            DiscordRpc.Shutdown();
        }
    }
    internal class Settings2
    {
        public static void BindingSupport()
        {
            // Bindings
            if (MainSettings.keybinds)
            {
                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    MainSettings.flytoggle.Value = !MainSettings.flytoggle;
                }
                if (Input.GetKeyDown(KeyCode.G))
                {
                    MainSettings.ESPCapsules.Value = !MainSettings.ESPCapsules;
                    MainSettings.IESP.Value = !MainSettings.IESP;
                }
                if (Input.GetKeyDown(KeyCode.H))
                {
                    MainSettings.SpeedRun.Value = !MainSettings.SpeedRun;
                }
            }
        }
        public static void LoadSettings()
        {
            Load();
            API.Utils.Notificator.WriteHudMessage("[GC] Config Loaded");
        }
        public static void SaveSettings()
        {
            Save();
            API.Utils.Notificator.WriteHudMessage("[GC] Config Saved");
        }
    }
    internal class MainSettings
    {
        public static SaveProperty<bool> ClickTP = new("ClickTP", false);
        public static SaveProperty<bool> flytoggle = new("flytoggle", false);
        public static SaveProperty<bool> ESPCapsules = new("ESPCapsules", false);
        public static SaveProperty<bool> IESP = new("IESP", false);
        public static SaveProperty<bool> SpeedRun = new("SpeedRun", false);
        public static SaveProperty<bool> Idek = new("Idek", false);
        public static SaveProperty<bool> LogEvents = new("LogEvents", false);
        public static SaveProperty<bool> keybinds = new("keybinds", false);
        public static SaveProperty<bool> Nameplates = new("Nameplates", false);
        public static SaveProperty<bool> PlayerAppearenceLog = new("PlayerAppearenceLog", false);
        public static SaveProperty<bool> AutoClearCache = new("AutoClearCache", false);
    }
    internal class Game
    {
        public static SaveProperty<bool> Die = new("Die", false);
        public static SaveProperty<bool> AntiKS = new("AntiKS", false);
    }
    internal class GameCtrl
    {
        public static SaveProperty<bool> HighPrior = new("HighPrior", false);
        public static SaveProperty<bool> SkitHyperThread = new("SkitHyperThread", false);
    }
    internal class UserStruct
    {
        public string userId { get; set; }
        public Player player { get; set; }
    }
    internal class MenuCustomizationSettings
    {
        public static SaveProperty<bool> HideApiButtonBG = new("HideApiButtonBG", false);
    }
}
