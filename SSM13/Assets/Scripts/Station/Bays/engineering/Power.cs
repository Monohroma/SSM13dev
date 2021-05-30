using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ark;

public class Power : MonoBehaviour
{
	[SerializeField]
    Solar[] Solars;
	public int SolarCost = 1000;
	private byte QuantitySolars = 0;

	private int ProduceEnergy() =>(20000/60)* QuantitySolars;
	public Slider slider;
	private int СonsumptionEnergy;
	public float Capacity;
	public float CurrentCharge;
	public Economics economics;

	public void BuySolar()
    {
			for (int i = 0; i < Solars.Length; i++)
			{
				if (!Solars[i].working)
                {
					economics.SubtractMoney(SolarCost);
					Solars[i].working = true;
					QuantitySolars++;
					break;
				}
	      	}

	}
	public int ChargePercent()
	{
		float result = (CurrentCharge / Capacity * 100);

		return (int)result;


	}
	void Start()
	{
		//Solars = GetComponentsInChildren<Solar>();
		StartCoroutine(PowerOut());


	}
	void Update()
	{ // ПЕРЕНЕСИ СЛАЙДЕР В ОТДЕЛЬНЫЙ СКРИПТ SHOWPOWER и всё что касается показа энергии в отдельный скрипт, тут должна быть только логика энергии
		int chargePercent = ChargePercent();
	//	slider.value = chargePercent;

	/*	if (chargePercent >= 60)
		{

			GetComponent<Image>().color = new Color(0.29f, 0.49f, 0.16f);

		}
		else if (chargePercent <= 20)
		{
			GetComponent<Image>().color = Color.red;
		}
		else
		{
			GetComponent<Image>().color = new Color(0.9f, 0.5f, 0.1f);
		} */


	}
	IEnumerator PowerOut()
	{
		while (true)
		{
			Consumption();
			yield return new WaitForSeconds(1f);
		}
	}
	public static string WattText(int input)
	{
		string output = "";
		if (input >= 1000000)
		{
			input /= 1000000;
			output = input.ToString() + "MW";
			return output;
		}
		else if (input >= 1000)
		{
			input /= 1000;
			output = input.ToString() + "kW";
			return output;
		}
		else
		{
			output = input.ToString() + "W";
			return output;
		}
	}
	public void Consumption()
	{
		
		СonsumptionEnergy /= 60; //Вт в час переводим в секунды
								 //CurrentCharge += ProduceEnergy();
		CurrentCharge = Energetics.Instance.StoredEnergy;



		if (CurrentCharge > 0)
		{
			CurrentCharge -= СonsumptionEnergy;
		}
		else
		{
			CurrentCharge = 0;
		}
	}

}
