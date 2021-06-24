using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ark;

namespace UI
{
    public class UIBridge : MonoBehaviour
    {
        public GameObject UIKitchenPanelObj;
        public List<WorkManager> workersManager; // - Õ‡ ‚ÒˇÍËÈ ÒÎÛ˜‡È
        public Image buttonImage;
        public TMP_Text buttonText;
        public TMP_Dropdown dropdown;
        public Color enabledColor;
        public Color disabledColor;
        List<Bay> optionsBay = new List<Bay>();

        private void Start()
        {
            foreach (var item in workersManager)
            {
                item.Setup(this);
            }
            dropdown.options.Clear();
            int i = 0;
            foreach (var item in GameManager.Instance.currentBays)
            {
                dropdown.options.Add(new TMP_Dropdown.OptionData(item.BayName));
                if (item.Type == BayTypes.Bridge)
                    i = optionsBay.Count;
                optionsBay.Add(item);
            }
            dropdown.value = i;
            OnSelectBay(0);
        }

        public void Show()
        {
            UIKitchenPanelObj.SetActive(true);
        }

        public void Hide()
        {
            UIKitchenPanelObj.SetActive(false);
        }

        public void UpdateParams()
        {
            foreach (var item in workersManager)
            {
                item.UpdateText();
            }
        }

        public void UpdateAlert()
        {
            if (GameManager.Instance.alertLevel == AlertLevel.GREEN_ALERT)
                GameManager.Instance.alertLevel = AlertLevel.RED_ALERT;
            else
                GameManager.Instance.alertLevel = AlertLevel.GREEN_ALERT;
        }

        public void OnSelectBay(int t)
        {
            GameManager.Instance.safeBay = optionsBay[dropdown.value];
        }

        private void FixedUpdate()
        {
            if(GameManager.Instance.alertLevel == AlertLevel.GREEN_ALERT)
            {
                buttonImage.color = enabledColor;
                buttonText.text = "“–≈¬Œ√¿";
            }
            else
            {
                buttonImage.color = disabledColor;
                buttonText.text = "Œ“Ã≈Õ»“‹";
            }
        }
    }
}
