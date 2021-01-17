using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : NPC
{
    private Station station;
    private WORK work;
    // Start is called before the first frame update
    void Start()
    {
        station = FindObjectOfType<Station>();
        station.AddCrew(this);
        work = WORK.ASSISTANT;
    }

    public void CrewUpdate()
	{
        
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
