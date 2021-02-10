using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AssistantScript : Crew
{
    private GameObject[] NavPoints;
    private AIDestinationSetter setter;

    //трансформы для точек
    Transform kitchen;
    Transform RestZone;
    Transform WorkZone;
    Transform HideZone;


    public void Start()
    {
        NavPoints = GameObject.FindGameObjectsWithTag("NavPoint"); // массив с геймобджектами точек
        setter = GetComponent<AIDestinationSetter>();
        // перебераем массив и задаем трансформы нашим трансформам
        foreach (GameObject point in NavPoints)
        {
            switch (point.name)
            {
                case "kitchen":
                    kitchen = point.transform;
                    break;
                case "rest zone":
                    RestZone = point.transform;
                    break;
                case "work zone":
                    WorkZone = point.transform;
                    break;
                case "hide zone":
                    HideZone = point.transform;
                    break;
                default:
                    Debug.LogError("обнаружена непредусмотренная точка");
                    break;
            }
        }

        // стартуем голод
        StartCoroutine(IndicatorTimer(food, 5, " еда"));
    }
    public void SetTask(string TaskName)
    {
        switch (TaskName)
        {
            case "Eat":
                setter.target = kitchen;
                break;
            case "Rest":
                setter.target = RestZone;
                break;
            case "Work":
                setter.target = WorkZone;
                break;
            case "Hide":
                setter.target = HideZone;
                break;
            default:
                Debug.LogError($"Точки {TaskName} не существует");
                break;
        }

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
        if(rest > 0 && food >= 30)
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
        }
    }
}
