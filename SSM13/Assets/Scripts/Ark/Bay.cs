using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public enum BayTypes { Cargo, Med, Security, Botanics, Kitchen, Research, Engineering, GreyZone, Bridge }
namespace Ark
{

    public class Bay : MonoBehaviour
    {
        protected List<Human> WorkersInBay = new List<Human>(); // Если рабочий заходит в свою work zone, он начинает дико работать пока не упадёт без сил
        public List<Transform> WorkZone = new List<Transform>();
        public int Energy => _energy;
        [Header("Bay options")]
        public BayTypes Type;
        [SerializeField] protected string _name;
        [SerializeField] protected int _energy;


        public int Cost => _cost;
        public bool Purchased => _bought;
        public bool Active;
        public bool Powered;

        [Header("Dynamic Bay options")]
        [SerializeField] protected int _cost;
        [SerializeField] protected bool _bought = false;

        protected virtual void Start()
        {
            GameManager.Instance.AddBay(this);
        }

        public virtual void AddConsumptionEnergy(int value)
        {
            if (value >= 0)
            {
                _energy += value;
            }
        }

        public virtual void RemoveConsumptionEnergy(int value)
        {
            if (_energy - value >= 0)
            {
                _energy -= value;
            }
            else
            {
                _energy = 0;
            }
        }

        public virtual void SetConsumptionEnergy(int newEnergy)
        {
            if (newEnergy >= 0)
            {
                _energy = newEnergy;
            }
        }

        public virtual string GetEnergyFormat()
        {
            float kw = _energy / 1000;
            float mw = kw / 1000;

            if (mw >= 1) return mw.ToString() + "MW";
            else if (kw >= 1) return kw.ToString() + "KW";
            else return _energy.ToString() + "W";
        }

        public virtual void BuyBay()
        {
            _bought = true;
        }

        public virtual void SetCost(int newCost)
        {
            if (newCost >= 0)
            {
                _cost = newCost;
            }
        }

        public virtual void DoEveryTick()
        {

        }

        public virtual void OnCrewEnter(Crew crew)
        {
            if (!WorkersInBay.Contains(crew))
                WorkersInBay.Add(crew);
        }

        public virtual void OnCrewExit(Crew crew)
        {
            WorkersInBay.Remove(crew);
        }

        protected virtual void OnDestroy()
        {
            GameManager.Instance.RemoveBay(this);
        }
    }
}
