using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ark
{
    public class Energetics : MonoBehaviour
    {
        public delegate void EnergyBool();
        public event EnergyBool EnergyChangedBool;
        // ====================== fields =======================
        [Header("Energetics value")]
        [SerializeField] private int _storedEnergy;
        [SerializeField] private float _updateGeneratorsDelay = 1;
        [SerializeField] private int _maxEnergy = 100000;

        public int StoredEnergy => _storedEnergy;
        public bool IsEmpty => _storedEnergy == 0 ? true : false;

        public bool IsPower
        {
            get
            { 
                return _powered;
            }

            set
            {
                _powered = value;
                EnergyChangedBool?.Invoke();
            }                        
}

public float UpdateGeneratersDelay => _updateGeneratorsDelay;

        public int InEnergy => _in_energy;
        public int OutEnergy => _out_energy;

        public int MaxEnergy { get { return _maxEnergy; } set { _maxEnergy = value; } }

        private UnityEngine.Coroutine _generatorUpdater;
        private bool _powered = false;
        private int _in_energy = 0;
        private int _out_energy = 0;

        // ===================== instance ======================
        private static Energetics _instance;
        public static Energetics Instance
        {
            get
            {
                if (_instance == null) _instance = GameObject.FindObjectOfType<Energetics>();
                return _instance;
            }
        }

        // ====================== method =======================

        private void Start()
        {
            _generatorUpdater = StartCoroutine(GeneratorsUpdater());
        }
        public bool SubtractEnergy(int value)
        {
            if ((_storedEnergy - value) < 0)
            {
                _storedEnergy = 0;
                return false;
            }
            _storedEnergy -= value;
            return true;
        }

        public void AddEnergy(int value)
        {
            if (value >= 0)
            {
                _storedEnergy += value;
            }
            else throw new ArgumentOutOfRangeException(nameof(value),
                $"The {nameof(value)} value cannot be negative.");
        }

        private IEnumerator GeneratorsUpdater()
        {
            List<Generator> generators;
            List<Bay> bays;
            int i;
            while (true)
            {
                IsPower = false;
                generators = GameManager.Instance.currentGenerators;
                _in_energy = 0;
                for (i = 0; i < generators.Count; i++)
                {
                    if (generators[i] != null)
                    {
                        _in_energy += generators[i].Generate();
                    }
                    else
                    {
                        GameManager.Instance.RemoveGenerator(generators[i]);
                    }
                }
                AddEnergy(_in_energy);
                if (_storedEnergy > 0)
                    IsPower = true;
                bays = GameManager.Instance.currentBays;
                _out_energy = 0;
                for(i = 0; i < bays.Count; i++)
                {
                    if(bays[i] != null)
                    {
                        _powered = SubtractEnergy(bays[i].Energy);
                        _out_energy += bays[i].Energy;
                    }
                    else
                    {
                        GameManager.Instance.RemoveBay(bays[i]);
                    }
                }
                yield return new WaitForSeconds(_updateGeneratorsDelay);
            }
        }
    }
}