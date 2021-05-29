using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UICell : MonoBehaviour
    {
        private Cell _cell;
        private Sprite standartSprite;
        public Text plantNameTitle;
        public Image plantImage;
        public Slider growingBar;
        public GameObject onSelectBackground;
        public RectTransform rectTransform;
        public Cell CurentCell => _cell;
        public void Setup(Cell cell)
        {
            if (standartSprite == null)
                standartSprite = plantImage.sprite;
            _cell = cell;
            rectTransform = GetComponent<RectTransform>();
            if (cell.CurrentPlant != null)
            {
                plantImage.enabled = true;
                plantNameTitle.text = cell.CurrentPlant.ItemName;
                plantImage.sprite = cell.CurrentPlant.ItemSprite;
                growingBar.value = cell.GetProgress();
                growingBar.gameObject.SetActive(true);
            }
            else
                plantImage.enabled = false;
        }

        public void Clear()
        {
            plantImage.sprite = standartSprite;
            plantNameTitle.text = "Пусто";
            growingBar.gameObject.SetActive(false);
            _cell = null;
        }

        public void UpdateValues()
        {
            if(_cell != null)
                growingBar.value = _cell.GetProgress();
        }

        public void ShowBackground()
        {
            onSelectBackground.SetActive(true);
        }

        public void HideBackground()
        {
            onSelectBackground.SetActive(false);
        }

        public void OnClick()
        {
            UIManager.Instance.BotanicsBayMenu.ShowSelectBar(this);
        }
    }
}