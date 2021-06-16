using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

namespace AI
{
    //      (Паттерн стратегия)
    //Один из паттернов ходьбы для NPC, назначается в crew приравниванием переменной IMovable нужному паттерну ходьбы (класс с патерном, который реализует соответствующий интерфейс)

    public class CrewMovePattern : IMovable 
    {
        private Transform humanTransform;
        private AIDestinationSetter settDestination;
        private float speed;
        public CrewMovePattern(Transform humanTransform, float speed, AIDestinationSetter aIDestinationSetter)
        {
            this.humanTransform = humanTransform;
            this.speed = speed;
            settDestination = aIDestinationSetter;
        }
        public float SetMoveSpeed(float speed) => this.speed = speed;
        public void Move(Transform MovePoint)
        {
            settDestination.target = MovePoint;
        }
        public Transform GetRandomPoint(RandomPointGenerator randomPointGenerator) 
        {
            return randomPointGenerator.RandomPointGenerate();
        }
    }
}
