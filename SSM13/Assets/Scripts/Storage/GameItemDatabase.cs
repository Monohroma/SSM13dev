using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Storage;

public class GameItemDatabase
{
   private static List<GameItem> _items;

   private static bool _isDatabaseLoaded = false;

   private static void ValidateDatabase()
   {
      if (_items == null) _items = new List<GameItem>();
      if (!_isDatabaseLoaded) LoadDatabase();
   }

   private static void LoadDatabase()
   {
      if(_isDatabaseLoaded) return;
      _isDatabaseLoaded = true;
      LoadDatabaseForce();
   }

   private static void LoadDatabaseForce()
   {
      ValidateDatabase();
      GameItem[] resources = Resources.LoadAll<GameItem>(@"GameItems");
      foreach (GameItem item in resources)
      {
         if (!_items.Contains(item))
         {
            _items.Add(item);
         }
      }
   }

   public static void ClearDatabase()
   {
      _isDatabaseLoaded = false;
      _items.Clear();
   }

   public static GameItem GetItem(int id)
   {
      ValidateDatabase();
      foreach (GameItem item in _items)
      {
         if (item.ItemID == id)
         {
            return ScriptableObject.Instantiate(item) as GameItem;
         }
      }
      return null;
   }

   public static GameItem GetItem(string name)
   {
      ValidateDatabase();
      foreach (GameItem item in _items)
      {
         if (item.ItemName == name)
         {
            return ScriptableObject.Instantiate(item) as GameItem;
         }
      }
      return null;
   }
   
   public static GameItem GetItem(GameItem item)
   {
      ValidateDatabase();
      foreach (GameItem element in _items)
      {
         if (item == element)
         {
            return ScriptableObject.Instantiate(element) as GameItem;
         }
      }
      return null;
   }

   public static List<GameItem> GetListItems()
   {
      ValidateDatabase();
      List<GameItem> items = new List<GameItem>();
      foreach (var item in _items)
      {
         items.Add(ScriptableObject.Instantiate(item));
      }
      return items;
   }
   
   public static GameItem[] GetItems()
   {
      ValidateDatabase();
      return _items.ToArray();
   }
}

