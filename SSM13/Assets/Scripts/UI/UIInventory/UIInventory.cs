using Storage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIInventory : MonoBehaviour
    {
        public GameObject UIEngineeringPanelObj;
        public List<UIItem> uiItems;
        public MovingPanel movingPanel;
        public void Show()
        {
            movingPanel.ResetPosition();
            UIEngineeringPanelObj.SetActive(true);
            GameItem[] gitems = Inventory.Instance.GetAllItems();
            int i = 0;
            for(i=0;i<gitems.Length&&i<uiItems.Count;i++)
            {
                uiItems[i].Setup(gitems[i]);
            }
            for(;i<uiItems.Count;i++)
            {
                uiItems[i].Deactive();
            }
        }

        private void FixedUpdate()
        {
            foreach (var item in uiItems)
            {
                item.UpdateParametrs();
            }
        }

        public void Hide()
        {
            UIEngineeringPanelObj.SetActive(false);
        }
    }
}
