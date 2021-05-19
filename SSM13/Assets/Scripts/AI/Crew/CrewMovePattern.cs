using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class CrewMovePattern : IMovable
    {
        private Transform humanTransform;
        private float speed;
        public Vector3 GetMoveDirection()
        {
            throw new System.NotImplementedException();
        }
        public CrewMovePattern(Transform humanTransform, float speed)
        {
            this.humanTransform = humanTransform;
            this.speed = speed;
        }
        public float SetMoveSpeed(float speed) => this.speed = speed;
        public void Move(Transform MovePoint)
        {
            throw new System.NotImplementedException(); //ƒописать назначение точки дл€ астара
        }
    }
}
