using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Solar : MonoBehaviour
{
    public bool Bought = false;


    void Start()
    {
        
    }

    void Update()
    {
        GetComponent<Image>().enabled = Bought; 
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
