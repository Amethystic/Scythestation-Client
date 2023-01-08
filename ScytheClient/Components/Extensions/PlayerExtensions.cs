using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using VRC.UI;
using VRC.UI.Elements;

namespace ScytheStation.Components.Extensions
{
    internal static class PlayerExtensions
    {
        //		// Token: 0x1700000A RID: 10
        //		// (get) Token: 0x0600014C RID: 332 RVA: 0x000093F5 File Offset: 0x000075F5
        public static VRCPlayer LocalVRCPlayer
        {
            get
            {
                return VRCPlayer.field_Internal_Static_VRCPlayer_0;
            }
        }

        //		// Token: 0x1700000B RID: 11
        //		// (get) Token: 0x0600014D RID: 333 RVA: 0x000093FC File Offset: 0x000075FC
        public static Player LocalPlayer
        {
            get
            {
                return Player.Method_Internal_Static_Player_0();
            }
        }

        //		// Token: 0x1700000C RID: 12
        //		// (get) Token: 0x0600014E RID: 334 RVA: 0x00009403 File Offset: 0x00007603
        //		public static APIUser LocalAPIUser
        //		{
        //			get
        //			{
        //				return APIUser.CurrentUser;
        //			}
        //		}

        //		// Token: 0x0600014F RID: 335 RVA: 0x0000940A File Offset: 0x0000760A
        //		public static string DisplayName(this Player Instance)
        //		{
        //			return Instance.GetAPIUser().displayName;
        //		}

        //		// Token: 0x1700000D RID: 13
        //		// (get) Token: 0x06000150 RID: 336 RVA: 0x00009417 File Offset: 0x00007617
        //		public static USpeaker LocalUSpeaker
        //		{
        //			get
        //			{
        //				return PlayerExtensions.LocalVRCPlayer.field_Private_USpeaker_0;
        //			}
        //		}

        //		// Token: 0x1700000E RID: 14
        //		// (get) Token: 0x06000151 RID: 337 RVA: 0x00009423 File Offset: 0x00007623
        //		public static VRCPlayerApi LocalVRCPlayerAPI
        //		{
        //			get
        //			{
        //				return PlayerExtensions.LocalVRCPlayer.field_Private_VRCPlayerApi_0;
        //			}
        //		}

        //		// Token: 0x1700000F RID: 15
        //		// (get) Token: 0x06000152 RID: 338 RVA: 0x0000942F File Offset: 0x0000762F
        //		public static PlayerManager PManager
        //		{
        //			get
        //			{
        //				return PlayerManager.field_Private_Static_PlayerManager_0;
        //			}
        //		}

        //		// Token: 0x17000010 RID: 16
        //		// (get) Token: 0x06000153 RID: 339 RVA: 0x00009436 File Offset: 0x00007636
        //		public static List<Player> AllPlayers
        //		{
        //			get
        //			{
        //				return PlayerExtensions.PManager.field_Private_List_1_Player_0.ToArray().ToList<Player>();
        //			}
        //		}

        //		// Token: 0x06000154 RID: 340 RVA: 0x0000944C File Offset: 0x0000764C
        //		public static ApiAvatar GetAPIAvatar(this Player player)
        //		{
        //			return player.Method_Public_get_ApiAvatar_0();
        //		}

        //		// Token: 0x06000155 RID: 341 RVA: 0x00009454 File Offset: 0x00007654
        //		public static PlayerNet GetPlayerNet(this Player player)
        //		{
        //			return player.Method_Internal_get_PlayerNet_0();
        //		}

        //		// Token: 0x06000156 RID: 342 RVA: 0x0000945C File Offset: 0x0000765C
        //		public static USpeaker GetUSpeaker(this Player player)
        //		{
        //			return player.prop_USpeaker_0.field_Private_ArrayOf_Byte_0();
        //		}

        //		// Token: 0x06000157 RID: 343 RVA: 0x00009464 File Offset: 0x00007664
        //		public static VRCPlayerApi GetVRCPlayerApi(this Player player)
        //		{
        //			return player.field_Private_VRCPlayerApi_0;
        //		}

        //		// Token: 0x06000158 RID: 344 RVA: 0x0000946C File Offset: 0x0000766C
        //		public static APIUser GetAPIUser(this Player player)
        //		{
        //			return player.Method_Internal_get_APIUser_0();
        //		}

        //		// Token: 0x06000159 RID: 345 RVA: 0x00009474 File Offset: 0x00007674
        //		public static bool IsQuest(this Player player)
        //		{
        //			return player.GetAPIUser().IsOnMobile;
        //		}

        //		// Token: 0x0600015A RID: 346 RVA: 0x00009484 File Offset: 0x00007684
        //		public static void ToggleBlock(this Player player)
        //		{
        //			PageUserInfo pageUserInfo = player.GetPageUserInfo();
        //			if (!player.IsLocalPlayer())
        //			{
        //				pageUserInfo.ToggleBlock();
        //			}
        //		}

        //		// Token: 0x0600015B RID: 347 RVA: 0x000094A8 File Offset: 0x000076A8
        //		public static void ToggleMute(this Player player)
        //		{
        //			PageUserInfo pageUserInfo = player.GetPageUserInfo();
        //			if (!player.IsLocalPlayer())
        //			{
        //				pageUserInfo.ToggleMute();
        //			}
        //		}

        //		// Token: 0x0600015C RID: 348 RVA: 0x000094CC File Offset: 0x000076CC
        //		private static PageUserInfo GetPageUserInfo(this Player player)
        //		{
        //			PageUserInfo component = GameObject.Find("Screens").transform.Find("UserInfo").GetComponent<PageUserInfo>();
        //			component.field_Private_APIUser_0 = new APIUser
        //			{
        //				id = player.GetAPIUser().id
        //			};
        //			return component;
        //		}

        //		// Token: 0x0600015D RID: 349 RVA: 0x00009518 File Offset: 0x00007718
        //		//public static void SendVRCEvent(VRC_EventHandler.VrcEvent vrcEvent, VRC_EventHandler.VrcBroadcastType type, GameObject instagator)
        //		//{
        //		//	if (PlayerExtensions.handler == null)
        //		//	{
        //		//		PlayerExtensions.handler = Resources.FindObjectsOfTypeAll<VRC_EventHandler>().FirstOrDefault<VRC_EventHandler>();
        //		//	}
        //		//	vrcEvent.ParameterObject = Player.Method_Internal_Static_Player_0().prop_USpeaker_0().gameObject;
        //		//	PlayerExtensions.handler.TriggerEvent(vrcEvent, type, instagator, 0f);
        //		//}

        //		// Token: 0x0600015E RID: 350 RVA: 0x00009568 File Offset: 0x00007768
        //		public static GameObject InstantiatePrefab(string PrefabNAME, Vector3 position, Quaternion rotation)
        //		{
        //			return Networking.Instantiate(0, PrefabNAME, position, rotation);
        //		}

        //		// Token: 0x0600015F RID: 351 RVA: 0x00009573 File Offset: 0x00007773
        //		public static void Mute(bool toggle)
        //		{
        //		}

        //		// Token: 0x06000160 RID: 352 RVA: 0x00009575 File Offset: 0x00007775
        //		public static void SetVolume(this Player player, float vol)
        //		{
        //			player.GetUSpeaker().field_Private_SimpleAudioGain_0.field_Public_Single_0 = vol;
        //		}

        //		// Token: 0x06000161 RID: 353 RVA: 0x00009588 File Offset: 0x00007788
        //		public static float GetVolume(this Player player)
        //		{
        //			return player.GetUSpeaker().field_Private_SimpleAudioGain_0.field_Public_Single_0;
        //		}

        //		// Token: 0x06000162 RID: 354 RVA: 0x0000959A File Offset: 0x0000779A
        //		public static bool IsLocalMuted(this Player player)
        //		{
        //			return player.GetVolume() == 0f;
        //		}

        //		// Token: 0x06000163 RID: 355 RVA: 0x000095A9 File Offset: 0x000077A9
        //		public static void LocalMute(this Player player)
        //		{
        //			player.SetVolume(0f);
        //		}

        //		// Token: 0x06000164 RID: 356 RVA: 0x000095B6 File Offset: 0x000077B6
        //		public static void LocalUnMute(this Player player)
        //		{
        //			player.SetVolume(1f);
        //		}

        //		// Token: 0x06000165 RID: 357 RVA: 0x000095C3 File Offset: 0x000077C3
        //public static bool IsInVR(this Player player)
        //{
        //    return player.GetVRCPlayerApi().IsUserInVR();
        //}

        //		// Token: 0x06000166 RID: 358 RVA: 0x000095D0 File Offset: 0x000077D0
        //		//public static void Teleport(this Player player)
        //		//{
        //		//	PlayerExtensions.LocalVRCPlayer.transform.position = player.GetVRCPlayer().transform.position;
        //		//}

        //		// Token: 0x06000167 RID: 359 RVA: 0x000095F1 File Offset: 0x000077F1
        //		public static void ReloadAvatar(this Player player)
        //		{
        //			VRCPlayer.Method_Public_Static_Boolean_APIUser_0(player.GetAPIUser());
        //		}

        //		// Token: 0x06000168 RID: 360 RVA: 0x000095FF File Offset: 0x000077FF
        //		public static QuickMenu GetQuickMenu()
        //		{
        //			return GameObject.Find("UserInterface/QuickMenu").GetComponent<QuickMenu>();
        //		}

        //		// Token: 0x06000169 RID: 361 RVA: 0x00009610 File Offset: 0x00007810
        //		public static void ReloadAllAvatars()
        //		{
        //			PlayerExtensions.LocalVRCPlayer.Method_Public_Void_Boolean_0(false);
        //		}

        //		// Token: 0x0600016A RID: 362 RVA: 0x0000961D File Offset: 0x0000781D
        //		//public static VRCPlayer GetVRCPlayer(this Player player)
        //		//{
        //		//	return player.Method_Internal_get_VRCPlayer_0();
        //		//}

        //		//// Token: 0x0600016B RID: 363 RVA: 0x00009625 File Offset: 0x00007825
        //		//public static VRCAvatarManager GetVRCAvatarManager(this VRCPlayer player)
        //		//{
        //		//	return player.Method_Public_get_VRCAvatarManager_0();
        //		//}

        //		// Token: 0x0600016C RID: 364 RVA: 0x0000962D File Offset: 0x0000782D
        //		public static string GetName(this Player player)
        //		{
        //			return player.GetAPIUser().displayName;
        //		}

        //		// Token: 0x17000011 RID: 17
        //		// (get) Token: 0x0600016D RID: 365 RVA: 0x0000963A File Offset: 0x0000783A
        //		// (set) Token: 0x0600016E RID: 366 RVA: 0x00009641 File Offset: 0x00007841
        //		public static float LocalGain
        //		{
        //			get
        //			{
        //				return USpeaker.field_Internal_Static_Single_1;
        //			}
        //			set
        //			{
        //				USpeaker.field_Internal_Static_Single_1 = value;
        //			}
        //		}

        //		// Token: 0x17000012 RID: 18
        //		// (get) Token: 0x0600016F RID: 367 RVA: 0x00009649 File Offset: 0x00007849
        //		// (set) Token: 0x06000170 RID: 368 RVA: 0x00009650 File Offset: 0x00007850
        //		public static float AllGain
        //		{
        //			get
        //			{
        //				return USpeaker.field_Internal_Static_Single_0;
        //			}
        //			set
        //			{
        //				USpeaker.field_Internal_Static_Single_0 = value;
        //			}
        //		}

        //		// Token: 0x17000013 RID: 19
        //		// (get) Token: 0x06000171 RID: 369 RVA: 0x00009658 File Offset: 0x00007858
        //		public static float DefaultGain
        //		{
        //			get
        //			{
        //				return 1f;
        //			}
        //		}

        //		// Token: 0x17000014 RID: 20
        //		// (get) Token: 0x06000172 RID: 370 RVA: 0x0000965F File Offset: 0x0000785F
        //		public static float MaxGain
        //		{
        //			get
        //			{
        //				return float.MaxValue;
        //			}
        //		}

        //		// Token: 0x06000173 RID: 371 RVA: 0x00009666 File Offset: 0x00007866
        //		public static bool IsMaster(this Player player)
        //		{
        //			return player.GetVRCPlayerApi().isMaster;
        //		}

        //		// Token: 0x06000174 RID: 372 RVA: 0x00009673 File Offset: 0x00007873
        //public static int GetActorNumber(this Player player)
        //{
        //    return player.GetVRCPlayerApi().playerId;
        //}

        //		// Token: 0x06000175 RID: 373 RVA: 0x00009680 File Offset: 0x00007880
        //		public static int GetPlayerFrames(this Player player)
        //		{
        //			if (player.GetPlayerNet().field_Private_Byte_0 == 0)
        //			{
        //				return 0;
        //			}
        //			return (int)(1000f / (float)player.GetPlayerNet().field_Private_Byte_0);
        //		}

        //		// Token: 0x06000176 RID: 374 RVA: 0x000096A4 File Offset: 0x000078A4
        //		public static int GetPlayerPing(this Player player)
        //		{
        //			return (int)player.GetPlayerNet().field_Private_Int16_0;
        //		}

        //		// Token: 0x06000177 RID: 375 RVA: 0x000096B1 File Offset: 0x000078B1
        //		public static void ChangeAvatar(string AvatarID)
        //		{
        //			new PageAvatar
        //			{
        //				field_Public_SimpleAvatarPedestal_0 = new SimpleAvatarPedestal
        //				{
        //					field_Internal_ApiAvatar_0 = new ApiAvatar
        //					{
        //						id = AvatarID
        //					}
        //				}
        //			}.ChangeToSelectedAvatar();
        //		}

        //		// Token: 0x06000178 RID: 376 RVA: 0x000096DA File Offset: 0x000078DA
        //		public static void SetLocalPlayerWalkSpeed(float speed)
        //		{
        //			PlayerExtensions.LocalPlayer.GetVRCPlayerApi().SetWalkSpeed(speed);
        //		}

        //		// Token: 0x06000179 RID: 377 RVA: 0x000096EC File Offset: 0x000078EC
        //		public static void SetLocalPlayerWalkSpeed()
        //		{
        //			PlayerExtensions.LocalPlayer.GetVRCPlayerApi().SetWalkSpeed(0f);
        //		}

        //		// Token: 0x0600017A RID: 378 RVA: 0x00009702 File Offset: 0x00007902
        //		public static void SetLocalPlayerRunSpeed(float speed)
        //		{
        //			PlayerExtensions.LocalPlayer.GetVRCPlayerApi().SetRunSpeed(speed);
        //		}

        //		// Token: 0x0600017B RID: 379 RVA: 0x00009714 File Offset: 0x00007914
        //		public static void SetLocalPlayerRunSpeed()
        //		{
        //			PlayerExtensions.LocalPlayer.GetVRCPlayerApi().SetRunSpeed(0f);
        //		}

        //		// Token: 0x0600017C RID: 380 RVA: 0x0000972A File Offset: 0x0000792A
        //		public static void SetLocalPlayerStrafeSpeed(float speed)
        //		{
        //			PlayerExtensions.LocalPlayer.GetVRCPlayerApi().SetStrafeSpeed(speed);
        //		}

        //		// Token: 0x0600017D RID: 381 RVA: 0x0000973C File Offset: 0x0000793C
        //		public static void SetLocalPlayerStrafeSpeed()
        //		{
        //			PlayerExtensions.LocalPlayer.GetVRCPlayerApi().SetStrafeSpeed(0f);
        //		}

        //		// Token: 0x0600017E RID: 382 RVA: 0x00009752 File Offset: 0x00007952
        //		public static void ToggleBlock(string player)
        //		{
        //		}

        //		// Token: 0x0600017F RID: 383 RVA: 0x00009754 File Offset: 0x00007954
        //		public static Player GetPlayer(int ActorNumber)
        //		{
        //			return (from p in PlayerExtensions.AllPlayers
        //					where p.GetActorNumber() == ActorNumber
        //					select p).FirstOrDefault<Player>();
        //		}

        //		// Token: 0x06000180 RID: 384 RVA: 0x0000978C File Offset: 0x0000798C
        //		public static string GetSteamID(this VRCPlayer player)
        //		{
        //			return player.field_Private_UInt64_0.ToString();
        //		}

        //		// Token: 0x06000181 RID: 385 RVA: 0x000097A8 File Offset: 0x000079A8
        //		public static Player GetPlayer(string Displayname)
        //		{
        //			return (from p in PlayerExtensions.AllPlayers
        //					where p.GetName() == Displayname
        //					select p).FirstOrDefault<Player>();
        //		}

        //		// Token: 0x06000182 RID: 386 RVA: 0x000097DD File Offset: 0x000079DD
        //		//public static Player GetPlayer(this VRCPlayer player)
        //		//{
        //		//	return player.();
        //		//}

        //		// Token: 0x06000183 RID: 387 RVA: 0x000097E5 File Offset: 0x000079E5
        //		public static bool IsLocalPlayer(this Player player)
        //		{
        //			return player.GetAPIUser().id == APIUser.CurrentUser.id;
        //		}

        //		// Token: 0x06000184 RID: 388 RVA: 0x00009804 File Offset: 0x00007A04
        //		public static Player GetPlayerByID(string UserID)
        //		{
        //			return (from p in PlayerExtensions.AllPlayers
        //					where p.GetAPIUser().id == UserID
        //					select p).FirstOrDefault<Player>();
        //		}

        //		// Token: 0x06000185 RID: 389 RVA: 0x00009839 File Offset: 0x00007A39
        //		public static void SetGain(float Gain)
        //		{
        //			PlayerExtensions.LocalGain = Gain;
        //		}

        //		// Token: 0x06000186 RID: 390 RVA: 0x00009841 File Offset: 0x00007A41
        //		public static void ResetGain()
        //		{
        //			USpeaker.field_Internal_Static_Single_1 = PlayerExtensions.DefaultGain;
        //		}

        //		// Token: 0x06000187 RID: 391 RVA: 0x0000984D File Offset: 0x00007A4D
        public static bool IsInWorld()
        {
            return RoomManager.field_Internal_Static_ApiWorld_0 != null;
        }

        //		// Token: 0x06000188 RID: 392 RVA: 0x00009857 File Offset: 0x00007A57
        //		public static Player[] GetAllPlayers()
        //		{
        //			return PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.ToArray();
        //		}

        //		// Token: 0x04000101 RID: 257
        //		private static VRC_EventHandler handler;
    }
}
