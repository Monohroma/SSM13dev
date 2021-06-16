using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ark;
using Storage;

namespace UI
{
    public class UIDebug : MonoBehaviour
    {
        public GameObject debugObj;
        public TMP_InputField moneyInput;
        public TMP_InputField energyInput;
        public Toggle toggle;
        public TMP_InputField itemInput;
        public TMP_InputField countInput;
        float time = 0;
        int energ = 0;

        public void AddMoney()
        {
            Economics.Instance.AddMoney(int.Parse(moneyInput.text));
        }

        public void RemoveMoney()
        {
            Economics.Instance.SubtractMoney(int.Parse(moneyInput.text));
        }

        public void AddEnergy()
        {
            if (toggle.isOn)
                energ = int.Parse(energyInput.text);
            else
                Energetics.Instance.AddEnergy(int.Parse(energyInput.text));
        }

        public void RemoveEnergy()
        {
            if (toggle.isOn)
                energ = -int.Parse(energyInput.text);
            else
                Energetics.Instance.SubtractEnergy(int.Parse(energyInput.text));
        }

        public void AddItem()
        {
            Inventory.Instance.AddItem(int.Parse(itemInput.text), int.Parse(countInput.text));
        }

        public void RemoveItem()
        {
            Inventory.Instance.SubtractItem(int.Parse(itemInput.text), int.Parse(countInput.text));
        }

        private void Update()
        {
            if(time + Energetics.Instance.UpdateGeneratersDelay <= Time.time)
            {
                time = Time.time;
                if(energ >= 0)
                {
                    Energetics.Instance.AddEnergy(energ);
                }
                else
                {
                    Energetics.Instance.SubtractEnergy(-energ);
                }
            }
            if(Input.GetKeyDown(KeyCode.F11))
            {
                debugObj.SetActive(!debugObj.activeSelf);
            }
        }
    }
}