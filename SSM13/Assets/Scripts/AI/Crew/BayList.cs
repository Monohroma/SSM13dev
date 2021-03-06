using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ark;

public class BayList : MonoBehaviour
{
   public List<GameObject> Bays = new List<GameObject>();
   public BayTrigger Kitchen;
   public KitchenZone[] KitchenZone; //? ??????? ?????????? ????????? ????.
   public RestZone[] RestZone;
   [Header("Only debug")]
   public List<Transform> FreeKitchenZone = new List<Transform>(); //???? ??????????? ? ???? ????? ?? ??????? ????????, ??????????? ? ???? (????? ???????? ?? Queue)
   public List<Transform> FreeRestZone = new List<Transform>();

    private void Awake()
    {

        int index = 0;
        foreach (Transform child in transform)
        {
            if(child.tag == "bayTrigger")
            {
                index++;
                Bays.Add(child.gameObject);
                child.gameObject.GetComponent<BayTrigger>().Index = index;
            }
        }
        UpdateList();
        
    }
    public void TakeKitchenPoint(int index, GameObject NPC)
    {
        if (FreeKitchenZone[index])
        {
            FreeKitchenZone.Remove(FreeKitchenZone[index]);
            FreeKitchenZone[index].gameObject.GetComponent<KitchenZone>().PointIsBusy = true;
            FreeKitchenZone[index].gameObject.GetComponent<KitchenZone>().NPCInPoint = NPC;
            UpdateList();
        }
        else
        {
            Debug.LogWarning("?????, ?????!");
        }
        
    }
    public void TakeRestPoint(int index, GameObject NPC)
    {
        if (FreeRestZone[index])
        {
            FreeRestZone.Remove(FreeKitchenZone[index]);
            FreeRestZone[index].gameObject.GetComponent<RestZone>().PointIsBusy = true;
            FreeRestZone[index].gameObject.GetComponent<RestZone>().NPCInPoint = NPC;
            UpdateList();
        }
        else
        {
            Debug.LogWarning("?????, ?????!");
        }

    }
    public void UpdateList()
    {
        FreeKitchenZone = new List<Transform>();
        FreeRestZone = new List<Transform>();
        foreach (var point in KitchenZone)
        {
            if (!point.PointIsBusy && point.NPCInPoint == null)
            {
                FreeKitchenZone.Add(point.gameObject.transform); // ??????? ?? ???? ?????? ?????? null reference?
            }
        }
        foreach (var point in RestZone)
        {
            if (!point.PointIsBusy && point.NPCInPoint == null)
            {
                FreeRestZone.Add(point.gameObject.transform);
            }
        }
    }

}
