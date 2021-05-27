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
            HumanStartMethod();
            CrewStartMethod();
            InitWork(BayTypes.Botanics);            
        }
        private void InitWork(BayTypes Acces)
        {
            AccessLevel = Acces;
            SetJobBehaviour(new DefaultWorkPattern(1.5f, WorkBay.WorkZone)); 
        }

    }
}


