using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

namespace AI
{
    public class Security : Human
    {
        public GameObject Point;
        private void Awake()
        {
            setter = GetComponent<AIDestinationSetter>();
            bayList = GameObject.FindObjectOfType<BayList>();
            
            InitBehaviors();
        }
        void Start()
        {
            StartNeedCoroutine(true, true, bayList); // Из базовых классов почему-то не запускается  //Нужно вынести в класс crew
        }
        private void Update()
        {
            
            if (Input.GetMouseButtonDown(1))
            {
                ((SecurityMovementPattern)_IMovable).MoveToClick();
            }
        }
        private void InitBehaviors()
        {
            SetWalkBehaviour(new SecurityMovementPattern(transform, 1f, setter,Point));
        }
    }
}

