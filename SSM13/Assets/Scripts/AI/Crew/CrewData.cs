using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Crew/Standart Crew", fileName = "New Crew")]
public class CrewData : ScriptableObject
{
     public Sprite sprite;
     public float speed = 1;
     public int rest = 100;
     public int hp = 100;
}
