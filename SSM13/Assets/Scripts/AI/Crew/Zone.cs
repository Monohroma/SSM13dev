using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public BayList bayList;
    public bool PointIsBusy;
    public GameObject NPCInPoint;
    private void Awake()
    {
        bayList = GameObject.FindObjectOfType<BayList>();
    }
}
