using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Solar : MonoBehaviour
{
    public bool Bought = false;

    void Update()
    {
        GetComponent<SpriteRenderer>().enabled = Bought; 
        if (Bought)
        {
            gameObject.name = "bought";
        }
        else 
        {
            gameObject.name = "unbought";
        }
    }
}
