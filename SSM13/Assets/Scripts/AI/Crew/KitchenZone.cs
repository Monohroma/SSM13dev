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
                            ai.StartEating(this);
                            ai.Goes = false;
                        }
                        else
                        {
                            PointIsBusy = false;
                            NPCInPoint = null;
                            Debug.LogWarning("��� �� ��������, ������ ��� ����� ����� ���?");
                        }
                    }
            }                         
    }
    public bool BayAvailable()
    {
        return (bayList.Kitchen.Active && bayList.Kitchen.Bought);
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }
}
