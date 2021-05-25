using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkZone : Zone
{
    public Ark.Bay bay;
    private BayTypes bayTypes;
    private void Start()
    {
        bayTypes = bay.Type;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (NPCInPoint == other.gameObject && other.gameObject.GetComponent<AI.Crew>() && other.gameObject.GetComponent<AI.Crew>().AccessLevel == bayTypes)
        {
            if (bay.Active && bay.Purchased)
            {
                if (other.gameObject.GetComponent<AI.Crew>())
                {
                    var ai = other.gameObject.GetComponent<AI.Crew>();
                    ai.StartWork();
                }
                else
                {
                    PointIsBusy = false;
                    NPCInPoint = null;
                    Debug.Log("Ёто не персонал, что эта тварь здесь делает? јЋя–ћ");
                }
            }
            else
            {
                other.gameObject.GetComponent<AI.Crew>().RandomMovePoint();
            }
        }
    }
}
