using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botanics : MonoBehaviour
{   [SerializeField]
    Cell[] Cells;
    Plants Tomato; // 110-220             "Tomato",/* 180*/5, 55, 3, 0.10f, 2/* Random.Range(2,4)*/
    Plants Potato; //175-245            "Potato", 360, 35, 1, 0.2f, 2/* Random.Range(5,7)*/
    
    void Start()
    {

        Tomato = new Plants() { Name = "Tomato", GrowingTime = 5, Cost = 55, NumberOfGrowths = 3, HarvestAmount = 4, ItemName = ITEMNAME.TOMATO };
        Potato = new Plants() { Name = "Potato", GrowingTime = 5, Cost = 55, NumberOfGrowths = 3, HarvestAmount = 4, ItemName = ITEMNAME.POTATO };
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
                Debug.Log(Tomato);
                Cells[i].SetPlant(Tomato);
                break;
            }  
        }
    }
}
