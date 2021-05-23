using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenZone : Zone
{
private void OnTriggerEnter2D(Collider2D other)
{
        if (NPCInPoint == other.gameObject)
            {
                    if (bayList.Kitchen.Active && bayList.Kitchen.Bought)
                    {
                        if (other.gameObject.GetComponent<AI.Crew>())
                        {
                            var ai = other.gameObject.GetComponent<AI.Crew>();
                            ai.StartEating();
                            ai.GoesToEat = false;
                        }
                        else
                        {
                            other.gameObject.GetComponent<AI.Crew>().GoesToEat = false;
                            PointIsBusy = false;
                            NPCInPoint = null;
                            Debug.LogError("Это не персонал, почему эта тварь здесь жрёт?");
                        }
                    }
            }                         
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }
}
