using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Storage;
using Ark;

public class ShowInventory : MonoBehaviour
{
    public TextMeshProUGUI MoneyT;
    public TextMeshProUGUI textComponent;
    public Economics economics;
    // Update is called once per frame
    private void Awake()
    {
        economics = Economics.Instance;
    }
    void Update()
    {
        string defaultString = "В ИНВЕНТАРЕ\n";
        var invtntory = Inventory.Instance;

        MoneyT.text = economics.StoredMoney.ToString();
    }
}
