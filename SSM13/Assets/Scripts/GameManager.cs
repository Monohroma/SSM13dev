using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using Ark;
using System;
using AI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
	public GameObject AssistantPrefab;
	public List<Generator> currentGenerators = new List<Generator>();
	public List<Crew> AllCrew = new List<Crew>();
	public List<Crew> FreeAssistant = new List<Crew>();
	public List<Bay> currentBays = new List<Bay>();
	public AlertLevel alertLevel;
	public Bay safeBay;
	public Action<Bay> OnBayAdd;
	public Action<Bay> OnBayRemove;

	// Засуну сюда, просто потому что
	public delegate void ChangeCrew(int count);
	public event ChangeCrew CrewChanged;

    private GameManager()
    {
		_instance = this;
    }
    private void Awake()
    {
		AllCrew.AddRange(GameObject.FindObjectsOfType<Crew>());
		foreach (var crew in AllCrew)
        {
			if(crew is Assistant)
            {
				FreeAssistant.Add(crew);
            }
        }
    }
    public static GameManager Instance
	{
		get
		{
			return _instance;
		}
	}

	/*
	public void AddCrew(Crew crew)
	{
		if (!AllCrew.Contains(crew))
		{
			AllCrew.Add(crew);
			CrewChanged(AllCrew.Count);
			return;
		}
		throw new ArgumentException($"Trying add crew to {nameof(AllCrew)} that already have it");
	}
	*/

	public void AddGenerator(Generator generator)
    {
		if(!currentGenerators.Contains(generator))
			currentGenerators.Add(generator);
    }

	public void RemoveGenerator(Generator generator)
	{
		currentGenerators.Remove(generator);
	}

	public void AddBay(Bay bay)
    {
		if (!currentBays.Contains(bay))
		{
			currentBays.Add(bay);
			OnBayAdd?.Invoke(bay);
		}
    }

	public void RemoveBay(Bay bay)
    {
		if (currentBays.Contains(bay))
		{
			currentBays.Remove(bay);
			OnBayRemove?.Invoke(bay);
		}
    }

	public static Vector3 Vector2To3(Vector2 vec)
    {
		return new Vector3(vec.x, vec.y, 0);
    }
}
