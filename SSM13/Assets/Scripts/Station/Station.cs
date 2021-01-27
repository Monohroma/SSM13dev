using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using Bay;

public class Station : MonoBehaviour
{
	[SerializeField]
	private uint money = 0;
	
	public uint Money
	{
		get
		{
			return money;
		}
	}

	public void AddMoney(uint count)
	{
		money += count;
	}

	public void TakeMoney(uint count)
	{
		money -= count;
	}

	public void BuyBay()
    {
	 
    }
}