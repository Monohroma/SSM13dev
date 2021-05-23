using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
namespace AI
{
    public abstract class Human : MonoBehaviour
    {        
        protected AIDestinationSetter setter;
        protected BayList bayList;
        protected float speed = 1;
        public int rest = 100;
        protected int WasteOfEnergyCoefficent = 1; // Коэффицент расхода энергии. Т.е если работает - rest и food снижается быстре, если не работает - медленее.
        protected readonly int MaxHp = 100;
        public int CurrentHp = 100; //В будущем заменить на свойство 
        public int food = 100;
        public bool IsWork; //Люди могут работать, а могут и не работать.........
        protected IMovable _IMovable; // Человек умеет ходить

        public void SetWalkBehaviour(IMovable behaviour)
        {
            _IMovable = behaviour; //Конструктор для выбранного варианта ходьбы
        }
        public void ChangeMovement(IMovable movementBehavior) //Сменить паттерн ходьбы
        {
            _IMovable = movementBehavior;
        }
        public void PerformWalkSetSpeed(float speed)
        {
            _IMovable.SetMoveSpeed(speed);
        }
        public void PerformWalkMove(Transform point)
        {
            Debug.Log("Идёт");
            _IMovable.Move(transform);
        }
        protected void StartNeedCoroutine(bool HumanGoesToKitchen = false, bool HumanGoesToRest = false, BayList bayList = null)
        {
            StartCoroutine(HungerCoroutine(2.1f,HumanGoesToKitchen, bayList));
            StartCoroutine(FatigueCoroutine(3.2f,HumanGoesToRest, bayList));
        }
        IEnumerator FatigueCoroutine(float delay, bool restInRestZone = false, BayList bayList = null)
        {
           while(CurrentHp > 0 && rest > 0)
            {
                rest--;
                if(rest <= 10 && restInRestZone)
                {
                        for (int i = 0; i < bayList.FreeRestZone.Count; i++)
                        {
                            if (bayList.FreeRestZone[i])
                            {
                                bayList.TakeRestPoint(i, gameObject);
                                PerformWalkMove(bayList.FreeRestZone[i]); //Идёт кушать, если в вызове корутины бул true
                                break;
                            }
                        }                    
                }
                yield return new WaitForSeconds(delay / WasteOfEnergyCoefficent);
            }
            Debug.LogWarning("Устал и помер");
            yield break;
        }
        IEnumerator HungerCoroutine(float delay, bool isEatingInKitchen = false, BayList bayList = null)
        {
            while (CurrentHp >  0 && food > 0)
            {
                food--;
                if (food <= 25 && isEatingInKitchen)
                {
                    if (bayList.Kitchen.Bought && bayList.Kitchen.Active)
                    {
                        Debug.Log("Пора поесть");
                        for (int i = 0; i < bayList.FreeKitchenZone.Count; i++)
                        {
                            if (bayList.FreeKitchenZone[i])
                            {
                                bayList.TakeKitchenPoint(i, gameObject);
                                PerformWalkMove(bayList.FreeKitchenZone[i]); //Идёт кушать, если в вызове корутины бул true
                                break;
                            }

                        }
                    }
                }
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
