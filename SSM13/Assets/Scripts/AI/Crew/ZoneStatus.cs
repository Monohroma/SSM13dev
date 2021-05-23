using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneStatus : MonoBehaviour
{
    public bool PointIsBusy;
    public GameObject NPCInPoint;
    public BayList bayList;
    private void Awake()
    {
        bayList = GameObject.FindObjectOfType<BayList>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC")
        {
            if(NPCInPoint == other.gameObject)
            {
                if (PointIsBusy)
                {
                    if (bayList.Kitchen.Active && bayList.Kitchen.Bought)
                    {
                        if (other.gameObject.GetComponent<AI.Crew>())
                        {
                            other.gameObject.GetComponent<AI.Crew>().StartEating();
                        }
                        else
                        {
                            PointIsBusy = false;
                            NPCInPoint = null;
                            Debug.LogError("Это не персонал, почему эта тварь здесь жрёт?");
                        }
                    }
                }
            }          
        }       
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }
}
