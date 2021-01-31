using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AssistantScript : MonoBehaviour
{
    private static CrewData Data;
    private GameObject[] NavPoints = GameObject.FindGameObjectsWithTag("NavPoint"); // массив с геймобджектами точек
    private AIDestinationSetter setter;

    //трансформы для точек
    Transform kitchen;
    Transform RestZone;
    Transform WorkZone;
    Transform HideZone;

    public void Awake()
    {
        setter = GetComponent<AIDestinationSetter>();
        // перебераем массив и задаем трансформы нашим трансформам
        foreach(GameObject point in NavPoints)
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
                Debug.LogError("Точки пути не существует");
                break;
        }

    }

    /* Дальше должена находится корутина которая уменьшает голод и корутина которая уменьшает энергию во время работы. А так же проверка в апдейте на активные желания
       типо если всё хорошо - работаем, хочется кушать - кушаем, хочется чилить - чилим, получаем по лицу - прячемся.
     */

}
