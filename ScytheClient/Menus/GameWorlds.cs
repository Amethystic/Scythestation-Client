using ApolloCore.API.QM;
using MelonLoader;
using System;
using Obfuscation = System.Reflection.ObfuscationAttribute;

namespace ScytheStation.Menus
{
    internal class GameWorlds
    {
        [Obfuscation(Exclude = false)]
        public static void Init(QMTabMenu menu)
        {
            // GAMEWORLD MENU //
            var AnotherMenu6 = new QMNestedButton(menu, 1, 1, "GW Hacks", "Skeet on top!! number 1 cheat!!!!", "GameWorld Hacks");
            var GameMenu = new QMNestedButton(AnotherMenu6, 1, 0, "Feast ur eyes", ":Scream emoji:", "Feast ur eyes");
            var GameMenu1 = new QMNestedButton(GameMenu, 1, 0, "Murder 4", "Skeet on top!! number 1 cheat!!!!", "Murder");
            var GameMenu2 = new QMNestedButton(GameMenu, 2, 0, "Among Us", "Skeet on top!! number 1 cheat!!!!", "Sussy");
            var GameMenu4 = new QMNestedButton(GameMenu, 3, 0, "Keep Running", "Skeet on top!! number 1 cheat!!!!", "Run away from the NPCS");
            var GameMenu3 = new QMNestedButton(GameMenu, 4, 0, "Etc", "Skeet on top!! number 1 cheat!!!!", "Etc");

            // -0--------------------------------8-

            // Murder (Might Update later)
            new QMSingleButton(GameMenu1, 1, 0, "The blinder", delegate { Functions.GameControls.blindall(); }, "wtf!");
            new QMSingleButton(GameMenu1, 2, 0, "Start a Minigame", delegate { Functions.GameControls.unlockminigame(); }, "no way bruh");
            new QMSingleButton(GameMenu1, 3, 0, "Deathmatch", delegate { Functions.GameControls.deathmatch(); }, "well someone browk da gawm *snort*");
            new QMSingleButton(GameMenu1, 4, 0, "Scyts pet snake", delegate { Functions.GameControls.realeasesnake(); }, "Go get em boy!");
            new QMSingleButton(GameMenu1, 1, 1, "Know it all", delegate { Functions.GameControls.findclues(); }, "I found pics of yo ma in bed");
            new QMSingleButton(GameMenu1, 2, 1, "Go to bed", delegate { Functions.GameControls.flickthelights(); }, "Lights out");
            new QMSingleButton(GameMenu1, 3, 1, "Troll the detective", delegate { Functions.GameControls.shootweapon(); }, "He must be confused asf rn");
            new QMSingleButton(GameMenu1, 4, 1, "Close doors", delegate { Functions.GameControls.closedoors(); }, "Idk what this does");
            new QMSingleButton(GameMenu1, 1, 2, "Give new roles", delegate { Functions.GameControls.LemmeCDem(); }, "Shos things idk");
            new QMSingleButton(GameMenu1, 2, 2, "Wake up", delegate { Functions.GameControls.unflickthelights(); }, "Lights on");

            var GameMenuExtras = new QMNestedButton(GameMenu1, 1, 3f, "->", "Next Page", "2");
            new QMToggleButton(GameMenuExtras, 1, 0, "Anti Killsay", delegate
            { Components.Game.AntiKS.Value = true; }, delegate
            { Components.Game.AntiKS.Value = false; }, "Get that shit out of my face!");
            new QMSingleButton(GameMenuExtras, 2, 0, "Open Doors", delegate { Functions.GameControls.opendoors(); }, "Haunted ass doors");
            new QMSingleButton(GameMenuExtras, 3, 0, "Lock Doors", delegate { Functions.GameControls.lockdoors(); }, "Haunted ass doors 2");

            // Among Us (Might Update later)
            new QMSingleButton(GameMenu2, 1, 0, "Eject EVERYONE", delegate { Functions.GameControls.ejecteveryone(); }, "FUNNY!!!");
            new QMSingleButton(GameMenu2, 2, 0, "Everyone Becomes SUS", delegate { Functions.GameControls.GiveSussyAll(); }, "Sex time");
            new QMSingleButton(GameMenu2, 3, 0, "Everyone Becomes UNSUS", delegate { Functions.GameControls.GiveNonSussyAll(); }, "Not Sex time");
            new QMSingleButton(GameMenu2, 4, 0, "Shut The Fuck Up Everyone", delegate { Functions.GameControls.ShutTheFuckUp(); }, "Oh");
            new QMSingleButton(GameMenu2, 1, 1, "Shut The Fuck Up Everyone V2", delegate { Functions.GameControls.ShutTheFuckUpV2(); }, "ok");
            new QMSingleButton(GameMenu2, 2, 1, "Fix the shit", delegate { Functions.GameControls.RepairAll(); }, "yeah");
            new QMSingleButton(GameMenu2, 3, 1, "UnFix the shit", delegate { Functions.GameControls.sabotageeverything(); }, "K");

            var GameMenuExtras2 = new QMNestedButton(GameMenu2, 1, 3f, "->", "Next Page", "2");
            new QMSingleButton(GameMenuExtras2, 1, 0, "Immediantly Do Tasks", delegate { Functions.GameControls.AllTasksComplete(); }, "fuck those things");
            new QMSingleButton(GameMenuExtras2, 2, 0, "Emergency", delegate { Functions.GameControls.EmergencyMeeting(); }, "uh oh");

            // Run Away (Might Update later)
            new QMSingleButton(GameMenu4, 1, 0, "Break Game", delegate { Functions.GameControls.BreakGame(); }, "FUNNY!!!");
            new QMSingleButton(GameMenu4, 2, 0, "Fix Game", delegate { Functions.GameControls.FixGame(); }, "UNFUNNY!!!");
            new QMSingleButton(GameMenu4, 3, 0, "Tickle Newtarget", delegate { Functions.GameControls.DoSomethingWithnewtarget(); }, "hehe");
            new QMSingleButton(GameMenu4, 4, 0, "Bright", delegate { Functions.GameControls.Brightness(); }, "my eyes burn");
            new QMSingleButton(GameMenu4, 1, 1, "Dark", delegate { Functions.GameControls.Darkness(); }, "my eyes not burn");
            new QMSingleButton(GameMenu4, 2, 1, "Respawn Everyone", delegate { Functions.GameControls.RespawnAll(); }, "what the fuck");
            new QMSingleButton(GameMenu4, 3, 1, "Start Game", delegate { Functions.GameControls.StartRunGame(); }, "what the fuck 2");
            new QMSingleButton(GameMenu4, 4, 1, "End Game", delegate { Functions.GameControls.EndRunGame(); }, "what the fuck 3");

            // Etc (Might Update later)
            new QMSingleButton(GameMenu3, 1, 0, "Kill Everyone", delegate { Functions.GameControls.KillAll(); }, "Scythe after the | after the v1.5 ScytheStation Update");
            new QMSingleButton(GameMenu3, 2, 0, "Force Start", delegate { Functions.GameControls.FS(); }, "Also Wow!");
            new QMSingleButton(GameMenu3, 3, 0, "Force End", delegate { Functions.GameControls.FE(); }, "Wow!");
            new QMSingleButton(GameMenu3, 4, 0, "Expose", delegate { Functions.GameControls.ShowAllRoles(); }, "Cool");
            new QMSingleButton(GameMenu3, 1, 1, "You r Bystanding", delegate { Functions.GameControls.AssignSelfBystander(); }, "Wow AWESOME!");
            new QMSingleButton(GameMenu3, 2, 1, "You r Killa", delegate { Functions.GameControls.AssignSelfMurder(); }, "WoW COOL!");
            new QMSingleButton(GameMenu3, 3, 1, "Murderer/Sussy Bystand Win", delegate { Functions.GameControls.Win(); }, "oh");
            new QMSingleButton(GameMenu3, 4, 1, "Murderer/Sussy Impo win", delegate { Functions.GameControls.OtherWin(); }, "oh");
            // -0--------------------------------8-
            // GAMEWORLD MENU //
            MelonLogger.Msg(ConsoleColor.Green, "[MENUS] GameWorldManager Loaded", MenuManager.C++);
        }
    }
}
