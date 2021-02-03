using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botanics : MonoBehaviour
{   [SerializeField]
    Cell[] Cells;
  public Plants Tomato;
  public Plants Potato; 
    
    void Start()
    {
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
