using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Storage;
using Ark;

namespace UI
{
    public class UICargo : MonoBehaviour
    {
        public GameObject UIKitchenPanelObj;
        public TMP_Text moneyTitle;
        public TMP_Text shuttleTitle;
        public RectTransform categoryContent;
        public GameObject catergotyPrefab;
        public RectTransform packetsContent;
        public GameObject packetPrefab;
        public List<UICargoBuyButton> uicbbs;
        public GameObject BuyItemsPanel;
        public List<UIItem> UIItems;
        public TMP_Text categoryTitle;
        public TMP_Text fullCost;
        public Dictionary<int, UIInvenoryItem> uiiis = new Dictionary<int, UIInvenoryItem>();
        public GameObject uiiiPrefab;
        public RectTransform uiiiContent;
        private List<GameItem> gameItems = new List<GameItem>();
        private Cargo currentCargo;

        private void Start()
        {
            gameItems = GameItemDatabase.GetListItems();
            List<string> categoryes = new List<string>();
            categoryes.Add("Все");
            foreach (var item in gameItems)
            {
                if(!categoryes.Contains(item.ItemCategory))
                {
                    categoryes.Add(item.ItemCategory);
                }
            }
            foreach (var item in categoryes)
            {
                GameObject o = Instantiate(catergotyPrefab, categoryContent) as GameObject;
                o.GetComponent<UICargoCategoryButton>().Setup(this, item);
            }
            Inventory.OnAddItem += OnItemAdd;
            Inventory.OnRemoveItem += OnItemRemove;
        }

        public void Show(Cargo cargo)
        {
            UIKitchenPanelObj.SetActive(true);
            currentCargo = cargo;
            ReloadBuyList();
            UpdateInventoryList();
        }

        public void Hide()
        {
            UIKitchenPanelObj.SetActive(false);
        }

        public void SelectCategoty(string category)
        {
            GameItem[] gi = GameItemDatabase.GetItems();
            int i = 0, j = 0;
            for (i=0,j=0;i<gi.Length&&j<UIItems.Count;i++)
            {
                if (gi[i].ItemCategory==category||category=="Все")
                {
                    UIItems[j].Setup(this, gi[i], currentCargo.ShopList.FindAll(x => x == gi[i].ItemName).Count);
                    j++;
                }
            }
            for(;j<UIItems.Count;j++)
            {
                UIItems[j].Hide();
            }
            categoryTitle.text = category;
            BuyItemsPanel.SetActive(true);
        }

        public void HideSelectCategory()
        {
            ReloadBuyList();
            BuyItemsPanel.SetActive(false);
        }

        public void ReloadBuyList()
        {
            foreach (var item in uicbbs)
            {
                Destroy(item.gameObject);
            }
            uicbbs.Clear();
            packetsContent.sizeDelta = new Vector2(packetsContent.sizeDelta.x, 0);
            List<string> items = currentCargo.ShopList;
            int c = 0;
            foreach (var item in items)
            {
                GameItem gi = Inventory.Instance.GetItem(item);
                GameObject o = Instantiate(packetPrefab, packetsContent) as GameObject;
                o.GetComponent<UICargoBuyButton>().Setup(this, gi);
                uicbbs.Add(o.GetComponent<UICargoBuyButton>());
                packetsContent.sizeDelta += new Vector2(0, o.GetComponent<RectTransform>().sizeDelta.y);
                c += gi.ItemPrice;
            }
            fullCost.text = c + "";
        }

        public void DeliteBuy(UICargoBuyButton uicbb)
        {
            currentCargo.RemoveItemFromShopList(uicbb.item);
            packetsContent.sizeDelta -= new Vector2(0, uicbb.GetComponent<RectTransform>().sizeDelta.y);
            uicbbs.Remove(uicbb);
            Destroy(uicbb.gameObject);
        }

        public void GetShuttle()
        {
            ReloadBuyList();
            currentCargo.CargoShuttleCall(false);
        }

        public void SendShuttle()
        {
            ReloadBuyList();
            currentCargo.CargoShuttleDeparture(true);
        }

        public void BuyItem(GameItem gi)
        {
            currentCargo.AddItemToShopList(gi);
        }

        public void UpdateInventoryList()
        {
            foreach (var item in uiiis)
            {
                Destroy(item.Value.gameObject);
            }
            uiiis.Clear();
            foreach (var item in Inventory.Instance.GetItems())
            {
                Debug.Log(item.ItemCount + " - t");
                if(item.ItemCount>0)
                    AddItemObj(item);
            }
        }

        public void OnItemAdd(GameItem gi)
        {
            if (uiiis.ContainsKey(gi.ItemID))
            {
                Debug.Log(gi.ItemCount);
                uiiis[gi.ItemID].UpdateCount(gi);
            }
            else
            {
                AddItemObj(gi);
            }
        }

        public void OnItemRemove(GameItem gi)
        {
            if (uiiis.ContainsKey(gi.ItemID))
            {
                if (gi.ItemCount > 0)
                {
                    uiiis[gi.ItemID].UpdateCount(gi);
                }
                else
                {
                    RemoveItemObj(gi);
                }
            }
        }

        public void AddItemObj(GameItem gi)
        {
            if (!uiiis.ContainsKey(gi.ItemID))
            {
                GameObject o = Instantiate(uiiiPrefab, uiiiContent) as GameObject;
                o.GetComponent<UIInvenoryItem>().Setup(gi);
                uiiis.Add(gi.ItemID, o.GetComponent<UIInvenoryItem>());
            }
        }

        public void RemoveItemObj(GameItem gi)
        {
            if (uiiis.ContainsKey(gi.ItemID))
            {
                Destroy(uiiis[gi.ItemID].gameObject);
                uiiis.Remove(gi.ItemID);
            }
        }

        private void FixedUpdate()
        {
            moneyTitle.text = Economics.Instance.StoredMoney + "";
            if (currentCargo != null)
            {
                if(currentCargo.ShuttleArrive)
                    shuttleTitle.text = "Пристыкован";
                else
                    shuttleTitle.text = "Отстыкован";
            }
        }
    }
}
