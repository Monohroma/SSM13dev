using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIBridge : MonoBehaviour
    {
        public GameObject UIKitchenPanelObj;
        public List<WorkManager> workersManager; // - На всякий случай

        private void Start()
        {
            foreach (var item in workersManager)
            {
                item.Setup(this);
            }
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
    }
}
