using UnityEngine;

class Item : MonoBehaviour
{
	private ITEMTYPE type = ITEMTYPE.FOOD;
	private ITEMNAME name = ITEMNAME.POTATO;
	private uint count = 0;
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