using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public enum BayTypes { Cargo, Med, Security, Botanics, Kitchen, Research, Engineering, GreyZone, Bridge, None }
namespace Ark
{

    public class Bay : MonoBehaviour
    {
        public List<Crew> WorkersInBay = new List<Crew>(); // Если рабочий заходит в свою work zone, он начинает дико работать пока не упадёт без сил
        public List<Crew> AssignedToWork = new List<Crew>();
        public List<Transform> WorkZone = new List<Transform>();
        public GameObject WorkerPrefab;
        public int Energy => _energy;
        [Header("Bay options")]
        public BayTypes Type;
        [SerializeField] protected string _name;
        [SerializeField] protected int _energy;


        public int Cost => _cost;
        public bool Purchased => _bought;
        public bool Active;
        public bool Powered;
        public string BayName => _name;

        [Header("Dynamic Bay options")]
        [SerializeField] protected int _cost;
        [SerializeField] protected bool _bought = false;

        protected virtual void Start()
        {
            GameManager.Instance.AddBay(this);
            AddWorkerInList();
        }
        private void AddWorkerInList() 
        {
            foreach (var crew in GameManager.Instance.AllCrew)
            {
                if(crew.WorkBay == this)
                {
                    AssignedToWork.Add(crew);
                }
            }
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
        protected virtual void CheckBayActive()
        {
            if(WorkersInBay.Count > 0 && Powered && Purchased)
            {
                 Active = true;
            }
            else Active = false;
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
            if (Economics.Instance.SubtractMoney(Cost))
            {
                _bought = true;
            }
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
            {
                WorkersInBay.Add(crew);
                CheckBayActive();
            }
                
        }

        public virtual void OnCrewExit(Crew crew)
        {
            WorkersInBay.Remove(crew);
            CheckBayActive();
        }

        protected virtual void OnDestroy()
        {
            GameManager.Instance.RemoveBay(this);
        }
    }
}
