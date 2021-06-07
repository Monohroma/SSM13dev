using System;
using System.Collections;
using System.Collections.Generic;
using Ark;
using Storage;
using UnityEngine;
using UnityEngine.UI;
using UI;

public class Cargo : Bay
{
    // ================ fields ================
    [Header("System setup")]
    public List<string> ShopList = new List<string>();
    private List<GameObject> CargoObjects = new List<GameObject>();
    private List<Vector3> _availablePlaces;
    public bool ShuttleArrive = false;
    public GameObject CargoItem;
    public GameObject CargoShuttle;
   // public Transform spawn; легаси код
   // public GameObject Assistent; легаси код


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

    protected override void Start()
    {
        base.Start();
        string a = _inventory.dev_ShowInfo();
        print(a);
        _availablePlaces = GetComponent<CargoShuttle>().availablePlaces;
        CargoShuttle.SetActive(ShuttleArrive);
    }
    // ================ methods ================
    public void BuyItem(string nameItem, int cost)
    {
        if (_economics.SubtractMoney(cost) && _availablePlaces.Count < ShopList.Count)
        {
             ShopList.Add(nameItem);
           // _inventory.AddItem(_inventory.GetItem(nameItem)); легаси код
        }
        else Debug.Log("Денег нет! или места в списке покупок!");
    }

    public void Sell(int s) // будет тоже переписано аналогично с BuyItem, но попозже
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

    public void Sell(string s) // будет тоже переписано аналогично с BuyItem, но попозже
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

    public void BuyCrew(int cost) // будет тоже переписано аналогично с BuyItem, но попозже
    {
        if(_economics.SubtractMoney(cost))
        {
           // Instantiate(Assistent, spawn.position, Quaternion.identity); легаси код
        }
        else Debug.Log("Денег нет!");
    }

    public void TestAddPotato()
    {
        _inventory.AddItem(0, 100);
    }

    public void ShowMenu()
    {
        UIManager.ShowInventoryMenu();
    }

    public void CallShuttle(bool arive)
    {
        if (!arive)
        {
            StartCoroutine(CargoShuttleArrive(10));        
        }
    }
    public void CargoShuttleDeparture(bool arive)
    {
        if (arive)
        {
            foreach (var Objects in CargoObjects)
            {
                Destroy(Objects);
            }
            ShuttleArrive = false;
            CargoShuttle.SetActive(ShuttleArrive);
        }
    }
    IEnumerator CargoShuttleArrive(float seconds)
    {
        yield return new WaitForSeconds(seconds); // таймер прилёта шатла
        ShuttleArrive = true;
        CargoShuttle.SetActive(ShuttleArrive); 
        GameItem TempItem; // временный предмет для получения спрайта предмета
        for (int n = 0; n <= ShopList.Count; n++)
        {
                TempItem = _inventory.GetItem(ShopList[n]);
                CargoItem.name = ShopList[n];
                CargoItem.GetComponent<SpriteRenderer>().sprite = TempItem.ItemSprite;
                CargoObjects.Add(Instantiate(CargoItem, _availablePlaces[n], Quaternion.identity)); // спавним префаб с измененным спрайтом и именем
        }
        ShopList.Clear();
        
    }


}
