using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private int hp;
    private int hungry;
    private NPCSTATUS status;
    private Dictionary<NPCSTATUS, int> taskQueue; // Task queue with they priority
    

    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        hungry = 100;
        status = NPCSTATUS.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum NPCSTATUS
{
    IDLE,
    WORKING,
    EAT,
    REST,
    FIGHT,
    HIDING
}

public enum WORK
{
    ASSISTANT,
    ENGINEER,
    JANITOR,
    COOK,
    BOTANIST,
    CARGO,
    SECURITY
}