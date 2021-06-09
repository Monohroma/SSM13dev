using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UI
{
    public class UICargoCategoryButton : MonoBehaviour
    {
        private UICargo _UICargo;
        public TMP_Text CategoryTitle;
        public string category;

        public void Setup(UICargo uic, string category)
        {
            this.category = category;
            _UICargo = uic;
            CategoryTitle.text = category;
        }

        public void OnClick()
        {
            _UICargo.SelectCategoty(category);
        }
    }
}
