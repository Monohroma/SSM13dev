using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    Plants currentPlant;
    public bool Completed { get; private set; } = true;
    public float Progress { get; private set; }
    

    IEnumerator Tray()
    {
        
        int NumberOfGrowths=0;
    point:
        var timer = currentPlant.GrowingTime;
        while (timer > 0)
        {
            timer--;
            yield return new WaitForSeconds(1);
            Progress++;
        }
        var amount = Random.Range(0,currentPlant.HarvestAmount);
        InventoryManager.Instance.CreateItem(currentPlant.ItemName, ITEMTYPE.FOOD, (uint)amount, 100);
        NumberOfGrowths++;
        Progress = 0;
                              
        if(NumberOfGrowths <= currentPlant.NumberOfGrowths)
        {
            goto point;
        }
        Completed = true;
        gameObject.name = "inactive";

    }       
    public void SetPlant(Plants p)
    {
        gameObject.name = "active";
        Completed = false;
        currentPlant = p;
        StartCoroutine(Tray());
    }
    public string GetProgress()
    {

        int progress = 0;
        try
        {
             progress = (int)(Progress * 100 / currentPlant.GrowingTime);
        }   
        catch
        {
            progress = 0;
        }
            return progress.ToString();

    }
    public void Start()
    {
       
    }
    public void FixedUpdate()
    {
        var getText = GetComponentInChildren<TMP_Text>();
        getText.text =GetProgress();
    }

}
