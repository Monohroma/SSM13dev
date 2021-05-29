using Storage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class UISelectBar : MonoBehaviour, IPointerExitHandler
    {
        public List<UISelectPlant> selectPlantsUI;
        public HorizontalLayoutGroup horizontalLayout;
        public RectTransform contentTransform;
        public GameObject panelPrefab;
        private List<Plants> plants = new List<Plants>();
        private RectTransform rectTransform;
        private UICell _currentCell;
        public void Setup()
        {
            rectTransform = GetComponent<RectTransform>();
            GameItem[] gi = GameItemDatabase.GetItems();
            foreach (var item in gi)
            {
                if (item is Plants)
                {
                    plants.Add((Plants)item);
                    GameObject o = Instantiate(panelPrefab, contentTransform) as GameObject;
                    o.GetComponent<UISelectPlant>().Setup((Plants)item, this);
                    selectPlantsUI.Add(o.GetComponent<UISelectPlant>());
                }
            }
        }

        public void Show(UICell cell)
        {
            gameObject.SetActive(true);
            _currentCell = cell;
            cell.ShowBackground();
            rectTransform.anchoredPosition = _currentCell.rectTransform.anchoredPosition;
            if (cell.CurentCell.CurrentPlant != null)
            {
                selectPlantsUI.ForEach(x => x.gameObject.SetActive(!(x.plant.ItemID==cell.CurentCell.CurrentPlant.ItemID))); //Скрыть уже использующийся UICell
                contentTransform.sizeDelta = new Vector2(horizontalLayout.padding.left + horizontalLayout.padding.right + Mathf.Max(plants.Count - 2, 0) * horizontalLayout.spacing + panelPrefab.GetComponent<RectTransform>().sizeDelta.x * (plants.Count - 1), contentTransform.sizeDelta.y);
            }
            else
            {
                selectPlantsUI.ForEach(x => x.gameObject.SetActive(true)); // Показать все UICell
                contentTransform.sizeDelta = new Vector2(horizontalLayout.padding.left + horizontalLayout.padding.right + Mathf.Max(plants.Count - 1, 0) * horizontalLayout.spacing + panelPrefab.GetComponent<RectTransform>().sizeDelta.x * plants.Count, contentTransform.sizeDelta.y);
            }
        }

        public void Hide()
        {
            if (_currentCell != null)
                _currentCell.HideBackground();
            _currentCell = null;
            gameObject.SetActive(false);
        }

        private void LateUpdate()
        {
            if(_currentCell != null)
            {
                rectTransform.anchoredPosition = _currentCell.rectTransform.anchoredPosition;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Hide();
        }

        public void Select(UISelectPlant uisp)
        {
            _currentCell.CurentCell.SetPlant(uisp.plant);
            _currentCell.Setup(_currentCell.CurentCell);
            Hide();
        }
    }
}
