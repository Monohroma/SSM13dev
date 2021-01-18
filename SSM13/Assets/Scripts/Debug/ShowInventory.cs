using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowInventory : MonoBehaviour
{
    public TextMeshProUGUI MoneyT;
    public TextMeshProUGUI textComponent;
    public InventoryManager inventory;
    public Station station;

    // Update is called once per frame
    void Update()
    {
        string defaultString = "В ИНВЕНТАРЕ\n";
        foreach (KeyValuePair<ITEMNAME, Item> obj in inventory.items)
		{
            defaultString += string.Format("{0}: {1}\n", obj.Key.ToString(), obj.Value.Count);
		}
        textComponent.text = defaultString;
        MoneyT.text = station.Money.ToString();
    }
}
