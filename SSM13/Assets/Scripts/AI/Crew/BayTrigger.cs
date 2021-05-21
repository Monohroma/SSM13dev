using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ark; // Арк - гига пространство имён арса с двумя классами


public class BayTrigger : MonoBehaviour
{

    public int Index; // Для дебага
    private Bay bay;
    private bool Bought { get { return ((DynamicBay)bay).Purchased; } set { value = ((DynamicBay)bay).Purchased;} } //Комментарии излишни 
    private bool Active = true;
    [HideInInspector]  public BayTypes Type;
    private void Start()
    {
        bay = GetComponent<Bay>();
        Type = bay.Type;
    }
}
