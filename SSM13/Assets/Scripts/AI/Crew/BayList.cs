using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BayList : MonoBehaviour
{
   public List<GameObject> Bays = new List<GameObject>();
   public ZoneStatus[] KitchenZone; //� ������� ���������� ��������� ����.
   public ZoneStatus[] RestZone;
   [Header("Only debug")]
   public List<Transform> FreeKitchenZone; //���� ����������� � ���� ����� �� ������� ��������, ����������� � ���� (����� �������� �� Queue)
   public List<Transform> FreeRestZone;

    private void Awake()
    {
        int index = 0;
        foreach (Transform child in transform)
        {
            index++;
            Bays.Add(child.gameObject);
            child.gameObject.GetComponent<BayTrigger>().Index = index;
        }
        UpdateList();
        
    }
    public void TakeKitchenPoint(int index, GameObject NPC)
    {
        if (FreeKitchenZone[index])
        {
            FreeKitchenZone.Remove(FreeKitchenZone[index]);
            FreeKitchenZone[index].gameObject.GetComponent<ZoneStatus>().PointIsBusy = true;
            FreeKitchenZone[index].gameObject.GetComponent<ZoneStatus>().NPCInPoint = NPC;
            UpdateList();
        }
        else
        {
            Debug.LogWarning("�����, �����!");
        }
        
    }
    public void TakeRestPoint(int index, GameObject NPC)
    {
        if (FreeKitchenZone[index])
        {
            FreeRestZone.Remove(FreeKitchenZone[index]);
            FreeRestZone[index].gameObject.GetComponent<ZoneStatus>().PointIsBusy = true;
            FreeRestZone[index].gameObject.GetComponent<ZoneStatus>().NPCInPoint = NPC;
            UpdateList();
        }
        else
        {
            Debug.LogWarning("�����, �����!");
        }

    }
    public void UpdateList()
    {
        FreeKitchenZone = null;
        FreeRestZone = null;
        foreach (var point in KitchenZone)
        {
            if (!point.PointIsBusy)
            {
                FreeKitchenZone.Add(point.gameObject.transform); //������ ����� ���� ��������
            }
        }
        foreach (var point in RestZone)
        {
            if (!point.PointIsBusy)
            {
                FreeRestZone.Add(point.gameObject.transform);
            }
        }
    }

}
