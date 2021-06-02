using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityFinishedMovement : MonoBehaviour
{
    private AI.Security security;
    private GameObject NPC;
    private void Start()
    {
        security = GetComponentInChildren<AI.Security>();
        NPC = transform.GetChild(0).gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == NPC)
        {
            security.FinishedMovement();
        }
    }
}
