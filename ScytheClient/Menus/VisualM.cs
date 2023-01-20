using ApolloCore.API.QM;


namespace ScytheStation.Menus
{
    internal class VisualM
    {
        public static void Init(QMTabMenu menu)
        {
            // VISUAL MENU //
            var AnotherMenu5 = new QMNestedButton(menu, 4, 0, "Visuals", "I can see you!", "Visuals");
            new QMToggleButton(AnotherMenu5, 1, 0, "Visualize all Players", delegate
            { Functions.Visuals.PlayerESP.ESPToggle(); }, delegate
            { Functions.Visuals.PlayerESP.ESPToggle(); }, "Highlights players with capsules");
            // VISUAL MENU //
        }
    }
}
