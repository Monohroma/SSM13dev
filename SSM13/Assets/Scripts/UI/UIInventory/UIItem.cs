using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Storage;

namespace UI
{
    public class UIItem : MonoBehaviour
    {
        public TMP_Text nameText;
        public Image img;
        public TMP_Text countText;
        private GameItem _currentItem;

        public void Setup(GameItem gi)
        {
            _currentItem = gi;
            UpdateParametrs();
        }

        public void UpdateParametrs()
        {
            if (_currentItem != null)
            {
                img.color = new Color(1, 1, 1, 1);
                nameText.text = _currentItem.ItemName;
                img.sprite = _currentItem.ItemSprite;
                countText.text = $"x{_currentItem.ItemCount}";
            }
        }

        public void Deactive()
        {
            _currentItem = null;
            nameText.text = "Пусто";
            img.sprite = null;
            img.color = new Color(1, 1, 1, 0);
            countText.text = "";
        }
    }
}
