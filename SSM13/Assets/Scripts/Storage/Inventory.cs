using System;
using System.Collections.Generic;
using UnityEngine;
using Ark;
using NUnit.Framework;

namespace Storage
{
    public class Inventory : MonoBehaviour
    {
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

        public void ClearInventory()
        {
            _items.Clear();
        }

        /// <summary>
        /// Only DEBUG!
        /// </summary>
        public void dev_ClearCountItems()
        {
            foreach (var item in _items)
            {
                item.SetCount(0);
            }
        }
        
        public GameItem GetItem(int itemId)
        {
            return _items.Find(item => item.ItemID == itemId);
        }

        public GameItem GetItem(GameItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            return _items.Find(element => element == item);
        }
        
        public void AddItem(GameItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            print("ttt");
            if (_items.Count != 0)
            {
                GetItem(item).AddCount(item.ItemCount);
                return;
            }
            _items.Add(item);
        }

        public void AddItem(int id, int count)
        {
            if (_items.Count != 0)
            {
                GetItem(id).AddCount(count);
            }
            else throw new ArgumentNullException(nameof(_items), "Please add GameItem in List<GameItem>");
        }

        public void SubtractItem(GameItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            GetItem(item).RemoveCount(item.ItemCount);
        }
        
        public void SubtractItem(int id, int count)
        {
            GetItem(id).RemoveCount(count);
        }

    }
}
