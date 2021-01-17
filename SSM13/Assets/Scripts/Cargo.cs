using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cargo : MonoBehaviour
{
    public InventoryManager inventory;
    public uint Buy(uint Price, uint Count, ITEMNAME name)// покупка предметов с цк
    {
        uint money = 0;

        return money;
    }
    public uint Sell(uint Price, uint Count, ITEMNAME name)// продажа предметов на цк
    {
        uint money = 0;

        return money;
    }
    
   /* public Item CheckInventory(ITEMNAME thingName)// проверка инвентаря
    {
        Item thing;
        foreach (Item obj in inventory.items)
        {
          if(thingName == obj.Name)
          {
                thing = obj;
          }
        return thing;
        }
        
    } */
}
