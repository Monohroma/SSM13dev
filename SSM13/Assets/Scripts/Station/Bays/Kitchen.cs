using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public class Food
{
    public string Name { get; private set; }
    public float CookingTime { get; private set; }
    public int Cost { get; private set; }

    public Food(string Name, float CookingTime, int Cost)
    {
        this.Name = Name;
        this.CookingTime = CookingTime;
        this.Cost = Cost;
    }
}

struct Coroutine
{
    public bool Completed;
    public float Progress;
}
public class Kitchen : MonoBehaviour
{
     Food fried_potatoes = new Food("Fried potatoes", 1,10);
     Food puree = new Food("Puree", 3,15);
     Food potato_pie = new Food("Potato pie", 5,20);
     Food baked_potatoes = new Food("Baked potatoes", 8,30);
     Food potato_stew = new Food("Potato stew", 10,50);


     private void Start()
     {
         Coroutine c;
     }


     IEnumerator<float> Slot(Food f, Coroutine c)
     {
         c.Completed = false;
         var timer = f.CookingTime;
         while (timer >= 0)
         {
             yield return Timing.WaitForSeconds(1);
             c.Progress = timer--;
         }
         c.Completed = true;
     }
    
     
     


         // Bay.Bay Kitchen = new Bay.Bay("Kitchen", false, 2000, 4500);


}



