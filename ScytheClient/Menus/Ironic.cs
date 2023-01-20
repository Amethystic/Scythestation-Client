using ApolloCore.API.QM;

namespace ScytheStation.Menus
{
    internal class Ironic
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
        }
    }
}
