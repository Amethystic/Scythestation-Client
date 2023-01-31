using UnityEngine;
using ScytheStation.Components;
using ScytheStation.Components.Extensions;
using VRC;
using MelonLoader;
using System.Linq;
using VRC.SDKBase;

namespace ScytheStation.Functions
{
    internal class Visuals
    {
        public static VRC_Pickup[] vrc_Pickups;

        public static VRC_Trigger[] vrc_Triggers;
        // ik this is from ml but i'll replace it soon (peebo29)
        internal GameObject nameplateCanvas;
        public static void ESPToggle()
        {
            if (MainSettings.ESPCapsules.Value)
            {
                HighlightsFX.field_Private_Static_HighlightsFX_0.enabled = true;
                HighlightsFX.field_Private_Static_HighlightsFX_0.field_Protected_Material_0.color = Color.magenta;
                if (PlayerExtensions.IsInWorld() && PlayerExtensions.LocalPlayer != null)
                {
                    try
                    {
                        foreach (Player player in PlayerManager.Method_Public_Static_List_1_Player_PDM_0().ToArray())
                        {
                            if (player.transform.Find("SelectRegion"))
                            {
                                Renderer component = player.transform.Find("SelectRegion").GetComponent<Renderer>();
                                HighlightsFX.field_Private_Static_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(component, player);
                            }
                        }
                    }
                    catch { MelonLogger.Error("[VISUALS] Failed to start ESP On Players"); }
                }
            }
            else { HighlightsFX.field_Private_Static_HighlightsFX_0.enabled = false; }
        }
    }
}
