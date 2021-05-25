using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using Ark;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
	public List<Generator> currentGenerators = new List<Generator>();
	public List<Bay> currentBays = new List<Bay>();

    private void Awake()
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
			currentBays.Add(bay);
    }

	public void RemoveBay(Bay bay)
    {
		currentBays.Remove(bay);
    }
}
