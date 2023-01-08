using System;
using System.Linq;
using UnityEngine;
using ScytheStation.Core.Wrappers;
using ScytheStation.Components;
using ScytheStation.Components.Extensions;
using VRC;
using MelonLoader;

namespace ScytheStation.Functions
{
    internal class Visuals
    {
		public class PlayerESP
        {
            public static void ESPOn()
            {
                MelonLogger.Msg(ConsoleColor.Blue, "[VISUALS] ESP On");
                HighlightsFX.field_Private_Static_HighlightsFX_0.enabled = true;
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
                    catch
                    {
                        MelonLogger.Msg(ConsoleColor.DarkBlue, "[VISUALS] Failed to start ESP On Players");
                    }
                }
            }
            public static void ESPOff()
            {
                HighlightsFX.field_Private_Static_HighlightsFX_0.enabled = false;
                MelonLogger.Msg(ConsoleColor.DarkBlue, "[VISUALS] ESP Off");
            }

        }
    }
}
