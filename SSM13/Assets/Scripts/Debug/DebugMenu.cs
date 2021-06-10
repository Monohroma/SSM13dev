using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ark;

public class DebugMenu : MonoBehaviour
{
    public Text MoneyText;
    Economics _economics;

    private void Start()
    {
        _economics = Economics.Instance;
    }
    public void debugAddMoney(int MoneyCount)
    {
        _economics.AddMoney(MoneyCount);
        MoneyText.text = _economics.StoredMoney.ToString();
    }
}
