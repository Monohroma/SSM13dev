using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ark;

public class VentPowerCheck : MonoBehaviour
{
    private Energetics energetics;
    private Animator animator;
    private void Awake()
    {
        energetics = GameObject.FindObjectOfType<Energetics>();
        energetics.EnergyChangedBool += VentPowerChanged;
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        energetics.EnergyChangedBool += VentPowerChanged;
    }
    private void OnDisable()
    {
        energetics.EnergyChangedBool -= VentPowerChanged;
    }
    private void VentPowerChanged(bool IsPower)
    {
        if (IsPower)
        {
            Debug.Log("Вент вкл");
            animator.SetBool("Power", true);
        }
        else
        {
            Debug.Log("Вент выкл");
            animator.SetBool("Power", false);
        }
    }
}
