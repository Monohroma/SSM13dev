using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIBotanics : MonoBehaviour
    {
        public GameObject UIBotanicsPanelObj;
        public List<UICell> cells;
        public UISelectBar SelectBar;
        private Botanics _botanics;

        private void Start()
        {
            SelectBar.Setup();
        }

        public void Show(Botanics botanics)
        {
            UIBotanicsPanelObj.SetActive(true);
            if (_botanics != null)
            {
                foreach (var item in cells)
                {
                    item.Clear();
                }
            }
            _botanics = botanics;
            for(int i=0;i<_botanics.Cells.Count && i<cells.Count;i++)
            {
                cells[i].Setup(_botanics.Cells[i]);
            }
        }

        private void FixedUpdate()
        {
            foreach (UICell cell in cells)
            {
                cell.UpdateValues();
            }
        }

        public void ShowSelectBar(UICell uicell)
        {
            SelectBar.Show(uicell);
        }

        public void Hide()
        {
            SelectBar.Hide();
            UIBotanicsPanelObj.SetActive(false);
        }
    }
}
