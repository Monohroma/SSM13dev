using System.Collections;
using System.Collections.Generic;
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
    public string ChargePercent()
    {
        float result = Mathf.Round(chargeLevel / Capacity * 100);
        return result.ToString(); 
        
    }
     void Start()
    {
        StartCoroutine(PowerOut());
        
          
    }
    void Update()
    {
        int SlideValue = int.Parse(ChargePercent());
        slider.value = SlideValue;
        ChargeText.text = ChargePercent() +"%";
    }
    IEnumerator PowerOut()
    {
        
       while(true)
        {
            
            Consumption();
            yield return new WaitForSeconds(1f);
            
        }
        
        
    }
    public string WattText(int input)
    {
        string output = "";
        if (input >= 1000)
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
            chargeLevel -=СonsumptionEnergy;
        }
        else
        {
            chargeLevel = 0;
        }
            
            
           
        
            
    }
}
