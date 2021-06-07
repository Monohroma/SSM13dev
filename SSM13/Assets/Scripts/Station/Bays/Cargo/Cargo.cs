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
    public List<string> SellList = new List<string>();
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
    public void BuyItem(string nameItem)
    {
        if (_economics.SubtractMoney(_inventory.GetItem(nameItem).ItemPrice) && _availablePlaces.Count < ShopList.Count)
        {
             ShopList.Add(nameItem);
           // _inventory.AddItem(_inventory.GetItem(nameItem)); легаси код
        }
        else Debug.Log("Денег не хватит! или нету места в списке покупок!");
    }

   /* public void Sell(int s) 
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
    } */

    public void SellItem(string item)
    {
        GameItem gameItem = _inventory.GetItem(item);
        if (gameItem != null && gameItem.ItemCount > 0 && _availablePlaces.Count < SellList.Count)
        {
            SellList.Add(item);
            //_inventory.SubtractItem(item, 1); удаляет 1 предмет из инвентаря, пусть пока тут будет
        }
        else
        {
            Debug.Log("нету предмета, или он не существует или нету места в карго шатле");
        }
    }

   /* public void Buy(int s) легаси код
    {
        GameItem gameItem = _inventory.GetItem(s);
        BuyItem(gameItem.ItemName, gameItem.ItemPrice);
    }
   */ 
    public void BuyCrew(int cost) // будет тоже переписано аналогично с BuyItem, но попозже
    {
        if(_economics.SubtractMoney(cost))
        {
            Debug.Log("Асистент был успешно куплен");
           // Instantiate(Assistent, spawn.position, Quaternion.identity); легаси код
        }
        else Debug.Log("Денег нет!");
    }

    public void TestAddPotato() // это вообще по хорошему надо в дебаг меню перенести
    {
        _inventory.AddItem(0, 100);
    }

    public void ShowMenu()
    {
        if (Purchased)
        {
            UIManager.ShowInventoryMenu();
        }
        else
        {
            BuyBay();
        }
    }

    public void CargoShuttleCall(bool arive)
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
            foreach (GameObject Objects in CargoObjects)
            {
                ShopList.Add(Objects.name); // ну не пропадать же добру
                _economics.AddMoney(_inventory.GetItem(Objects.name).ItemPrice); // полноразмерный кэшбэк за незаюзанные покупки
                Destroy(Objects); // тоесть если не дождаться пока рабочий донесёт предмет до склада, то при отзыве шатла этот предмет тупо пропадёт O_o придумаю позже как это пофиксить
            }
            // так же тут должны зачисляться деньги за все предметы отправленные на продажу и погруженные на шатл. и это будут сдланы NPC гружчиков.
            ShuttleArrive = false;
            CargoShuttle.SetActive(ShuttleArrive);
        }
    }
    IEnumerator CargoShuttleArrive(float seconds)
    {
        yield return new WaitForSeconds(seconds); // таймер прилёта шатла
        ShuttleArrive = true;
        CargoShuttle.SetActive(ShuttleArrive); 
        GameItem TempItem;
        for (int n = 0; n <= ShopList.Count; n++)
        {
                TempItem = _inventory.GetItem(ShopList[n]);
                _economics.SubtractMoney(TempItem.ItemPrice);
                CargoItem.name = ShopList[n];
                CargoItem.GetComponent<SpriteRenderer>().sprite = TempItem.ItemSprite;
                CargoObjects.Add(Instantiate(CargoItem, _availablePlaces[n], Quaternion.identity)); // спавним префаб с измененным спрайтом и именем
        }
        ShopList.Clear(); // ну мы же всё купили, значит и в списке покупок это нам не нужно
        
    }


}
