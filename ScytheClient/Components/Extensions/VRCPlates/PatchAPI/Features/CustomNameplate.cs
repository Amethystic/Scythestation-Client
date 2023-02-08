using System;
using TMPro;
using UnityEngine;
using VRC;
using ScytheStation.Components;
using ScytheStation.Core.Wrappers;

namespace VRCPlates
{
    internal class CustomNameplate : MonoBehaviour
    {
        public Player player = new Player();
        public Transform PlateObg;
        public TextMeshProUGUI Nameplatext;
        public byte frames, ping;
        public int noUpdateCount = 0;

        public CustomNameplate(IntPtr ptr) : base(ptr) { }

        public void Start()
        {
            if (MainSettings.Nameplates.Value)
            {
                PlayerNameplate namePlateManager = player._vrcplayer.field_Public_PlayerNameplate_0;
                Transform Plate = namePlateManager.field_Public_GameObject_5.transform;
                PlateObg = Instantiate(Plate, Plate);
                PlateObg.parent = namePlateManager.transform;
                PlateObg.parent = gameObject.transform.Find("Contents");
                PlateObg.name = "ScythePlates";
                PlateObg.gameObject.SetActive(true);
                PlateObg.localPosition = new Vector3(0f, 62f, 0f);
                PlateObg.localScale = new Vector3(1f, 1f, 2f);
                Nameplatext = PlateObg.Find("Trust Text").GetComponent<TextMeshProUGUI>();
                Nameplatext.color = Color.white;
                Nameplatext.fontStyle = FontStyles.Subscript;
                Nameplatext.isOverlay = true;
                PlateObg.Find("Trust Icon").gameObject.SetActive(false);
                PlateObg.Find("Performance Icon").gameObject.SetActive(false);
                PlateObg.Find("Performance Text").gameObject.SetActive(false);
                PlateObg.Find("Friend Anchor Stats").gameObject.SetActive(false);

                frames = player._playerNet.field_Private_Byte_0;
                ping = player._playerNet.field_Private_Byte_1;
                Nameplatext.text = "";
                Update();
            }
            else
            {
                PlayerNameplate namePlateManager = player._vrcplayer.field_Public_PlayerNameplate_0;
                Transform Plate = namePlateManager.field_Public_GameObject_5.transform;
                PlateObg = Instantiate(Plate, Plate);
                PlateObg.parent = namePlateManager.transform;
                PlateObg.parent = gameObject.transform.Find("Contents");
                PlateObg.name = "ScythePlates";
                PlateObg.gameObject.SetActive(false);
            }
        }
        private void Update()
        {
            if (frames == player._playerNet.field_Private_Byte_0 && ping == player._playerNet.field_Private_Byte_1)
            {
                noUpdateCount++;
            }
            else
            {
                noUpdateCount = 0;
            }
            frames = player._playerNet.field_Private_Byte_0;
            ping = player._playerNet.field_Private_Byte_1;

            var status = "<color=green>Alive</color>";
            if (noUpdateCount > 35)
            {
                status = "<color=yellow>Fuckery</color>";
            }
            if (noUpdateCount > 375)
            {
                status = "<color=red>Dead as fuck</color>";
            }
            try
            {
                Nameplatext.text = $"[<color=green>{ player.GetPlatform() }</color>] | [{ status }] |<color=white> FPS:</color> { player.GetFramesColord() }|<color=white> P:</color> { player.GetPingColord() } |<color=red> Admin?:</color> { player.ClientDetect() }";
            }
            catch { }
        }
    }
}
