using System;
using UnityEngine;

namespace Ark
{
    public class Energetics : MonoBehaviour
    {
        // ====================== fields =======================
        [Header("Energetics value")]
        [SerializeField] private int _storedEnergy;

        public int StoredEnergy => _storedEnergy;
        public bool IsEmpty => _storedEnergy == 0 ? true : false;
        
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
        
    }
}