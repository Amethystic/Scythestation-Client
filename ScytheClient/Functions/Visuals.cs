using UnityEngine;
using ScytheStation.Components;
using ScytheStation.Components.Extensions;
using VRC;
using MelonLoader;
using Obfuscation = System.Reflection.ObfuscationAttribute;
using System.Linq;
using VRC.Core;
using VRC.SDKBase;
using VRC.UI;

namespace ScytheStation.Functions
{
    internal class Visuals
    {
        private static Renderer[] _Render { get; set; }
        internal static VRC_Pickup[] Pickupsobs;
        internal static Shader outlshader = null;
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
        public static void Itemesp()
        {
            if (MainSettings.IESP.Value)
            {
                try
                {
                    for (int i = 0; i < Pickupsobs.Length; i++)
                    {
                        Outlineobjectandchilds(Pickupsobs[i].gameObject, new Color(0, 1, 2, 1));
                    }
                }
                catch { MelonLogger.Error("[VISUALS] Failed to start ESP On Items"); }
            }
        }
        internal static void Outlineobjectandchilds(GameObject obj, Color colora, bool onoff = true)
        {
            try
            {
                _Render = obj.GetComponentsInChildren<Renderer>(true);
                if (onoff)
                {
                    var outm = new Material(outlshader);
                    outm.EnableKeyword("_falloff");
                    outm.SetFloat("_falloff", 0);
                    outm.EnableKeyword("_Color");
                    outm.SetColor("_Color", colora);
                    outm.EnableKeyword("width");
                    outm.SetFloat("_Width", 0.6f);
                    outm.name = "espshaderNocturnal";
                    for (int i = 0; i < _Render.Length; i++)
                    {
                        var materials = _Render[i].sharedMaterials.ToList();
                        materials.Add(outm);
                        _Render[i].materials = materials.ToArray();
                        _Render[i].allowOcclusionWhenDynamic = false;

                    }
                }
                else
                {
                    for (int i = 0; i < _Render.Length; i++)
                    {
                        var materials = _Render[i].sharedMaterials.ToList();
                        for (int i2 = 0; i2 < materials.Count; i2++)
                        {
                            if (materials[i2].name == "espshaderNocturnal")
                                materials.Remove(materials[i2]);
                        }
                        _Render[i].materials = materials.ToArray();
                        _Render[i].allowOcclusionWhenDynamic = true;
                    }
                }
            }
            catch { }
        }
    }
}
