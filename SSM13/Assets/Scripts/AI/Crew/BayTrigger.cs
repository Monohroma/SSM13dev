using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ark; // ��� - ���� ������������ ��� ���� � ����� ��������


public class BayTrigger : MonoBehaviour
{

    public int Index; // ��� ������
    private Bay bay;
    private bool Bought { get { return ((DynamicBay)bay).Purchased; } set { value = ((DynamicBay)bay).Purchased;} } //����������� ������� 
    private bool Active = true;
    [HideInInspector]  public BayTypes Type;
    private void Start()
    {
        bay = GetComponent<Bay>();
        Type = bay.Type;
    }
}
