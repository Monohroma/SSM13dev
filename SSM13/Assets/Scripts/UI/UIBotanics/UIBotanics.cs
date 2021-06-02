using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIBotanics : MonoBehaviour
    {
        public GameObject UIBotanicsPanelObj;
        public GameObject UIPlant2PanelPrefab;
        public RectTransform plantsTransform;
        public List<UICell> cells;
        public List<UIPlant2Panel> uip2p;
        public UISelectBar SelectBar;
        public MovingPanel movingPanel;
        private Botanics _botanics;

        private void Start()
        {
            SelectBar.Setup();
        }

        public void Show(Botanics botanics)
        {
            foreach (var item in uip2p)
            {
                Destroy(item.gameObject);
            }
            uip2p.Clear();
            cells.Clear();
            plantsTransform.sizeDelta = new Vector2(plantsTransform.sizeDelta.x, 0);
            UIBotanicsPanelObj.SetActive(true);
            _botanics = botanics;
            int i = 0;
            for (i=0;i<_botanics.Cells.Count;i+=2)
            {
                GameObject o = Instantiate(UIPlant2PanelPrefab, plantsTransform) as GameObject;
                if (i + 1 < botanics.Cells.Count)
                {
                    o.GetComponent<UIPlant2Panel>().SetupCells(this, _botanics.Cells[i], _botanics.Cells[i + 1]);
                }
                else
                {
                    o.GetComponent<UIPlant2Panel>().SetupCells(this, _botanics.Cells[i]);
                }
                uip2p.Add(o.GetComponent<UIPlant2Panel>());
                plantsTransform.sizeDelta += new Vector2(0, o.GetComponent<RectTransform>().sizeDelta.y);
            }
            movingPanel.ResetPosition();
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
