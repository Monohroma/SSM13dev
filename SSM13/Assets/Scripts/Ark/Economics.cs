using System;
using UnityEngine;

namespace Ark
{
    public class Economics : MonoBehaviour
    {
        // ============= fields =============
        [Header("Economics value")]
        [SerializeField] private int _storedMoney;

        public int StoredMoney => _storedMoney;
        public bool IsEmpty => _storedMoney == 0 ? true : false;
        
        // ============= instance =============
        private static Economics _instance;
        /// <summary>
        /// Переменная которая хранит экземпляр класса
        /// </summary>
        public static Economics Instance
        {
            get
            {
                if (_instance == null) _instance = GameObject.FindObjectOfType<Economics>();
                return _instance;
            }
        }
        
        // ============= method =============

        public void dev_SubtractMoney(int value)
        {
            if ((_storedMoney - value) < 0)
                throw new ArgumentOutOfRangeException(nameof(StoredMoney),
                    $"The {nameof(StoredMoney)} value cannot become negative.");
            _storedMoney -= value;
        }

        /// <summary>
        /// Вычитает денюжку из банка
        /// </summary>
        /// <param name="value">Количество денег которое будет вычтено</param>
        /// <returns>Возвращает true, если операция выполнена. False если обратное</returns>
        public bool SubtractMoney(int value)
        {
            if ((_storedMoney - value) < 0) return false;
            _storedMoney -= value;
            return true;
        }

        public void AddMoney(int value)
        {
            if (value >= 0)
            {
                _storedMoney += value;
            }
            else throw new ArgumentOutOfRangeException(nameof(value),
                $"The {nameof(value)} value cannot be negative.");
        }
    }
}