using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CrewNavigation : MonoBehaviour
{                                           // ПОИСК ПУТИ ЕСТЬ, А ХОДЬБЫ ПО ТАЙЛАМ НЕТУ! докожу позже
    public Transform target;

    public float speed = 200f;
    public float nextWaypointDistanse = .32f;

    Path path;
    int currentWaypoint = 0;
    bool reacheEndOfPath = false;

    Seeker seeker;
    void Start()
    {
        seeker = GetComponent<Seeker>();

        InvokeRepeating("UpdatePath", 0f, .5f);

    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        seeker.StartPath(transform.position, target.position, OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    void FixedUpdate()
    {
        if (path == null)
            return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reacheEndOfPath = true;
            return;
        }
        else
        {
            reacheEndOfPath = false;
        }

    }
}
