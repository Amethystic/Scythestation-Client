using ApolloCore.API.QM;

namespace ScytheStation.Menus
{
    internal class Self
    {
        public static void Init(QMTabMenu menu)
        {
            // SELF MENU //
            var AnotherMenu4 = new QMNestedButton(menu, 3, 0, "Player Controls", "Where yo movement at? - Plasma (Creds 2 rsdnt)", "Player Controls");
            new QMSingleButton(AnotherMenu4, 1, 0, "T-Pose", delegate { Functions.Self.TPOSE(); }, "Assert ur dominance ig");
            new QMSingleButton(AnotherMenu4, 2, 0, "Rep ScytheStation", delegate { Functions.Self.DefaultAVI(); }, "ScytheStation Time");
            new QMSingleButton(AnotherMenu4, 3, 0, "Change by ID", delegate { Functions.Self.AVIID(); }, "Change Avatars by ID");
            // SELF MENU //
        }
    }
}
