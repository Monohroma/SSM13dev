using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BayList : MonoBehaviour
{
   public List<GameObject> Bays = new List<GameObject>();
    private void Awake()
    {
        int index = 0;
        foreach (Transform child in transform)
        {
            index++;
            Bays.Add(child.gameObject);
            child.gameObject.GetComponent<BayTrigger>().Index = index;
        }
    }
}
