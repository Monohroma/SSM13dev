using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DefaultWorkPattern : IWork 
{
    private float WorkEnergyConsumption;
    private List<Transform> WorkZone = new List<Transform>();

    public DefaultWorkPattern(float energyConsumption, List<Transform> Zone)
    {
        WorkEnergyConsumption = energyConsumption;
        WorkZone = Zone;
    }

    public Transform GoInWork(List<Transform> workZone)
    {
        foreach (var zone in WorkZone)
        {
            if(!zone.GetComponent<WorkZone>().PointIsBusy && zone.GetComponent<WorkZone>().NPCInPoint == null)
            {
                return zone;
            }
        }
        return null;
    }

    public void StartWork()
    {
        throw new System.NotImplementedException();
    }
}
