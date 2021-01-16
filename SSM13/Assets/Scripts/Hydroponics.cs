using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MEC;



public class Plants
{
    public string Name { get; private set; }
    public float GrowingTime { get; private set; }
    public int Cost { get; private set; }
    public int NumberOfGrowths { get; private set; } //То, сколько раз можно собрать
    public float FailureChance { get; private set; }
    public int HarvestAmount { get; private set; } //Кол-во получаемых предметов после сбора

    public Plants(string Name, float GrowingTime, int Cost, int NumberOfGrowths, float FailureChance, int HarvestAmount)
    {
        this.Name = Name;
        this.GrowingTime = GrowingTime;
        this.Cost = Cost;
        this.NumberOfGrowths = NumberOfGrowths;
        this.FailureChance = FailureChance;  // 0 - 1
        this.HarvestAmount = HarvestAmount; //grown amount
    }
}
struct CoroutineOperation
{
   public CoroutineHandle Handle;
   public float Progress;
   public bool Completed;

}
public class Hydroponics : MonoBehaviour
{
    bool BayActive = true;
    Bay.Bay Botanics = new Bay.Bay("Hydroponics", false, 4000, 3000);
    Plants Tomato = new Plants("Tomato", 3, 55, 3, 0.10f, Random.Range(2, 4)); // 110-220
    Plants Potato = new Plants("Potato", 6, 35, 1, 0.2f, Random.Range(5, 7));  //175-245 
    List<CoroutineOperation> Coroutines = new List<CoroutineOperation>();
    public void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            CoroutineOperation b = new CoroutineOperation();
            b.Completed = true;
            Coroutines.Add(b);
        }
    }
    public void PotattoButton()
    {
        if (BayActive & Botanics.Bought)
        {
            for (int i = 0; i < 6; i++)
            {
                if (Coroutines[i].Completed)
                {
                    Timing.RunCoroutine(Tray(Coroutines[i], Potato));

                    //Дописать выдачу предмета в инвентарь
                    break;
                }
            }
        }
    }
    public void TomatoButton()
    {
        if (BayActive & Botanics.Bought)
        {
            for (int i = 0; i < 6; i++)
            {
                if (Coroutines[i].Completed)
                {
                    Timing.RunCoroutine(Tray(Coroutines[i],Tomato));
                    //Дописать выдачу предмета в инвентарь

                    break;
                    
                } 
            }
        }
    }
    public void Update()
    {
   /*     for (int i = 0; i < 6; i++)
        {
            Mathf.Round((Coroutines[i].Progress*100)/ //вывод на слайдеры
        }  */
    }
   
    IEnumerator<float> Tray(CoroutineOperation b, Plants p)
    {
        b.Completed = false;
        var timer = p.GrowingTime*60;
        while (timer >= 0)
        {
            yield return Timing.WaitForSeconds(1);
            b.Progress = timer--;
        }
        b.Completed = true;
    }

    public void bought()
    {
        // тут короче проверка на то хватает ли денег на покупку отсека и если хватает то уменьшаем деньги и меняем куплено на true
    }

    
   

    
    
  
}




