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
            HumanStartMethod();
            InitBehaviors();     
        }
        void Start()
        {
            StartNeedCoroutine(true, true, bayList); 
        }
        private void Update()
        {
            
            if (Input.GetMouseButtonDown(1))
            {
                ((SecurityMovementPattern)_IMovable).MoveToClick();
                Goes = true;
                StopCoroutine(SpriteDirection());
                StopCoroutine(GoesOffDelay());
                StartCoroutine(SpriteDirection());      
            }
        }

        private void InitBehaviors()
        {
            SetWalkBehaviour(new SecurityMovementPattern(transform, 1f, setter, Point));
        }
    }
}

