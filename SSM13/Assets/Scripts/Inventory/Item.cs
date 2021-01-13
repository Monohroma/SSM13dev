public class Item
{
	public ITEMTYPE Type;
	public ITEMNAME Name;
	public uint Count;

	public Item(ITEMNAME name, ITEMTYPE type, uint count)
	{
		Type = type;
		Name = name;
		Count = count;
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