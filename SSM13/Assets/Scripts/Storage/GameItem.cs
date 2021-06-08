using System;
using UnityEngine;
using System.Collections;
using System.ComponentModel;
using Unity.Collections;



namespace Storage
{
    [CreateAssetMenu(menuName = "Item/StandartItem", fileName = "New Item")]
    public class GameItem : ScriptableObject
    {
        [Header("Item values")]
        [SerializeField] private string Name;
        [SerializeField] private int ID;
        [SerializeField] private int Price;
        
        [TextArea]
        [SerializeField] private string Description;
        
        [Space(1f)]
        [SerializeField] private Sprite Sprite;

        [Header("Don't change! / Only DEBUG")]
        [SerializeField] private int _count = 0;

        public string ItemName => Name;
        public int ItemID => ID;
        public int ItemPrice => Price;
        public string ItemDescription => Description;
        public int ItemCount => _count;
        //public bool IsEmpty => real_count == 0 ? true : false;
        public Sprite ItemSprite => Sprite;

        public void SetCount(int value)
        {
            if (value >= 0)
            {
                _count = value;
            }
        }

        public void AddCount(int value)
        {
            if (value >= 0)
            {
                _count += value;
            }
        }

        public void RemoveCount(int value)
        {
            if ((_count - value) < 0)
                throw new ArgumentOutOfRangeException(nameof(ItemCount), "The ItemCount value cannot become negative.");
            _count -= value;
        }

        public int GetCount()
        {
            return _count;
        }

    }
}
