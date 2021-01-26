using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Power : MonoBehaviour
{
	[SerializeField]
    Solar[] Solars;
	public int SolarCost = 1000;
	Bay.Bay Cargo = new Bay.Bay();
	public Station station;
	private byte QuantitySolars = 0;
	public TextMeshProUGUI QuantitySolarsText;

	private int ProduceEnergy() =>(20000/60)* QuantitySolars;
	public Slider slider;
	public Text ChargeText;public Text TotalLoadText;
	private int СonsumptionEnergy;
	public float Capacity;
	public float CurrentCharge;
	
	public void BuySolar()
    {
		if(SolarCost <= station.Money)
        {
			for (int i = 0; i < Solars.Length; i++)
			{
				if (!Solars[i].Bought)
                {
					station.TakeMoney((uint)SolarCost);
					Solars[i].Bought = true;
					QuantitySolars++;
					QuantitySolarsText.text = QuantitySolars.ToString();
					break;
				}
	      	}
		}
		else
		{
			Debug.Log("Денег нет!");
		}

	}
	public int ChargePercent()
	{
		float result = (CurrentCharge / Capacity * 100);

		return (int)result;


	}
	void Start()
	{
		Solars = GetComponentsInChildren<Solar>();
		StartCoroutine(PowerOut());


	}
	void Update()
	{
		int chargePercent = ChargePercent();
		slider.value = chargePercent;
		ChargeText.text = chargePercent + "%";

		if (chargePercent >= 60)
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
		}


	}
	IEnumerator PowerOut()
	{
		while (true)
		{
			Consumption();
			yield return new WaitForSeconds(1f);
		}
	}
	public string WattText(int input)
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
		CurrentCharge += ProduceEnergy();



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
