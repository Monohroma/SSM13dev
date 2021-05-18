using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ark; // Арк - гига пространство имён арса с двумя классами


public class BayTrigger : MonoBehaviour
{

    public int Index; // Для дебага
    private DynamicBay bay;
    private bool Bought { get { return bay.Purchased; } set { value = bay.Purchased;} } //Комментарии излишни 
    private bool Active = true;
    private BayTypes Type;
    private void Start()
    {
        bay= GetComponent<DynamicBay>();
        Type = bay.Type;
    }
}
