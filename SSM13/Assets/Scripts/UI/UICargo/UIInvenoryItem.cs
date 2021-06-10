using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Storage;

namespace UI
{
    public class UIInvenoryItem : MonoBehaviour
    {
        public Image image;
        public TMP_Text itemText;
        private GameItem gameItem;

        public void Setup(GameItem gi)
        {
            gameItem = gi;
            image.sprite = gi.ItemSprite;
            itemText.text = gi.ItemCount+"";
        }

        public void UpdateCount(GameItem gi)
        {
            gameItem.SetCount(gi.ItemCount);
            itemText.text = gameItem.ItemCount + "";
        }
    }
}
