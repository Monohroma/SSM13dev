using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Storage;

namespace UI
{
    public class UICargoBuyButton : MonoBehaviour
    {
        public TMP_Text InfoTitle;
        public TMP_Text CostTitle;
        public GameItem item;
        private UICargo _Cargo;

        public void Setup(UICargo uic, GameItem i)
        {
            _Cargo = uic;
            item = i;
            InfoTitle.text = i.ItemName;
            CostTitle.text = i.ItemPrice+"";
        }

        public void OnClick()
        {
            _Cargo.DeliteBuy(this);
            Destroy(gameObject);
        }
    }
}
