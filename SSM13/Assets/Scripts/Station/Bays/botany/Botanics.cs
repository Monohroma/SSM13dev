using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ark;
using Storage;
using UI;

public class Botanics : Bay
{   [SerializeField]
    public Cell[] Cells;
    // Вы серъёзно хотите вот так прописывать каждое растение?
    public Plant Tomato;
    public Plant Potato; 
    
    private void FixedUpdate()
    {
        foreach (var item in Cells)
        {
            if(item.CurrentPlant != null)
            {
                if(item.UpdatePlant(Time.fixedDeltaTime))
                {
                    Inventory.Instance.AddItem(item.CurrentPlant);
                    item.SetPlant(item.CurrentPlant);
                }
            }
        }
    }

    public void ShowMenu()
    {
        UIManager.ShowBotanicsMenu(this);
    }
}
