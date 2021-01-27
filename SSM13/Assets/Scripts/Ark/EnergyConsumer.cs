using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Ark
{
    public class EnergyConsumer : MonoBehaviour
    {
        // ====================== fields =======================
        private Energetics _energeticsInstance;
        private float _timer;
        private UnityEvent OnEmptyEnergy = new UnityEvent();
        
        [Header("Energetics option")]
        public int EnergyConsumption;
        
        [Header("Timer option")]
        [SerializeField] private bool IsEnable = true;
        [SerializeField] private float TimerTimeValue = 1f;
        
        // ================ event MonoBehavior =================
        private void Awake() => _energeticsInstance = Energetics.Instance;
        private void Start() => _timer = TimerTimeValue;
        private void Update()
        {
            if (IsEnable)
            {
                _timer -= Time.deltaTime;
                if (_timer <= 0)
                {
                    _timer = TimerTimeValue;
                    if (_energeticsInstance.IsEmpty) OnEmptyEnergy?.Invoke();
                    else
                    {
                        _energeticsInstance.SubtractEnergy(EnergyConsumption);
                    }
                }
            }
        }
    }
}