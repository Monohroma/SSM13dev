using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ark; // ��� - ���� ������������ ��� ���� � ����� ��������


public class BayTrigger : MonoBehaviour
{

    public int Index; // ��� ������
    private DynamicBay bay;
    private bool Bought { get { return bay.Purchased; } set { value = bay.Purchased;} } //����������� ������� 
    private bool Active = true;
    private BayTypes Type;
    private void Start()
    {
        bay= GetComponent<DynamicBay>();
        Type = bay.Type;
    }
}
