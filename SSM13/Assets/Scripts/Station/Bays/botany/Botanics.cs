using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botanics : MonoBehaviour
{   [SerializeField]
    Cell[] Cells;
    Plants Tomato;
    Plants Potato; 
    
    void Start()
    {
     
        Tomato = new Plants() { Name = "Tomato", GrowingTime = 35, Cost = 15, NumberOfGrowths = 2, HarvestAmount = 4, ItemName = ITEMNAME.TOMATO };
        Potato = new Plants() { Name = "Potato", GrowingTime = 60, Cost = 35, NumberOfGrowths = 1, HarvestAmount = 7, ItemName = ITEMNAME.POTATO };
        Cells =  GetComponentsInChildren<Cell>();
    }

    void Update()
    {
       
    }
    public void TomatoButton()
    {
        for (int i = 0; i < Cells.Length; i++)
        {
           if(Cells[i].Completed)
            {
                Cells[i].SetPlant(Tomato);
                break;
            }  
        }
    }
    public void PotatoButton()
    {
        for (int i = 0; i < Cells.Length; i++)
        {
            if (Cells[i].Completed)
            {
                Cells[i].SetPlant(Potato);
                break;
            }
        }
    }
}
