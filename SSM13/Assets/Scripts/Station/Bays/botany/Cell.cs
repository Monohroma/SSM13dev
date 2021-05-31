using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cell : ScriptableObject
{
    public Plant CurrentPlant => currentPlant;

    private Plant currentPlant = null;
    private float timer = 0;
       
    public void SetPlant(Plant p)
    {
        currentPlant = p;
        timer = p._GrowingTime;
    }
    public float GetProgress()
    {
        if(currentPlant != null)
            return ((currentPlant._GrowingTime - timer) / currentPlant._GrowingTime);
        return 0;
    }
    public bool UpdatePlant(float fixedDeltaTime)
    {
        timer -= fixedDeltaTime;
        if(timer <= 0)
        {
            timer = 0;
            return true;
        }
        return false;
    }
}
