using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ark;
using TMPro;
namespace UI
{
    public class UIEngineering : MonoBehaviour
    {
        public GameObject UIEngineeringPanelObj;
        public RectTransform panels_point;
        public GameObject panel_prefab;
        public List<UIEngineeringPanel> engineeringPanels;
        public Slider battery;
        public TMP_Text in_power;
        public TMP_Text out_power;
        public Power power;
        public MovingPanel movingPanel;

        private void Awake()
        {
            GameManager.Instance.OnBayAdd += OnBayAdd;
            GameManager.Instance.OnBayRemove += OnBayRemove;
        }

        private void OnBayAdd(Bay bay)
        {
            GameObject o = Instantiate(panel_prefab, panels_point) as GameObject;
            o.GetComponent<UIEngineeringPanel>().Setup(bay);
            engineeringPanels.Add(o.GetComponent<UIEngineeringPanel>());
            panels_point.sizeDelta += new Vector2(0, o.GetComponent<RectTransform>().sizeDelta.y);
        }

        private void OnBayRemove(Bay bay)
        {
            UIEngineeringPanel uiep = engineeringPanels.Find(x => x.bay_orig == bay);
            panels_point.sizeDelta -= new Vector2(0, uiep.GetComponent<RectTransform>().sizeDelta.y);
            Destroy(uiep.bay_orig.gameObject);
            engineeringPanels.Remove(uiep);
        }

        public void BuySolarPanel()
        {
            power.BuySolar();
        }

        private void FixedUpdate()
        {
            foreach (var item in engineeringPanels)
            {
                item.UpdateParametrs();
            }
            battery.value = (float)Energetics.Instance.StoredEnergy / (float)Energetics.Instance.MaxEnergy;
            in_power.text = Power.WattText(Energetics.Instance.InEnergy);
            out_power.text = Power.WattText(Energetics.Instance.OutEnergy);
        }

        public void Show()
        {
            UIEngineeringPanelObj.SetActive(true);
            movingPanel.ResetPosition();
        }

        public void Hide()
        {
            UIEngineeringPanelObj.SetActive(false);
        }
    }
}
