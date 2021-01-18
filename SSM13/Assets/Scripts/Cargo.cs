using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cargo : MonoBehaviour
{
    public InventoryManager inventory;
    public Station station;
    public void Buy(int name)// покупка предметов с цк
    {
        Item thing = inventory.GetItem((ITEMNAME)name);

        if (thing.Price <= station.Money)
        {
            thing.Count++;
            station.TakeMoney(thing.Price);
        }
        else
        {
            Debug.Log("денег нет");
        }
    }
    public void Sell(int name)// продажа предметов на цк
    {
        Item thing = inventory.GetItem((ITEMNAME)name);

        if (thing.Count > 0)
        {
            thing.Count--;
            station.AddMoney(thing.Price - 5);
        }
        else
        {
            Debug.Log("денег нет");
        }
    }
}
