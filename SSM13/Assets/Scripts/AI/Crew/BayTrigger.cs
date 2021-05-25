using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ark; // ��� - ���� ������������ ��� ���� � ����� ��������
using AI;

public class BayTrigger : MonoBehaviour
{

    public int Index; // ��� ������
    private Bay bay;
    public bool Bought { get { return bay.Purchased; } set { value = bay.Purchased;} } //����������� ������� 
    public bool Active { get { return bay.Active; } set { value = bay.Active; } }
    [HideInInspector]  public BayTypes Type;
    private void Start()
    {
        bay = GetComponent<Bay>();
        Type = bay.Type;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {    
        if(collision.tag == "NPC")
        {
            if(collision.gameObject.GetComponent<Crew>().AccessLevel == Type)
            {
                bay.OnCrewEnter(collision.GetComponent<Crew>());
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            if (collision.gameObject.GetComponent<Crew>().AccessLevel == Type)
            {
                bay.OnCrewExit(collision.GetComponent<Crew>());
            }
        }
    }
}
