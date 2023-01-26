using ApolloCore.API.QM;
using System;
using MelonLoader;
using ScytheStation.API.Utils;
using Obfuscation = System.Reflection.ObfuscationAttribute;

namespace ScytheStation.Menus
{
    internal class Ironic
    {
        [Obfuscation(Exclude = false)]
        public static void Init(QMTabMenu menu)
        {
            // IRONIC MENU //
            var AnotherMenu1 = new QMNestedButton(menu, 1, 0, "Ironic", "For ironic and giggles n shit buttons", "Ironic");
            new QMSingleButton(AnotherMenu1, 1, 0, "<color=#ed2311><b>Chris</b></color><color=#56ed11><b>tmas!!!!!!!!</b></color>", delegate { Functions.Ironic.Christmas(); Notificator.WriteHudMessage($"[IRONIC] Christmas!"); }, "Joke button lol");
            new QMSingleButton(AnotherMenu1, 2, 0, "", delegate { Functions.Ironic.dn(); Notificator.WriteHudMessage($"[IRONIC] Thx for trusting me"); }, "Trust me bro");
            new QMSingleButton(AnotherMenu1, 3, 0, "Unban Tutorial", delegate { Functions.Ironic.UnbanTutorial(); Notificator.WriteHudMessage($"[IRONIC] MEOWENGINE EXCLUSIVE"); }, "How to get unbanned 101");
            new QMSingleButton(AnotherMenu1, 4, 0, "Jackson", delegate { Functions.Ironic.MichealJackson(); Notificator.WriteHudMessage($"[IRONIC] heehee"); }, "Heehee");
            new QMSingleButton(AnotherMenu1, 1, 1, "Press this!", delegate { Functions.Ironic.Counter(); Notificator.WriteHudMessage($"[IRONIC] +1"); }, "Stop pressing this button");
            // IRONIC MENU //
            MelonLogger.Msg(ConsoleColor.Green, "[MENUS] IronicFunnies Loaded", MenuManager.C++);
        }
    }
}
