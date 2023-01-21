using ApolloCore.API.QM;
using ScytheStation.Menus;
using MelonLoader;
using System;

namespace ScytheStation.Menus
{
    internal class GameWorlds
    {
        public static void Init(QMTabMenu menu)
        {
            // GAMEWORLD MENU //
            var AnotherMenu6 = new QMNestedButton(menu, 1, 1, "GW Hacks", "Skeet on top!! number 1 cheat!!!!", "GameWorld Hacks");
            var GameMenu = new QMNestedButton(AnotherMenu6, 1, 0, "Feast ur eyes", ":Scream emoji:", "Feast ur eyes");
            var GameMenu1 = new QMNestedButton(GameMenu, 1, 0, "Murder", "Skeet on top!! number 1 cheat!!!!", "Murder");
            var GameMenu2 = new QMNestedButton(GameMenu, 2, 0, "Sussy", "Skeet on top!! number 1 cheat!!!!", "Sussy");
            var GameMenu3 = new QMNestedButton(GameMenu, 3, 0, "Etc", "Skeet on top!! number 1 cheat!!!!", "Etc");

            // -0--------------------------------8-

            // Murder (Might Update later)
            new QMSingleButton(GameMenu1, 1, 0, "Murder Wins", delegate { Functions.GameControls.MurderWin(); }, "Hackrt!");
            new QMSingleButton(GameMenu1, 2, 0, "The blinder", delegate { Functions.GameControls.blindall(); }, "wtf!");
            new QMSingleButton(GameMenu1, 3, 0, "Bystander Gets a W", delegate { Functions.GameControls.BystanderWin(); }, "how u gon hak! then lose.. wtf!! - Plasma");
            new QMSingleButton(GameMenu1, 4, 0, "Start a Minigame", delegate { Functions.GameControls.unlockminigame(); }, "no way bruh");
            new QMSingleButton(GameMenu1, 1, 1, "Deathmatch", delegate { Functions.GameControls.deathmatch(); }, "well someone browk da gawm *snort*");
            new QMSingleButton(GameMenu1, 2, 1, "Scyts pet snake", delegate { Functions.GameControls.realeasesnake(); }, "Go get em boy!");
            new QMSingleButton(GameMenu1, 3, 1, "Know it all", delegate { Functions.GameControls.findclues(); }, "I found pics of yo ma in bed");
            new QMSingleButton(GameMenu1, 4, 1, "Go to bed", delegate { Functions.GameControls.flickthelights(); }, "Lights out");
            new QMSingleButton(GameMenu1, 1, 2, "Troll the detective", delegate { Functions.GameControls.shootweapon(); }, "He must be confused asf rn");
            new QMSingleButton(GameMenu1, 2, 2, "Close doors", delegate { Functions.GameControls.closedoors(); }, "Idk what this does");

            var GameMenuExtras = new QMNestedButton(GameMenu1, 1, 3f, "->", "Next Page", "2");
            new QMToggleButton(GameMenuExtras, 1, 0, "Gun Spammer", delegate
            { Functions.GameControls.SpamGun(); }, delegate
            { Functions.GameControls.SpamGun(); }, "AAAAAAAAAAAAAAAA");
            new QMToggleButton(GameMenuExtras, 2, 0, "Hard of seeing Spammer", delegate
            { Functions.GameControls.SpamBlind(); }, delegate
            { Functions.GameControls.SpamBlind(); }, "AAAAAAAAAAAAAAAA V2");

            // Among Us (Might Update later)
            new QMSingleButton(GameMenu2, 1, 0, "Eject EVERYONE", delegate { Functions.GameControls.ejecteveryone(); }, "FUNNY!!!");
            new QMSingleButton(GameMenu2, 2, 0, "Become SUS", delegate { Functions.GameControls.GiveSussy(); }, "Sex time");
            new QMSingleButton(GameMenu2, 3, 0, "Shut The Fuck Up Everyone", delegate { Functions.GameControls.ShutTheFuckUp(); }, "Oh");
            new QMSingleButton(GameMenu2, 4, 0, "Shut The Fuck Up Everyone V2", delegate { Functions.GameControls.ShutTheFuckUpV2(); }, "ok");
            new QMSingleButton(GameMenu2, 1, 1, "Fix the shit", delegate { Functions.GameControls.RepairAll(); }, "yeah");
            new QMSingleButton(GameMenu2, 2, 1, "UnFix the shit", delegate { Functions.GameControls.sabotageeverything(); }, "K");

            // Etc (Might Update later)
            new QMSingleButton(GameMenu3, 1, 0, "Kill Everyone", delegate { Functions.GameControls.KillAll(); }, "Scythe after the | after the v1.5 ScytheStation Update");
            new QMSingleButton(GameMenu3, 2, 0, "Force Start", delegate { Functions.GameControls.FS(); }, "Also Wow!");
            new QMSingleButton(GameMenu3, 3, 0, "Force End", delegate { Functions.GameControls.FE(); }, "Wow!");
            // -0--------------------------------8-
            // GAMEWORLD MENU //
            MelonLogger.Msg(ConsoleColor.Green, "[MENUS] GameWorldManager Loaded", MenuManager.C++);
        }
    }
}
