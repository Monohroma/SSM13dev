using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ark;

public class UITopInfo : MonoBehaviour
{
    public TMP_Text moneyText;
    public TMP_Text energyText;
    public TMP_Text humansText;

    private void Update()
    {
        if (Energetics.Instance.StoredEnergy >= Energetics.Instance.MaxEnergy)
            energyText.color = Color.red;
        else
            energyText.color = Color.white;
        energyText.text = Energetics.Instance.StoredEnergy.ToString();
        moneyText.text = Economics.Instance.StoredMoney.ToString();
        humansText.text = GameManager.Instance.FreeAssistant.Count + $" /{GameManager.Instance.AllCrew.Count}";
    }
}
