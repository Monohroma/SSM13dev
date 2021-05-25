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
        private float _timer = 0;
        private UnityEvent OnEmptyEnergy = new UnityEvent();
        
        [Header("Energetics option")]
        public int EnergyConsumption;
        
        [Header("Timer option")]
        [SerializeField] private bool IsEnable = true;
        [SerializeField] private float TimerTimeValue = 1f;
        
        // ================ event MonoBehavior =================
        private void Awake() => _energeticsInstance = Energetics.Instance;
        private void Start() => _timer = TimerTimeValue;
        private void FixedUpdate()
        {
            if (IsEnable)
            {
                if (Time.time >= _timer)
                {
                    _timer = Time.time + TimerTimeValue;
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