using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public int ConsumeEnergy = 4000;
    private int ProduceEnergy;
  
    public int Capacity = 2000000; 
    private int chargeLevel = 102;

    //  public int chargePercent = 100 * chargeLevel / Capacity;


     public float ChargePercent { get => Mathf.Round(100 * chargeLevel / Capacity); }
   
    




    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void FixedUpdate()
    {
        
    }
}
