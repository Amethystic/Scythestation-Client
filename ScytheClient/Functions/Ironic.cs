using System.Diagnostics;
using MelonLoader;
using Obfuscation = System.Reflection.ObfuscationAttribute;

namespace ScytheStation.Functions
{
    internal class Ironic
    {
        [Obfuscation(Exclude = false)]
        public static int Number = 1;
        public static void Christmas()
        {
            MelonLogger.Msg("[Goofy] Christmas is in a week! Woohoo!! I am so happy about this information!");
            Process.Start("https://www.youtube.com/watch?v=gRo9Z5nAp9g&feature=youtu.be");
        }
        public static void dn()
        {
            MelonLogger.Msg("[Goofy] DN lol");
            Process.Start("https://vine.fandom.com/wiki/Deez_Nuts");
            Process.Start("https://youtu.be/BYzZ7HpnZ_Q?t=34");
            Process.Start("https://www.youtube.com/watch?v=zDCQsScA_JA&t=25s");
        }
        public static void UnbanTutorial()
        {
            MelonLogger.Msg("[Goofy] Sponsoreded by MEOWENGINE");
            Process.Start("https://www.youtube.com/watch?v=uQHqZ2B2780");
            Process.Start("https://help.vrchat.com/hc/en-us/requests/new");
        }
        public static void MichealJackson()
        {
            MelonLogger.Msg("[Goofy] Heehee");
            int Loop = 0;
            for (; ; )
            {
                if (Loop < 50)
                {
                    Process.Start("https://www.youtube.com/watch?v=7BqLKGJZ9lI");
                    Process.Start("https://www.youtube.com/watch?v=7BqLKGJZ9lI");
                    Process.Start("https://www.youtube.com/watch?v=7BqLKGJZ9lI");
                    Process.Start("https://www.youtube.com/watch?v=7BqLKGJZ9lI");
                    Process.Start("https://www.youtube.com/watch?v=7BqLKGJZ9lI");
                    Loop++;
                }
                else { break; }
            } // By Peebo29 [From https://www.tutorialsteacher.com/csharp/csharp-for-loop]
        }
        public static void Counter()
        {
            MelonLogger.Msg($"[Goofy] Counting up to {Number}");
            Number++;
        }
    }
}
