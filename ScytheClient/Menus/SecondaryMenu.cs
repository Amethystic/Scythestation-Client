using ApolloCore.API.QM;
using MelonLoader;
using System;

namespace ScytheStation.Menus
{
    internal class SecondaryMenu
    {
        public static void Init(QMTabMenu menu)
        {
            // IRONIC MENU //
            var AnotherMenu1 = new QMNestedButton(menu, 1, 0, "Ironic", "For ironic and giggles n shit buttons", "Ironic");
            new QMSingleButton(AnotherMenu1, 1, 0, "<color=#ed2311><b>Chris</b></color><color=#56ed11><b>tmas!!!!!!!!</b></color>", delegate { Functions.Ironic.Christmas(); }, "Joke button lol");
            new QMSingleButton(AnotherMenu1, 2, 0, "", delegate { Functions.DN.dn(); }, "Trust me bro");
            new QMSingleButton(AnotherMenu1, 3, 0, "Unban Tutorial", delegate { Functions.UnbanTut.UnbanTutorial(); }, "How to get unbanned 101");
            new QMSingleButton(AnotherMenu1, 4, 0, "Jackson", delegate { Functions.Jackson.MichealJackson(); }, "Heehee");
            // IRONIC MENU //

            // GAME MENU //
            /* Main Settings Buttons */
            var AnotherMenu2 = new QMNestedButton(menu, 4, 3f, "Game Controls", "This tooltip goes hard fr fr - Scrim", "Game Controls");
            new QMSingleButton(AnotherMenu2, 1, 3f, "<color=#fa0702><b>Reinject & Restart Game</b></color>", delegate { Functions.GameControls.ReInject(); }, "Reinjects and Restarts with EACMELON <color=#fa0702><b>(This will may not Restart your game immediantly!)</b></color>");
            new QMSingleButton(AnotherMenu2, 2, 3f, "<color=#fa0702><b>Chris Brown</b></color>", delegate { Functions.GameControls.Quit(); }, "Kills the process of the game");
            new QMSingleButton(AnotherMenu2, 3, 3f, "<color=#fa0702><b>Quick LogOut</b></color>", delegate { MelonLogger.Msg("[GC] Buh bye"); Functions.GameControls.LogOut(); }, "Logs you out lol?");
            /* Main Settings Buttons */
            /* Settings Buttons */
            new QMToggleButton(AnotherMenu2, 1, 0, "Lag yo ass out!", delegate
            { Functions.GameControls.LagGame(); MelonLogger.Msg(ConsoleColor.DarkRed, "[GC] [ON] You're now lagging ur own game (Retard)"); }, delegate
            { Functions.GameControls.UnLagGame(); MelonLogger.Msg(ConsoleColor.Green, "[GC] [OFF] U managed to not lag so badly (Quest ass man)"); }, "This fucks with ur game so badly");
            new QMSingleButton(AnotherMenu2, 2, 0, "Cap to 60", delegate { Functions.GameControls.Capto60(); MelonLogger.Msg("[GC] Capped to 60"); }, "caps to 60 (Idk lol)");
            new QMSingleButton(AnotherMenu2, 3, 0, "Cap to inf", delegate { Functions.GameControls.UnCapLol(); MelonLogger.Msg("[GC] UnCapped"); }, "frames go WHEEEEEEEE!!");
            new QMSingleButton(AnotherMenu2, 4, 0, "Get world ID", delegate { Functions.GameControls.WorldID(); }, "Grabs the world ID");
            /* Settings Buttons */
            // GAME MENU //

            // MOVEMENT MENU //
            var AnotherMenu3 = new QMNestedButton(menu, 2, 0, "Movement Controls", "Localplayer or fucking whatever idk", "Movement Controls");
            new QMToggleButton(AnotherMenu3, 1, 0, "SpeedRunner time", delegate
            { Functions.Movements.SpeedRunToggle(); MelonLogger.Msg(ConsoleColor.Blue, "[MC] [ON] You're too fast"); }, delegate
            { Functions.Movements.SpeedRunToggle(); MelonLogger.Msg(ConsoleColor.DarkBlue, "[MC] [OFF] U too slow"); }, "This fucks with ur speed");
            new QMToggleButton(AnotherMenu3, 2, 0, "I believe i can Fly", delegate
            { Functions.Movements.FlyOn(); MelonLogger.Msg(ConsoleColor.Blue, "[MC] [ON] Im an angel"); }, delegate
            { Functions.Movements.FlyOff(); MelonLogger.Msg(ConsoleColor.DarkBlue, "[MC] [OFF] Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex Hex "); }, "This makes u fly lol");
            new QMToggleButton(AnotherMenu3, 3, 0, "Click TP", delegate
            { Functions.Movements.ClickTPToggle(); MelonLogger.Msg(ConsoleColor.Blue, "[MC] [ON] Click anywhere to teleport"); }, delegate
            { Functions.Movements.ClickTPToggle(); MelonLogger.Msg(ConsoleColor.DarkBlue, "[MC] [OFF] Ok then fuck u then"); }, "This makes u teleport by clicking places lol (Ctrl + Mousebutton0 (Idk neither))");
            // MOVEMENT MENU //

            // SELF MENU //
            var AnotherMenu4 = new QMNestedButton(menu, 3, 0, "Player Controls", "Where yo movement at? - Plasma (Creds 2 rsdnt)", "Player Controls");
            new QMSingleButton(AnotherMenu4, 1, 0, "T-Pose", delegate { Functions.Self.TPOSE(); }, "Assert ur dominance ig");
            new QMSingleButton(AnotherMenu4, 2, 0, "Rep ScytheStation", delegate { Functions.Self.DefaultAVI(); }, "ScytheStation Time");
            new QMSingleButton(AnotherMenu4, 3, 0, "Change by ID", delegate { Functions.Self.AVIID(); }, "Change Avatars by ID");
            // SELF MENU //

            // VISUAL MENU //
            var AnotherMenu5 = new QMNestedButton(menu, 4, 0, "Visuals", "I can see you!", "Visuals");
            new QMToggleButton(AnotherMenu5, 1, 0, "Visualize all Players", delegate
            { Functions.Visuals.PlayerESP.ESPToggle(); }, delegate
            { Functions.Visuals.PlayerESP.ESPToggle(); }, "Highlights players with capsules");
            // VISUAL MENU //

            // GAMEWORLD MENU //
            var AnotherMenu6 = new QMNestedButton(menu, 1, 1, "GW Hacks", "Skeet on top!! number 1 cheat!!!!", "GameWorld Hacks");
            var GameMenu = new QMNestedButton(AnotherMenu6, 1, 0, "Feast ur eyes", ":Scream emoji:", "Feast ur eyes");
            var GameMenu1 = new QMNestedButton(GameMenu, 1, 0, "Murder", "Skeet on top!! number 1 cheat!!!!", "Murder");
            var GameMenu2 = new QMNestedButton(GameMenu, 2, 0, "Sussy", "Skeet on top!! number 1 cheat!!!!", "Sussy");
            var GameMenu3 = new QMNestedButton(GameMenu, 3, 0, "Etc", "Skeet on top!! number 1 cheat!!!!", "Etc");

            // -0--------------------------------8-

            // Murder (Might Update later)
            new QMSingleButton(GameMenu1, 1, 0, "Force Start", delegate { Functions.GameControls.forcestartMurd(); }, "Also Wow!");
            new QMSingleButton(GameMenu1, 2, 0, "Force End", delegate { Functions.GameControls.forceendMurd(); }, "Wow!");
            new QMSingleButton(GameMenu1, 3, 0, "Murder Wins", delegate { Functions.GameControls.MurderWin(); }, "Hackrt!");
            new QMSingleButton(GameMenu1, 4, 0, "The blinder", delegate { Functions.GameControls.blindall(); }, "wtf!");
            new QMSingleButton(GameMenu1, 1, 1, "Bystander Gets a W", delegate { Functions.GameControls.BystanderWin(); }, "how u gon hak! then lose.. wtf!! - Plasma");
            new QMSingleButton(GameMenu1, 2, 1, "Start a Minigame", delegate { Functions.GameControls.unlockminigame(); }, "no way bruh");
            new QMSingleButton(GameMenu1, 3, 1, "Deathmatch", delegate { Functions.GameControls.deathmatch(); }, "well someone browk da gawm *snort*");
            new QMSingleButton(GameMenu1, 4, 1, "Scyts pet snake", delegate { Functions.GameControls.realeasesnake(); }, "Go get em boy!");
            new QMSingleButton(GameMenu1, 1, 2, "Know it all", delegate { Functions.GameControls.findclues(); }, "I found pics of yo ma in bed");
            new QMSingleButton(GameMenu1, 2, 2, "Go to bed", delegate { Functions.GameControls.flickthelights(); }, "Lights out");
            new QMSingleButton(GameMenu1, 3, 2, "Troll the detective", delegate { Functions.GameControls.shootweapon(); }, "He must be confused asf rn");
            new QMSingleButton(GameMenu1, 4, 2, "Close doors", delegate { Functions.GameControls.closedoors(); }, "Idk what this does");

            var GameMenuExtras = new QMNestedButton(GameMenu1, 1, 3f, "->", "", "Next Page");
            new QMToggleButton(GameMenuExtras, 1, 0, "Gun Spammer", delegate
            { Functions.GameControls.SpamGun(); }, delegate
            { Functions.GameControls.SpamGun(); }, "AAAAAAAAAAAAAAAA");
            new QMToggleButton(GameMenuExtras, 2, 0, "Hard of seeing Spammer", delegate
            { Functions.GameControls.SpamBlind(); }, delegate
            { Functions.GameControls.SpamBlind(); }, "AAAAAAAAAAAAAAAA V2");

            // Among Us (Might Update later)
            new QMSingleButton(GameMenu2, 1, 0, "Force Start", delegate { Functions.GameControls.forcestartAmong(); }, "Also Wow!");
            new QMSingleButton(GameMenu2, 2, 0, "Force End", delegate { Functions.GameControls.forceendAmong(); }, "Wow!");
            new QMSingleButton(GameMenu2, 3, 0, "Eject EVERYONE", delegate { Functions.GameControls.ejecteveryone(); }, "FUNNY!!!");
            new QMSingleButton(GameMenu2, 4, 0, "Become SUS", delegate { Functions.GameControls.GiveSussy(); }, "Sex time");
            new QMSingleButton(GameMenu2, 1, 1, "Shut The Fuck Up Everyone", delegate { Functions.GameControls.ShutTheFuckUp(); }, "Oh");
            new QMSingleButton(GameMenu2, 2, 1, "Shut The Fuck Up Everyone V2", delegate { Functions.GameControls.ShutTheFuckUpV2(); }, "ok");
            new QMSingleButton(GameMenu2, 3, 1, "Fix the shit", delegate { Functions.GameControls.RepairAll(); }, "yeah");
            new QMSingleButton(GameMenu2, 4, 1, "UnFix the shit", delegate { Functions.GameControls.sabotageeverything(); }, "K");

            // Etc (Might Update later)
            new QMSingleButton(GameMenu3, 1, 0, "Kill Everyone", delegate { Functions.GameControls.KillAll(); }, "Scythe after the | after the v1.5 ScytheStation Update");
            new QMToggleButton(GameMenu3, 2, 4, "Death Forever", delegate
            { Functions.GameControls.KillAllSpam(); }, delegate
            { Functions.GameControls.KillAllSpam(); }, "AAAAAAAAAAAAAAAA V3");
            // -0--------------------------------8-
            // GAMEWORLD MENU //
        }
    }
}
