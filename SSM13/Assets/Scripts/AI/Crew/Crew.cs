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
        public void StartEating(KitchenZone KitchenZone)
        {
            if (!NPCIsEating)
            {
                Debug.Log(gameObject.name + " ест в кухне");
                NPCIsEating = true;
                StartCoroutine(Eating(KitchenZone));
            }           
        }
        public void StopEating(KitchenZone KitchenZone)
        {
            StopCoroutine("Eating");
            NPCIsEating = false;
            KitchenZone.PointIsBusy = false;
            KitchenZone.NPCInPoint = null;
        }
        public void StartRest(RestZone RestZone)
        {
            if (!NPCIsRest)
            {
                Debug.Log(gameObject.name + " отдыхает");
                NPCIsRest = true;
                StartCoroutine(Rest(RestZone));
            }
        }
        public void StopRest(RestZone RestZone)
        {
            StopCoroutine("Rest");
            NPCIsRest = false;
            RestZone.PointIsBusy = false;
            RestZone.NPCInPoint = null;
        }
       IEnumerator Rest(RestZone restZone) 
        {
            while (NPCIsRest && rest < 100)
            {
                rest++;
                yield return new WaitForSeconds(0.5f);
            }
            restZone.PointIsBusy = false;
            restZone.NPCInPoint = null;
            NPCIsRest = false;
        }
        IEnumerator Eating(KitchenZone KitchenZone)
        {
            while(NPCIsEating && food < 100)
            {
                food++;
                if (!KitchenZone.BayAvailable())
                {
                    StopEating(KitchenZone);
                    yield break;
                }
                yield return new WaitForSeconds(0.3f);
            }
            KitchenZone.PointIsBusy = false;
            KitchenZone.NPCInPoint = null;
            NPCIsEating = false;
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

