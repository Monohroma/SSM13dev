using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ark;
using Storage;
using UI;

public class Botanics : Bay
{   [SerializeField]
    public Cell[] Cells;
    // Вы серьёзно хотите вот так прописывать каждое растение?
    public Plant Tomato;
    public Plant Potato; 
    
    private void FixedUpdate()
    {
        foreach (Cell cell in Cells)
        {
            if(cell.CurrentPlant != null)
            {
                if(cell.UpdatePlant(Time.fixedDeltaTime))
                {
                    Inventory.Instance.AddItem(cell.CurrentPlant, cell.CurrentPlant._HarvestAmount);
                    cell.SetPlant(cell.CurrentPlant);
                }
            }
        }
    }

    public void ShowMenu()
    {
        UIManager.ShowBotanicsMenu(this);
    }
}
