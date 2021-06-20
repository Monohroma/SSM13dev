using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

namespace AI
{
    //      (������� ���������)
    //���� �� ��������� ������ ��� NPC, ����������� � crew �������������� ���������� IMovable ������� �������� ������ (����� � ��������, ������� ��������� ��������������� ���������)

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
