using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SecurityMovementPattern : IMovable
{
    //      (Паттерн стратегия)
    //Один из паттернов ходьбы для NPC, назначается в human приравниванием переменной IMovable нужному паттерну ходьбы (класс с патерном, который реализует соответствующий интерфейс)
    //Паттерн ходьбы для security
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
