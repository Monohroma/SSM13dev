using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
namespace AI
{
    public abstract class Human : MonoBehaviour
    {
        
        protected AIDestinationSetter setter;
        protected float speed = 1;
        protected int rest = 100;
        protected int WasteOfEnergyCoefficent; // Коэффицент расхода энергии. Т.е если работает - rest и food снижается быстре, если не работает - медленее.
        protected readonly int MaxHp = 100;
        protected int CurrentHp = 100; //В будущем заменить на свойство 
        protected int food = 100;

        protected IMovable _IMovable; // Человек умеет ходить


        public void SetWalkBehaviour(IMovable behaviour) => _IMovable = behaviour; //Конструктор для выбранного варианта ходьбы
        public void ChangeMovement(IMovable movementBehavior)
        {
            _IMovable = movementBehavior;
        }

        public void PerformWalkSetSpeed(float speed) => _IMovable.SetMoveSpeed(speed); //Изменение скорости

        public void PerformWalkMove(Transform point) => _IMovable.Move(transform); // Куда идти

        private void Start()
        {
            StartCoroutine(HungerCoroutine(5f));
            StartCoroutine(FatigueCoroutine(7f));
        }
        IEnumerator FatigueCoroutine(float delay)
        {
            while(CurrentHp > 0 && rest > 0)
            {
                rest--;
                yield return new WaitForSeconds(delay / WasteOfEnergyCoefficent);

            }
            Debug.LogWarning("Устал");
            yield break;
        }
        IEnumerator HungerCoroutine(float delay)
        {
            while (CurrentHp >  0 && food > 0)
            {
                food--;
                yield return new WaitForSeconds(delay/WasteOfEnergyCoefficent);
            }
            StartCoroutine(HungerStrike());
            Debug.LogWarning("Голодовка!!");
            yield break;
        }
        IEnumerator HungerStrike()
        {
            while(CurrentHp > 0 && food <= 0)
            {
                CurrentHp--;
                yield return new WaitForSeconds(0.3f);
            }
            Debug.LogWarning("Помер от голода");
            yield break;
        }
    }
}
