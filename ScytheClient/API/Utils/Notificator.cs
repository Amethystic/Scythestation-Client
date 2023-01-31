using UnityEngine;
using ScytheStation.Core.FileManager;
using UserEventCarousel = MonoBehaviourPublicObusQu1VaObQu12StUnique;
using Obfuscation = System.Reflection.ObfuscationAttribute;

namespace ScytheStation.API.Utils
{
    internal class Notificator
    {
        private static UserEventCarousel _ActiveCarousel { get; set; }
        internal static UserEventCarousel ActiveCarousel { get { if (_ActiveCarousel == null) { foreach (var carousel in Resources.FindObjectsOfTypeAll<UserEventCarousel>()) { if (carousel != null) { if (carousel.field_Private_List_1_MonoBehaviourPublicTMteCaSiImdiCoUnique_1.Count != 0) { return _ActiveCarousel = carousel; } } } } return _ActiveCarousel; } }
        private static Transform _User_Event_Carousel { get; set; }
        internal static Transform User_Event_Carousel { get { if (_User_Event_Carousel == null) { return _User_Event_Carousel = ActiveCarousel.transform; } return _User_Event_Carousel; } }
        internal static void WriteHudMessage(string Text) { if (ActiveCarousel != null) { try { ActiveCarousel.Method_Private_Void_String_Sprite_0(Text, LoadSprite.LoadSpriteFromDisk($"{Directories.Folder}\\Dependencies\\Images\\scythestation.png")); } catch { ActiveCarousel.Method_Private_Void_String_Sprite_0(Text, null); } } }
    }
}
