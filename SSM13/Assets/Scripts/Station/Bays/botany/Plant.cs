using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Storage;
[CreateAssetMenu(menuName = "Item/PlantItem", fileName = "New Plant")]
public class Plant : GameItem
{
    [Header("Not debug, you can change it")]
    [SerializeField] private float GrowingTime;
    [SerializeField] private int NumberOfGrowths;
    [SerializeField] private int HarvestAmount;
    [SerializeField] private int Nutritional;

    public float _GrowingTime => GrowingTime;
    public int _NumberOfGrowths => NumberOfGrowths;
    public int _HarvestAmount => HarvestAmount;
    public int _Nutritional => Nutritional;



}
