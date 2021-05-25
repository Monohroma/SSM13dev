using Ark;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int power { get { return _power; } set { SetPower(value); } }
    public bool working { get { return _working; } set { SetWorking(value); } }

    [SerializeField]protected bool _working = false;
    [SerializeField] protected int _power = 100;

    private void Start()
    {
        GameManager.Instance.AddGenerator(this);
    }

    private void OnDestroy()
    {
        GameManager.Instance.RemoveGenerator(this);
    }

    public virtual void Generate()
    {
        if(_working)
            Energetics.Instance.AddEnergy(_power);
    }

    public virtual void SetWorking(bool work)
    {
        _working = work;
    }

    public virtual void SetPower(int power)
    {
        _power = power;
    }
}
