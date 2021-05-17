using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavPoint : MonoBehaviour
{
    private GameObject ThisCollider;

    private void Start()
    {
        ThisCollider = gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.tag == "Crew")
        {  Debug.Log("зашел в тригер как к себе домой");
            AssistantScript Asistant = collision.gameObject.GetComponent<AssistantScript>();
            switch (ThisCollider.tag)
            {
                case "kitchen":
                    Asistant.StartCoroutine(Asistant.IndicatorTimerPlus(Asistant.food, 1));
                    break;
                case "rest zone":
                    Asistant.StartCoroutine(Asistant.IndicatorTimerPlus(Asistant.rest, 1));
                    break;
                case "work zone":
                    Asistant.StartCoroutine(Asistant.IndicatorTimer(Asistant.rest, 1, "усталость"));
                    Debug.Log("test");
                    break;
                case "hide zone":
                    Debug.Log("Притаился, на крысичах");
                    break;
                default:
                    Debug.LogError("эта точка не предусмотрена");
                    break;
            }
                
        }
    }
}
