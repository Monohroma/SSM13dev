using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using Ark;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
	public List<Generator> currentGenerators = new List<Generator>();
	public List<Bay> currentBays = new List<Bay>();
	public Action<Bay> OnBayAdd;
	public Action<Bay> OnBayRemove;

    private GameManager()
    {
		_instance = this;
    }

    public static GameManager Instance
	{
		get
		{
			return _instance;
		}
	}

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
			OnBayAdd(bay);
		}
    }

	public void RemoveBay(Bay bay)
    {
		if (currentBays.Contains(bay))
		{
			currentBays.Remove(bay);
			OnBayRemove(bay);
		}
    }
}
