using System;
using ScytheStation.Core.Wrappers;
using UnityEngine;
using UnhollowerBaseLib;
using VRC.SDKBase;

namespace ScytheStation.Functions
{
    internal class Items
    {
        public class ObjectESP
        {
            public static void Enable()
            {
                Items.ObjectESP.PickupESP(true);
            }
            public static void Disable()
            {
                Items.ObjectESP.PickupESP(false);
            }
            internal static void PickupESP(bool state)
            {
                {
                    Il2CppArrayBase<VRC_Pickup> il2CppArrayBase = Resources.FindObjectsOfTypeAll<VRC_Pickup>();
                    foreach (VRC_Pickup vrc_Pickup in il2CppArrayBase)
                    {
                        bool flag = !((UnityEngine.Object)vrc_Pickup == null) && !((UnityEngine.Object)vrc_Pickup.gameObject == null) && vrc_Pickup.gameObject.active && vrc_Pickup.enabled && vrc_Pickup.pickupable && !vrc_Pickup.name.Contains("ViewFinder") && !((UnityEngine.Object)HighlightsFX.field_Private_Static_HighlightsFX_0 == null);
                        if (flag)
                        {
                            HighlightsFX.Method_Public_Static_Void_Renderer_Boolean_PDM_0((Renderer)vrc_Pickup.GetComponentInChildren<MeshRenderer>(), state);
                        }
                    }
                }
            }
        }
        public class Objects
        {
			//public static void BPickups(Player player)
			//{
			//	for (int i = 0; i < Objects.array.Length; i++)
			//	{
			//		if (Objects.array[i].gameObject)
			//		{
			//			Networking.SetOwner(PlayerExtensions.LocalPlayer.field_Private_VRCPlayerApi_0, Objects.array[i].gameObject);
			//			Objects.array[i].transform.transform.position = player.transform.position + new Vector3(0f, 0.1f, 0f);
			//		}
			//	}
			//}
			//public static void respawnpickups()
			//{
			//	for (int i = 0; i < Objects.array.Length; i++)
			//	{
			//		if (Networking.GetOwner(Objects.array[i].gameObject) != Networking.LocalPlayer)
			//		{
			//			Networking.SetOwner(Networking.LocalPlayer, Objects.array[i].gameObject);
			//		}
			//		Objects.array[i].transform.localPosition = new Vector3(-999f, -999f, -999f);
			//	}
			//}
			//public static void objectowner()
			//{
			//	for (int i = 0; i < Objects.array.Length; i++)
			//	{
			//		if (Objects.array[i].gameObject && Networking.GetOwner(Objects.array[i].gameObject) != Networking.LocalPlayer)
			//		{
			//			Networking.SetOwner(PlayerExtensions.LocalPlayer.field_Private_VRCPlayerApi_0, Objects.array[i].gameObject);
			//		}
			//	}
			//}
			//public static void rotateobj()
			//{
			//	for (int i = 0; i < Objects.array.Length; i++)
			//	{
			//		if (Objects.array[i].gameObject)
			//		{
			//			Networking.SetOwner(PlayerExtensions.LocalPlayer.field_Private_VRCPlayerApi_0, Objects.array[i].gameObject);
			//			Objects.array[i].transform.transform.Rotate(1f, 1f, 1f);
			//		}
			//	}
			//}
		}
    }
}
