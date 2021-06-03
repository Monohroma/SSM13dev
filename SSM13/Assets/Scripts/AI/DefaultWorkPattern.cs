using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DefaultWorkPattern : IWork 
{
    //      (Паттерн стратегия)
    //Один из паттернов работы для NPC, назначается в crew приравниванием переменной IWork нужному паттерну ходьбы (класс с патерном, который реализует соответствующий интерфейс)
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
        throw new System.NotImplementedException(); //В процессе кодинга
    }
}
