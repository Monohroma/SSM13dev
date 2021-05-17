using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AssistantScript : Crew
{

    public void Start()
    {
        
        StartCoroutine(IndicatorTimer(food, 5, " еда"));
    }
    public IEnumerator IndicatorTimer(int indicator, int timer, string debug)
    {
        while(indicator > 0)
        {
            indicator--;
            Debug.Log(indicator + debug);
        yield return new WaitForSeconds(timer);
        }
    }
    public IEnumerator IndicatorTimerPlus(int indicator, int timer)
    {
        while (indicator > 0)
        {
            indicator++;
            Debug.Log(indicator);
            yield return new WaitForSeconds(timer);
        }
    }

    public void Update()
    {
      /*  if(rest > 0 && food >= 30)
        {
            SetTask("Work");
        }
        else if (food <= 30)
        {
            SetTask("Eat");
        }
        else
        {
            SetTask("Rest");
        } */
    }
}
