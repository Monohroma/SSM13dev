using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
	public Dictionary<ITEMNAME, Item> items; // Не хочется держать его как паблик, но для дебага надо

	public void Add(Item item)
	{
		if (items.ContainsKey(item.Name))
		{
			items[item.Name].Count += item.Count;
			return;
		}
		items.Add(item.Name, item);
	}

	public void Add(ITEMNAME name, ITEMTYPE type, uint count)
	{
		Add(new Item(name, type, count));
	}

	public void DebugAddPotato(int count) // Инспектор юнити не видит функцию с uint
	{
		Add(ITEMNAME.POTATO, ITEMTYPE.FOOD, (uint)count);
	}

	public void Remove(ITEMNAME name, uint count)
	{
		if (items.ContainsKey(name))
		{
			items[name].Count -= count;
			if (items[name].Count <= 0)
			{
				items.Remove(name);
			}
			return;
		}
		Debug.LogWarning("Trying to remove item that not in the inventory");
	}

	private void Awake()
	{
		items = new Dictionary<ITEMNAME, Item>();
	}
}
