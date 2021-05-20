using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botanic : AI.Crew
{
    // Start is called before the first frame update
    void Start()
    {
        InitWork(BayTypes.Botanics);
        RandomMovePoint();
    }
    private void InitWork(BayTypes Acces)
    {
        AccessLevel = Acces;
        SetJobBehaviour(new BotanicJobPattern(1f,null)); //на место null засунуть геймобджект ботаники
    }


}
