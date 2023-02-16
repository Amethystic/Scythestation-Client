﻿using System.Linq;
using UnityEngine;

namespace ApolloCore.API.QM
{
    public class QMButtonBase
    {
        public GameObject button;
        public string btnQMLoc;
        public int[] initShift = { 0, 0 };

        public GameObject GetGameObject() => button;

        public void SetActive(bool state) => button.gameObject.SetActive(state);

        public void SetLocation(float buttonXLoc, float buttonYLoc)
        {
            button.GetComponent<RectTransform>().anchoredPosition += Vector2.right * (232 * (buttonXLoc + initShift[0]));
            button.GetComponent<RectTransform>().anchoredPosition += Vector2.down * (210 * (buttonYLoc + initShift[1]));
        }

        public void SetToolTip(string buttonToolTip) => button.GetComponents<VRC.UI.Elements.Tooltips.UiToggleTooltip>().ToList().ForEach(x => x.field_Public_String_0 = buttonToolTip);

        public void DestroyMe()
        {
            try
            {
                Object.Destroy(button);
            }
            catch { }
        }
    }
}
