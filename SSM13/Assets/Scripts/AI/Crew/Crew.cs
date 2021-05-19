using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
namespace AI
{
    public class Crew : Human
    {
        public void SetJobBehaviour(IWork behaviour) => _IWork = behaviour;
        private IWork _IWork; //Члены экипажа могут работать! Исключение ассистент кроме что (но бомл гений сделает заглушку-класс без работы)
        
        private void Start()
        {
            InitBehaviors();
        }
        private void InitBehaviors()
        {
            SetWalkBehaviour(new CrewMovePattern(transform, 1f));
            //SetJobBehaviour(new BotanicJobPattern());
        }
        private void Movement(Transform Point)
        {
            PerformWalkMove(Point);
        }
        private void RandomMovePoint()
        {
            if(rest > 5) 
            {

            }
        }
    }
}

