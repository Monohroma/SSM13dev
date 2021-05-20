using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotanicJobPattern : IWork
{
    private GameObject BayGameObject;
    private float WorkEnergyConsumption;

    public BotanicJobPattern(float energyConsumption, GameObject bay)
    {
        WorkEnergyConsumption = energyConsumption;
        BayGameObject = bay;
    }
    public void StartWork()
    {
        throw new System.NotImplementedException();
    }
}
