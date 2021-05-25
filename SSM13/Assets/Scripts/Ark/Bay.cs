using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public enum BayTypes { Cargo, Med, Security, Botanics, Kitchen, Research, Engineering, GreyZone, Bridge }
namespace Ark
{

    public class Bay : MonoBehaviour
    {
        private List<Human> WorkersInBay = new List<Human>(); // Если рабочий заходит в свою work zone, он начинает дико работать пока не упадёт без сил
        public int Energy => _energy;
        [Header("Bay options")]
        public BayTypes Type;
        [SerializeField] protected string _name;
        [SerializeField] protected int _energy;


        public int Cost => _cost;
        public bool Purchased => _bought;
        public bool Active;

        [Header("Dynamic Bay options")]
        [SerializeField] protected int _cost;
        [SerializeField] protected bool _bought = false;

        private void Start()
        {
            GameManager.Instance.AddBay(this);
        }

        public void AddConsumptionEnergy(int value)
        {
            if (value >= 0)
            {
                _energy += value;
            }
        }

        public void SetConsumptionEnergy(int newEnergy)
        {
            if (newEnergy >= 0)
            {
                _energy = newEnergy;
            }
        }

        public string GetEnergyFormat()
        {
            float kw = _energy / 1000;
            float mw = kw / 1000;

            if (mw >= 1) return mw.ToString() + "MW";
            else if (kw >= 1) return kw.ToString() + "KW";
            else return _energy.ToString() + "W";
        }

        public void BuyBay()
        {
            _bought = true;
        }

        public void SetCost(int newCost)
        {
            if (newCost >= 0)
            {
                _cost = newCost;
            }
        }

        private void OnDestroy()
        {
            GameManager.Instance.RemoveBay(this);
        }
    }
}