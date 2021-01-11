using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
	public Slider slider;
	public Text ChargeText; public Text EquipmentText; public Text LightingText; public Text EnviromentText; public Text TotalLoadText;
	private int СonsumptionEnergy;
	public int ConsumptionLight;
	public int ConsumptionEquipment;
	public int ConsumptionEnviroment;
	private int ProduceEnergy;
	public float Capacity;
	public float chargeLevel;
	public int ChargePercent()
	{
		float result = Mathf.Round(chargeLevel / Capacity * 100);

		return (int)result;


	}
	void Start()
	{
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
		СonsumptionEnergy = ConsumptionLight + ConsumptionEquipment + ConsumptionEnviroment;
		TotalLoadText.text = WattText(СonsumptionEnergy);
		EquipmentText.text = WattText(ConsumptionEquipment);
		EnviromentText.text = WattText(ConsumptionEnviroment);
		LightingText.text = WattText(ConsumptionLight);
		СonsumptionEnergy /= 60; //Вт в час переводим в секунды



		if (chargeLevel > 0)
		{
			chargeLevel -= СonsumptionEnergy;
		}
		else
		{
			chargeLevel = 0;
		}







	}
}
