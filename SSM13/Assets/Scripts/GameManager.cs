using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
	private List<Crew> crewList;
	private Timer crewUpdateTimer;

    private GameManager()
	{
		crewUpdateTimer = new Timer(5000);
		crewUpdateTimer.Elapsed += crewUpdateTrigger;
	}

	private void crewUpdateTrigger(object sender, ElapsedEventArgs e)
	{
		foreach (Crew crew in crewList)
		{
			crew.CrewUpdate();
		}
	}

	public static GameManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GameManager();
			}
			return instance;
		}
	}

	public void AddCrew(Crew crew)
	{
		#if UNITY_EDITOR
		if (crewList.Contains(crew))
		{
			Debug.LogWarning("ADDING TO CREW LIST A CREW THAT ALREADY IN LIST");
		}
		#endif
		crewList.Add(crew);
	}
}
