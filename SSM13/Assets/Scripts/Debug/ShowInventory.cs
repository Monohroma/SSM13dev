using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Storage;

public class ShowInventory : MonoBehaviour
{
    public TextMeshProUGUI MoneyT;
    public TextMeshProUGUI textComponent;
    public Station station;

    // Update is called once per frame
    void Update()
    {
        string defaultString = "В ИНВЕНТАРЕ\n";
        var invtntory = Inventory.Instance;

        MoneyT.text = station.Money.ToString();
    }
}
