using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavPoint : MonoBehaviour
{
    private GameObject ThisCollider;

    private void Start()
    {
        ThisCollider = GetComponent<GameObject>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Crew")
        {
            switch (ThisCollider.name)
            {
                case "kitchen":
                   AssistantScript Asistant = collision.gameObject.GetComponent<AssistantScript>();
 //                   Asistant.StartCoroutine(); ПОЧЕМУ ТО НЕ РАБОТАЕТ, ХОЧУ ЗАПУСТИТЬ IndicatorTimer, А не могу
                    break;
                case "rest zone":
                    
                    break;
                case "work zone":
                    
                    break;
                case "hide zone":
                    
                    break;
                default:
                    Debug.LogError("эта точка не предусмотрена");
                    break;
            }
                
        }
    }
}
