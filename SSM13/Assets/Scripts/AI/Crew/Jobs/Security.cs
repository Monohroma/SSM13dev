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
            StartNeedCoroutine(true, true, bayList); // Из базовых классов почему-то не запускается  //Нужно вынести в класс crew
        }
        private void Update()
        {
            
            if (Input.GetMouseButtonDown(1))
            {
                ((SecurityMovementPattern)_IMovable).MoveToClick();
                StopCoroutine(SpriteDirection());
                StartCoroutine(SpriteDirection());        //Кодить будет Толик, поэтому пофикси, корутина работает while Goes, значит нужно сделать условие перехода Goes в Security 
            }
        }
        private void InitBehaviors()
        {
            SetWalkBehaviour(new SecurityMovementPattern(transform, 1f, setter,Point));
        }
    }
}

