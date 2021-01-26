using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants
{
    public string Name { get;set; }
    public float GrowingTime { get; set; }
    public int Cost { get;set; }
    public int NumberOfGrowths { get;set; } //То, сколько раз можно собрать
    public int HarvestAmount { get;set; } //Кол-во получаемых предметов после сбора
    public ITEMNAME ItemName;

    
}
