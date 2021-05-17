using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public abstract class Crew : MonoBehaviour
{
    private AIDestinationSetter setter; // штука в которую надо передавать transform точки навигации
    public Sprite sprite; // спрайт
     public float speed = 1; // скорость
     public int rest = 100; // усталость
     public int hp = 100; // здоровье
     public int food = 100; // сытость
    public AImenedger aImenedger;
    // листы с точками навигации
    Dictionary<string, List<Transform>> NavPoints;

    public Crew()
    {

    }

}
