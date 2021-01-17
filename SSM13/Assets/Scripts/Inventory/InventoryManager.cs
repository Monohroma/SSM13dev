using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
	public Dictionary<ITEMNAME, Item> items; // Не хочется держать его как паблик, но для дебага надо

	public void CreateItem(Item item)
	{
		if (items.ContainsKey(item.Name))
		{
			items[item.Name].Count += item.Count;
			return;
		}
		items.Add(item.Name, item);
	}

	public void CreateItem(ITEMNAME name, ITEMTYPE type, uint count)
	{
		CreateItem(new Item(name, type, count, 100));
	}

	public void DebugAddPotato(int count) // Инспектор юнити не видит функцию с uint
	{
		CreateItem(ITEMNAME.POTATO, ITEMTYPE.FOOD, (uint)count);
	}

	public void Remove(ITEMNAME name, uint count)
	{
		if (Contains(name))
		{
			items[name].Count -= count;
			return;
		}
		Debug.LogWarning("Trying to remove item that not in the inventory");
	}

	public void Add(ITEMNAME name, uint count)
	{
		if (Contains(name))
		{
			items[name].Count += count;
		}
	}	

	public bool Contains(ITEMNAME name)
	{
		return items.ContainsKey(name);
	}

	public Item GetItem(ITEMNAME name)
	{
		return items[name];
	}

	private void Awake()
	{
		items = new Dictionary<ITEMNAME, Item>();
	}
}
