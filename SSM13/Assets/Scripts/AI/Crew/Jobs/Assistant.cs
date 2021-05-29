using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class Assistant : Crew
    {
        void Start()
        {
            HumanStartMethod();
            CrewStartMethod();
            InitWork(BayTypes.GreyZone);
        }
        private void InitWork(BayTypes Acces)
        {
            AccessLevel = Acces;
            //SetJobBehaviour(new DefaultWorkPattern(1.5f, WorkBay.WorkZone)); сделать паттерн работы для асситента (пустой скрипт с интерфейсом)
        }
    }
}

