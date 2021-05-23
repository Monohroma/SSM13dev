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
        public bool NPCIsEating;
        private RandomPointGenerator randomPointGenerator;
        private void Awake()
        {
            randomPointGenerator = GameObject.FindObjectOfType<RandomPointGenerator>();
            setter = GetComponent<AIDestinationSetter>();
            bayList = GameObject.FindObjectOfType<BayList>();
            InitBehaviors();
        }
        public void StartEating()
        {
            if (!NPCIsEating)
            {
                NPCIsEating = true;
                StartCoroutine(Eating());
            }           
        }
        public void StopEating()
        {
            StopCoroutine(Eating());
            NPCIsEating = false;
        }
        IEnumerator Eating()
        {
            while(NPCIsEating && food < 100)
            {
                Debug.Log("Нпсишка ест");
                food++;
                yield return new WaitForSeconds(0.3f);
            }
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
        protected void RandomMovePoint()
        {
           // if(rest > 5) 
           if(_IMovable is CrewMovePattern)
            {
                    ((CrewMovePattern)_IMovable).GoToRandomPoint(randomPointGenerator, AccessLevel);
            }
        }
    }
}

