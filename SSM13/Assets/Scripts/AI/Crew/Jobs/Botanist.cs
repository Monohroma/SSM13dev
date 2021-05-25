using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ark;


namespace AI 
{
    public class Botanist : Crew
    {      
        void Start()
        {
            InitWork(BayTypes.Botanics);
            StartNeedCoroutine(true,true,bayList); // Из базовых классов почему-то не запускается  //Нужно вынести в класс crew
            RandomMovePoint(); //Дебаг
        }
        private void InitWork(BayTypes Acces)
        {
            AccessLevel = Acces;
            SetJobBehaviour(new DefaultWorkPattern(1.5f, WorkZone)); 
        }

    }
}


