using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ark
{
    public class Energetics : MonoBehaviour
    {
        // ====================== fields =======================
        [Header("Energetics value")]
        [SerializeField] private int _storedEnergy;
        [SerializeField] private float _updateGeneratorsDelay = 1;

        public int StoredEnergy => _storedEnergy;
        public bool IsEmpty => _storedEnergy == 0 ? true : false;

        public float UpdateGeneratersDelay => _updateGeneratorsDelay;

        private UnityEngine.Coroutine _generatorUpdater;

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
                generators = GameManager.Instance.currentGenerators;
                for (i = 0; i < generators.Count; i++)
                {
                    if (generators[i] != null)
                    {
                        generators[i].Generate();
                    }
                    else
                    {
                        GameManager.Instance.RemoveGenerator(generators[i]);
                    }
                }
                bays = GameManager.Instance.currentBays;
                for(i = 0; i < bays.Count; i++)
                {
                    if(bays[i] != null)
                    {
                        SubtractEnergy(bays[i].Energy);
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