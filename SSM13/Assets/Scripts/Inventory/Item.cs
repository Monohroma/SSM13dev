public class Item
{
	public ITEMTYPE Type;
	public ITEMNAME Name;
	public uint Count;
	public uint Price;

	public Item(ITEMNAME name, ITEMTYPE type, uint count, uint price)
	{
		Type = type;
		Name = name;
		Count = count;
		Price = price;
	}
}

public enum ITEMNAME
{
	POTATO,
	HOTPOTATO
}

public enum ITEMTYPE
{
	FOOD,
	GUN
}