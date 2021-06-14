using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ark
{
    public class Economics : MonoBehaviour
    {
        public delegate void ChangeMoney(int money);
        public event ChangeMoney MoneyChanged;
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
            if (value < 0)
			{
                throw new ArgumentOutOfRangeException(nameof(value), $"Can't subtract negative money value");
			}
            if ((_storedMoney - value) >= 0)
			{
                _storedMoney -= value;
                MoneyChanged(_storedMoney);
                return true;
            }
            return false;
        }

        public void AddMoney(int value)
        {
            if (value < 0)
			{
                throw new ArgumentOutOfRangeException(nameof(value), $"Can't add negative money value");
			}
            _storedMoney += value;
            MoneyChanged(_storedMoney);
        }
    }
}