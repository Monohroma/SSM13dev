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

        public List<Generator> workingGenerators = new List<Generator>();

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
        public void SubtractEnergy(int value)
        {
            if ((_storedEnergy - value) < 0)
                throw new ArgumentOutOfRangeException(nameof(StoredEnergy),
                    $"The {nameof(StoredEnergy)} value cannot become negative.");
            _storedEnergy -= value;
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
            while (true)
            {
                for (int i = 0; i < workingGenerators.Count; i++)
                {
                    if (workingGenerators[i] != null)
                    {
                        workingGenerators[i].Generate();
                    }
                    else
                    {
                        workingGenerators.RemoveAt(i);
                        i--;
                    }
                }

                yield return new WaitForSeconds(_updateGeneratorsDelay);
            }
        }

        public static void AddGenerator(Generator generator)
        {
            if(!Instance.workingGenerators.Contains(generator))
                Instance.workingGenerators.Add(generator);
        }

        public static void RemoveGenerator(Generator generator)
        {
            Instance.workingGenerators.Remove(generator);
        }
        
    }
}