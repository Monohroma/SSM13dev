using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public abstract class Crew : MonoBehaviour
{
    private GameObject[] NavPoints; // массив с точками навигации
    private AIDestinationSetter setter; // штука в которую надо передавать transform точки навигации
    public Sprite sprite; // спрайт
     public float speed = 1; // скорость
     public int rest = 100; // усталость
     public int hp = 100; // здоровье
     public int food = 100; // сытость

    // листы с точками навигации
    List<List<Transform>> NavPointsList;
    List<Transform> EatPoints;
    List<Transform> WorkPoints;
    List<Transform> RestPoints;
    List<Transform> HidePoints;

    
}
