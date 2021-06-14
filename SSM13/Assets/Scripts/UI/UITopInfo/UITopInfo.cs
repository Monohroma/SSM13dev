using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ark;
namespace UI
{
    public class UITopInfo : MonoBehaviour
    {
        public TMP_Text moneyText;
        public TMP_Text energyText;
        public TMP_Text humansText;


        private void Awake()
        {
            Energetics.Instance.EnergyChanged += UpdateEnergy;
            Economics.Instance.MoneyChanged += UpdateMoney;
        }
        private void Start()
        {
            UpdateEnergy(Energetics.Instance.StoredEnergy);
            UpdateMoney(Economics.Instance.StoredMoney);
        }

        private void UpdateEnergy(int power)
        {
            if (Energetics.Instance.StoredEnergy >= Energetics.Instance.MaxEnergy)
            {
                energyText.color = Color.red;
            }
            else
            {
                energyText.color = Color.white;
            }
            energyText.text = power.ToString();
        }

        private void UpdateMoney(int money)
        {
            moneyText.text = money.ToString();
        }

        private void UpdateCrew(int count)
        {
            throw new NotImplementedException();
        }

        private void Update()
        {
            // ¬сЄ что св€зано с персоналом реализовано через дикий говнокод, так что не стал это убирать, чтобы ничего не сломалось.
            humansText.text = $"{GameManager.Instance.FreeAssistant.Count}/{GameManager.Instance.AllCrew.Count}";
        }
    }
}
