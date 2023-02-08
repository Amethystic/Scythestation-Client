using UnityEngine;
using ScytheStation.Components;
using ScytheStation.Components.Extensions;
using VRC;
using MelonLoader;
using UnhollowerBaseLib;
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
            if (MainSettings.ESPCapsules)
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
        public class ObjectESP
        {
            public static void PickupESP()
            {
                if (MainSettings.IESP)
                {
                    try
                    {
                        Il2CppArrayBase<VRC_Pickup> il2CppArrayBase = Resources.FindObjectsOfTypeAll<VRC_Pickup>();
                        foreach (VRC_Pickup vrc_Pickup in il2CppArrayBase)
                        {
                            bool flag = !((UnityEngine.Object)vrc_Pickup == null) && !((UnityEngine.Object)vrc_Pickup.gameObject == null) && vrc_Pickup.gameObject.active && vrc_Pickup.enabled && vrc_Pickup.pickupable && !vrc_Pickup.name.Contains("ViewFinder") && !((UnityEngine.Object)HighlightsFX.field_Private_Static_HighlightsFX_0 == null);
                            if (flag)
                            {
                                HighlightsFX.Method_Public_Static_Void_Renderer_Boolean_PDM_0(vrc_Pickup.GetComponentInChildren<MeshRenderer>(), MainSettings.IESP);
                            }
                        }
                    }
                    catch { MelonLogger.Error("[VISUALS] Failed to start ESP On Items"); }
                }
            }
        }
        internal class MenuCustomization
        {
            public static void HideMenuApiButtons()
            {
                if (MenuCustomizationSettings.HideApiButtonBG)
                {
                    try
                    {
                        GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Dashboard/Background").SetActive(false);
                        GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Notifications/Background").SetActive(false);
                        GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Here/Background").SetActive(false);
                        GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Camera/Background").SetActive(false);
                        GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_AudioSettings/Background").SetActive(false);
                        GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Settings/Background").SetActive(false);
                        GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/i-TabMenu-/Background").SetActive(false);
                    }
                    catch
                    {
                        MelonLogger.Error("[VISUALS | CUSTOMIZATION] Failed to hide button backgrounding");
                    }
                }
                else
                {
                    try
                    {
                        GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Dashboard/Background").SetActive(true);
                        GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Notifications/Background").SetActive(true);
                        GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Here/Background").SetActive(true);
                        GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Camera/Background").SetActive(true);
                        GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_AudioSettings/Background").SetActive(true);
                        GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Settings/Background").SetActive(true);
                        GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/i-TabMenu-/Background").SetActive(true);
                    }
                    catch
                    {
                        MelonLogger.Error("[VISUALS | CUSTOMIZATION] Failed to unhide button backgrounding");
                    }
                }
            }
        }
    }
}
