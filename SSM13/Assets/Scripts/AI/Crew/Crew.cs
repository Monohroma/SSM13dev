using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

namespace AI
{
    public class Crew : Human
    {
        public List<Transform> WorkZone = new List<Transform>();
        public void SetJobBehaviour(IWork behaviour) => _IWork = behaviour;
        private IWork _IWork; //Члены экипажа могут работать! Исключение ассистент кроме что (но бомл гений сделает заглушку-класс без работы)
        public BayTypes AccessLevel; 
        private RandomPointGenerator randomPointGenerator;
        private void Awake()
        {
            randomPointGenerator = GameObject.FindObjectOfType<RandomPointGenerator>();
            setter = GetComponent<AIDestinationSetter>();
            bayList = GameObject.FindObjectOfType<BayList>();
            InitBehaviors();
        }
        public void StartWork()
        {
            _IWork.StartWork();
            IsWork = true;
        }
        public void GoInWork()
        {
            if(rest >= 10 && food >= 15)
            {
                if (_IWork.GoInWork(WorkZone))
                {
                    PerformWalkMove(_IWork.GoInWork(WorkZone));
                }
                else
                {
                    RandomMovePoint();
                }
                
            }
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

