using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    Plants currentPlant;
    public bool Completed { get; private set; } = true;
    public float Progress { get; private set; }

    IEnumerator Tray()
    {
        Debug.Log("Карутина запущена!!");
        var timer = currentPlant.GrowingTime;

        
        while (timer > 0)
        {
            timer--;
            Debug.Log("Цикл карутины");
            Debug.Log(timer);
            yield return new WaitForSeconds(1);
            Progress = timer;

        }
        Debug.Log("Конец карутины");
        var amount = Random.Range(0,currentPlant.HarvestAmount);
        InventoryManager.Instance.CreateItem(currentPlant.ItemName, ITEMTYPE.FOOD, (uint)amount, 100);
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

}
