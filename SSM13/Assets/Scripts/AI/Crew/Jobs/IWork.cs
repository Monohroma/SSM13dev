using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public interface IWork 
{
    void StartWork();
    Transform GoInWork(List<Transform> workZone);
}
