using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Animator doorAnim;
    void Start()
    {
        doorAnim = GetComponent<Animator>();
    }


    //Ниже должна быть проверка на то есть ли доступ в отсек у НПС
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "NPC")
        {
            doorAnim.SetBool("Open", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            doorAnim.SetBool("Open", false);
        }
    }
}
