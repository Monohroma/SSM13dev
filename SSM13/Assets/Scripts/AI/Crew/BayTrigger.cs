using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ark; // Арк - гига пространство имён арса с двумя классами
using AI;
using UnityEngine.Events;

public class BayTrigger : MonoBehaviour
{
    public SpriteRenderer select_box;
    public int Index; // Для дебага
    private Bay bay;
    public bool Bought { get { return bay.Purchased; } set { value = bay.Purchased;} } //Комментарии излишни 
    public bool Active { get { return bay.Active; } set { value = bay.Active; } }
    [HideInInspector]  public BayTypes Type;
    public UnityEvent OnClick;
    private void Start()
    {
        bay = GetComponent<Bay>();
        Type = bay.Type;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Crew>())
        {
            if (collision.gameObject.GetComponent<Crew>().AccessLevel == Type)
            {
                bay.OnCrewEnter(collision.GetComponent<Crew>());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Crew>())
        {
            if (collision.gameObject.GetComponent<Crew>().AccessLevel == Type)
            {
                bay.OnCrewExit(collision.GetComponent<Crew>());
            }
        }
    }

    private void OnMouseEnter()
    {
        if(select_box != null)
            select_box.enabled = true;
    }

    private void OnMouseExit()
    {
        if (select_box != null)
            select_box.enabled = false;
    }

    private void OnMouseDown()
    {
        OnClick.Invoke();
    }
}
