using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ark
{
    public class Bay : MonoBehaviour
    {
        public string Name => _name;
        public int Energy => _energy;

        protected string _name;
        protected int _energy;
        
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
    }

    public class DynamicBay : Bay
    {
        public int Cost => _cost;
        public bool Purcased => _bought;
        
        private int _cost;
        private bool _bought = false;

        public DynamicBay(string name, int energy, int costBay)
        {
            _name = name;
            _energy = energy;
            _cost = costBay;
        }

        public void BuyBay() 
        {
            _bought = true;
        }

        public void SetCount(int newCost)
        {
            if (newCost >= 0)
            {
                _cost = newCost;
            }
        }
    }
}
