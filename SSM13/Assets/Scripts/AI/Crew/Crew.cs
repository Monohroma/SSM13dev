using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;
using Ark;

namespace AI
{
    public class Crew : Human
    {
        public Bay WorkBay;
        public void SetJobBehaviour(IWork behaviour) => _IWork = behaviour;
        
        public BayTypes AccessLevel; 
        private RandomPointGenerator randomPointGenerator;
        protected void CrewStartMethod()
        {
            randomPointGenerator = GameObject.FindObjectOfType<RandomPointGenerator>();
            setter = GetComponent<AIDestinationSetter>();
            bayList = GameObject.FindObjectOfType<BayList>();
            StartNeedCoroutine(true, true, bayList);
            InitBehaviors();
            NextAction += NextActions;
        }
        private void Start() //Вызывается только в том случае, если на NPC весит скрипт Crew 
        {
            HumanStartMethod(); 
            CrewStartMethod();
        }
        private void OnEnable()
        {
            NextAction += NextActions;
        }
        private void OnDisable()
        {
            NextAction -= NextActions;
        }
        private void NextActions()
        {
            if (rest >= 10 && food >= 15)
            {
                if (WorkBay.Active && WorkBay.Purchased)
                {
                    GoInWork();
                }
                else
                {
                    RandomMovePoint();
                }
            }
        }
        public void StartWork()
        {
            _IWork.StartWork();
            IsWork = true;
        }
        public void GoInWork()
        {
            PerformWalkMove(_IWork.GoInWork(WorkBay.WorkZone));
        }

        protected void InitBehaviors()
        {
            SetWalkBehaviour(new CrewMovePattern(transform, 1f,setter));
        }
        protected void Movement(Transform Point)
        {
            PerformWalkMove(Point);
        }
        public void RandomMovePoint()
        {
            if (rest >= 10 && food >= 15)
            {
                if (_IMovable is CrewMovePattern)
                {
                    ((CrewMovePattern)_IMovable).GoToRandomPoint(randomPointGenerator, AccessLevel);
                    IsWork = false;
                }
            }
        }
    }
}

