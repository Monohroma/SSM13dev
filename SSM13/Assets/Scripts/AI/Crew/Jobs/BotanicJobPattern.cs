using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotanicJobPattern : IWork
{
    private float WorkEnergyConsumption;

    public BotanicJobPattern(float energyConsumption, List<Transform> Zone)
    {

        WorkEnergyConsumption = energyConsumption;
    }
    public void StartWork()
    {
        throw new System.NotImplementedException();
    }
}
