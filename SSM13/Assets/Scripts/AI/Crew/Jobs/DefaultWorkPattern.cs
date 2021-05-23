using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultWorkPattern : IWork 
{
    private float WorkEnergyConsumption;
    private List<Transform> WorkZone = new List<Transform>();

    public DefaultWorkPattern(float energyConsumption, List<Transform> Zone)
    {
        WorkEnergyConsumption = energyConsumption;
        WorkZone = Zone;
    }

    public void GoInWork()
    {
       
    }

    public void StartWork()
    {
        throw new System.NotImplementedException();
    }
}
