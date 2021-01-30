using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CrewNavigation : MonoBehaviour
{ 
    public Transform target;
    public float speed = 20f;
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
        Vector2.Lerp((Vector2)transform.position, (Vector2)path.vectorPath[currentWaypoint], speed * Time.deltaTime);
        float distance = Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]);

        if (distance< nextWaypointDistanse)
        {
            currentWaypoint++;
        }
    }
}
