using System;
using System.Collections.Generic;
using UnityEngine;
using Ark;
//using NUnit.Framework;

namespace Storage
{
    public class Inventory : MonoBehaviour
    {
        public static Action<GameItem> OnAddItem;
        public static Action<GameItem> OnRemoveItem;
        private static Inventory _instance;
        private List<GameItem> _items = new List<GameItem>();

        public static Inventory Instance
        {
            get
            {
                if (_instance == null) _instance = GameObject.FindObjectOfType<Inventory>();
                return _instance;
            }
        }
        
        private void ValidateInventory()
        {
            _items = GameItemDatabase.GetListItems();
            foreach (var item in _items)
            {
                item.SetCount(0);
            }
        }

        public void ClearInventory()
        {
            foreach(GameItem item in _items)
			{
                item.SetCount(0);
                OnRemoveItem?.Invoke(item);
            }
        }

        private void Awake()
        {
            ValidateInventory();
        }

        /// <summary>
        /// Only DEBUG!
        /// </summary>
        public void dev_ClearCountItems()
        {
            //ValidateInventory();
            foreach (var item in _items)
            {
                item.SetCount(0);
                OnRemoveItem?.Invoke(item);
            }
        }

        public GameItem[] GetItems()
        {
            //ValidateInventory();
            return _items.ToArray();
        }
        
        public GameItem GetItem(int itemId)
        {
            //ValidateInventory();
            return _items.Find(item => item.ItemID == itemId);
        }
        
        public GameItem GetItem(string itemName)
        {
            //ValidateInventory();
            return _items.Find(item => item.ItemName == itemName);
        }

        public GameItem GetItem(GameItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            //ValidateInventory();
            return _items.Find(element => element.ItemID == item.ItemID);
        }
        
        public void AddItem(GameItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            //ValidateInventory();
            if (_items.Count != 0)
            {
                GetItem(item).AddCount(1);
                OnAddItem?.Invoke(GetItem(item));
                return;
            }
            else throw new ArgumentNullException(nameof(_items));
        }

        public void AddItem(GameItem item, int count)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            //ValidateInventory();
            if (_items.Count != 0)
            {
                Debug.Log(count);
                GetItem(item).AddCount(count);
                Debug.Log(item.ItemCount);
                OnAddItem?.Invoke(GetItem(item));
                return;
            }
            else throw new ArgumentNullException(nameof(_items));
        }

        public void AddItem(int id, int count) // OBSOLETE?
        {
            //ValidateInventory();
            if (_items.Count != 0)
            {
                var i = GetItem(id);
                i.AddCount(count);
                OnAddItem?.Invoke(i);
            }
            else throw new ArgumentNullException(nameof(_items));
        }

        public void SubtractItem(GameItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            //ValidateInventory();
            GetItem(item).RemoveCount(item.ItemCount);
            OnRemoveItem?.Invoke(GetItem(item));
        }
        
        public void SubtractItem(int id, int count)
        {
            //ValidateInventory();
            GetItem(id).RemoveCount(count);
            OnRemoveItem?.Invoke(GetItem(id));
        }

        public void SubtractItem(string itemName, int count)
        {
            GetItem(itemName).RemoveCount(count);
            OnRemoveItem?.Invoke(GetItem(itemName));
        }

        public bool ContainItem(int id)
        {
            if (GetItem(id).ItemCount > 0)
                return true;
            else
                return false;
        }

        public bool ContainItem(string itemName)
        {
            if (GetItem(itemName).ItemCount > 0)
                return true;
            else
                return false;
        }

        public bool ContainItem(int id, int count)
        {
            if (GetItem(id).ItemCount >= count)
                return true;
            else
                return false;
        }

        public bool ContainItem(string itemName, int count)
        {
            if (GetItem(itemName).ItemCount >= count)
                return true;
            else
                return false;
        }

        public string dev_ShowInfo()
        {
            //ValidateInventory();
            string data = "";
            foreach (var item in _items)
            {
                data += $"Name >> {item.ItemName}; ID >> {item.ItemID.ToString()}; Count >> {item.ItemCount.ToString()}; Price >> {item.ItemPrice.ToString()}; \n";
            }
            return data;
        }

        public GameItem[] GetAllItems()
        {
            return _items.ToArray();
        }
    }
}
