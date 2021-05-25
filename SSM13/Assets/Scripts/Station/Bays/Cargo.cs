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

    public void Sell(int s)
    {
        GameItem gameItem = _inventory.GetItem(s);
        if (gameItem != null)
        {
            try
            {
                _inventory.SubtractItem(s, 1);
                _economics.AddMoney(gameItem.ItemPrice);
            }
            catch(Exception e)
            {
                Debug.Log(e);
            }
        }
    }

    public void Sell(string s)
    {
        GameItem gameItem = _inventory.GetItem(s);
        if (gameItem != null)
        {
            try
            {
                _inventory.SubtractItem(gameItem.ItemID, 1);
                _economics.AddMoney(gameItem.ItemPrice);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
    }

    public void Buy(int s)
    {
        GameItem gameItem = _inventory.GetItem(s);
        BuyItem(gameItem.ItemName, gameItem.ItemPrice);
    }

    public void BuyCrew(int cost)
    {
        if(_economics.SubtractMoney(cost))
        {
            Instantiate(Assistent, spawn.position, Quaternion.identity);
        }
        else Debug.Log("Денег нет!");
    }

    public void TestAddPotato()
    {
        _inventory.AddItem(0, 100);
    }

}
