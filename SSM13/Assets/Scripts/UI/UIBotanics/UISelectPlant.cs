using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UISelectPlant : MonoBehaviour
    {
        public Plants plant;
        public Text plantName;
        public Image image;
        private UISelectBar _uisb;
        public void Setup(Plants currentPlant, UISelectBar uisb)
        {
            plant = currentPlant;
            plantName.text = currentPlant.ItemName;
            image.sprite = currentPlant.ItemSprite;
            _uisb = uisb;
        }

        public void Select()
        {
            _uisb.Select(this);
        }
    }
}
