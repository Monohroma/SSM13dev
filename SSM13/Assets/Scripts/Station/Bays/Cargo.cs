using System;
using System.Collections;
using System.Collections.Generic;
using Ark;
using Storage;
using UnityEngine;
using UnityEngine.UI;


public class Cargo : Ark.Bay
{
    // ================ fields ================
    [Header("System setup")]
    public Transform spawn;
    public GameObject Assistent;


    // DON'T use GameItem from assets!!!
    
    
    // ================ inventory ================
    private Inventory _inventory;
    private GameItem _item;
    private Economics _economics;
    
    private void Awake()
    {
        _inventory = Inventory.Instance;
        _economics = Economics.Instance;
    }

    private void Start()
    {
        string a = _inventory.dev_ShowInfo();
        print(a);
    }

    // ================ methods ================
    public void BuyItem(string nameItem, int cost)
    {
        if (_economics.SubtractMoney(cost))
        {
            _inventory.AddItem(_inventory.GetItem(nameItem));
        }
        else Debug.Log("Денег нет!");
    }

}
