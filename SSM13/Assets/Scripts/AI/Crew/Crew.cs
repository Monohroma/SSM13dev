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
        public void SetJobBehaviour(IWork behaviour)
        {
            _IWork = behaviour;
        }
        public BayTypes AccessLevel; 
        private RandomPointGenerator randomPointGenerator;
        protected void CrewStartMethod()
        {          
            randomPointGenerator = GameObject.FindObjectOfType<RandomPointGenerator>();
            setter = GetComponent<AIDestinationSetter>();
            bayList = GameObject.FindObjectOfType<BayList>();
            StartNeedCoroutine(true, true, bayList);
            InitBehaviors();
           
            //GameManager.Instance.AddCrew(this);
            NextAction += NextActions;
            NextActions();
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
        public void NextActions()
        {
            if (rest >= 10 && food >= 15)
            {
                if(this is Assistant)
                {
                    RandomMovePoint();
                }
                else if (WorkBay.Active && WorkBay.Purchased)
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
            Movement(_IWork.GoInWork(WorkBay.WorkZone));
        }

        protected void InitBehaviors()
        {
            SetWalkBehaviour(new CrewMovePattern(transform, 1f,setter));
        }
        protected void Movement(Transform Point)
        {
            Goes = true;
            PerformWalkMove(Point);
        }
        public void RandomMovePoint()
        {
            if (_IMovable is CrewMovePattern)
                {
                    var randomPoint = ((CrewMovePattern)_IMovable).GetRandomPoint(randomPointGenerator);
                    Movement(randomPoint);
                    IsWork = false;
                StartCoroutine(ChangePositionAfterDelay());
                }
        }
        private IEnumerator ChangePositionAfterDelay()
        {
            yield return new WaitForSeconds(20f);
            NextActions();
            yield break;
        }
    }
}

