using UnityEngine;

class Item : MonoBehaviour
{
	private ITEMTYPE type;
	private ITEMNAME name;
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