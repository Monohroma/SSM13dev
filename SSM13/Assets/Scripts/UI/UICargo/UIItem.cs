using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Storage;
using UnityEngine.UI;

namespace UI
{
    public class UIItem : MonoBehaviour
    {
        public TMP_Text NameTitle;
        public TMP_Text CountTitle;
        public Image sprite;
        private int count = 1;
        private GameItem gameItem;
        private UICargo uiCargo;

        public void Setup(UICargo uiCargo, GameItem gi, int count)
        {
            gameObject.SetActive(true);
            gameItem = gi;
            NameTitle.text = gi.ItemName;
            CountTitle.text = "x" + count;
            sprite.sprite = gi.ItemSprite;
            this.uiCargo = uiCargo;
            this.count = count;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void OnClick()
        {
            uiCargo.BuyItem(gameItem);
            count++;
            CountTitle.text = "x" + count;
        }
    }
}
