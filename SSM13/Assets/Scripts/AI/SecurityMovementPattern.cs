using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SecurityMovementPattern : IMovable
{
    private Camera Camera;
    private Transform humanTransform;
    private AIDestinationSetter settDestination;
    private GameObject targetPoint;
    private float speed;
    public SecurityMovementPattern(Transform humanTransform, float speed, AIDestinationSetter aIDestinationSetter, GameObject targetPoint)
    {
        this.humanTransform = humanTransform;
        this.speed = speed;
        settDestination = aIDestinationSetter;
        this.targetPoint = targetPoint;
        Camera = Camera.main;
    }

    public float SetMoveSpeed(float speed) => this.speed = speed;

    public void Move(Transform point)
    {
        settDestination.target = point;
    }
    public void MoveToClick()
    {
        Vector2 pos = Camera.ScreenToWorldPoint(Input.mousePosition);
        targetPoint.transform.position = pos;
        Move(targetPoint.transform);
    }

}
