using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
namespace AI
{
    public class Human : MonoBehaviour 
    {
        public Sprite Up;
        public Sprite Down;
        public Sprite Right;
        public Sprite Left;
        private SpriteRenderer spriteRenderer;
             
        protected delegate void Action();
        protected event Action NextAction;

        protected AIDestinationSetter setter;
        protected BayList bayList;
        protected float speed = 1;
        public int rest = 100;
        protected int WasteOfEnergyCoefficent = 1; // Коэффицент расхода энергии. Т.е если работает - rest и food снижается быстре, если не работает - медленее.
        protected readonly int MaxHp = 100;
        public int CurrentHp = 100; //В будущем заменить на свойство 
        public int food = 100;
        public bool IsWork; //Люди могут работать, а могут и не работать.........
        public bool NPCIsEating;
        public bool NPCIsRest;
        public bool Goes;
        protected IMovable _IMovable; // Человек умеет ходить
        protected IWork _IWork; //Члены экипажа могут работать! Исключение ассистент кроме что (но бомл гений сделает заглушку-класс без работы)
        protected void HumanStartMethod()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
        public void StartEating(KitchenZone KitchenZone)
        {
            if (!NPCIsEating)
            {
                Debug.Log(gameObject.name + " ест в кухне");
                NPCIsEating = true;
                StartCoroutine(Eating(KitchenZone));
            }
        }
        public void StopEating(KitchenZone KitchenZone)
        {
            StopCoroutine("Eating");
            NPCIsEating = false;
            KitchenZone.PointIsBusy = false;
            KitchenZone.NPCInPoint = null;
        }
        public void StartRest(RestZone RestZone)
        {
            if (!NPCIsRest)
            {
                Debug.Log(gameObject.name + " отдыхает");
                NPCIsRest = true;
                StartCoroutine(Rest(RestZone));
            }
        }
        public void StopRest(RestZone RestZone)
        {
            StopCoroutine("Rest");
            NPCIsRest = false;
            RestZone.PointIsBusy = false;
            RestZone.NPCInPoint = null;
        }
        IEnumerator Rest(RestZone restZone)
        {
            while (NPCIsRest && rest < 100)
            {
                rest++;
                yield return new WaitForSeconds(0.5f);
            }
            restZone.PointIsBusy = false;
            restZone.NPCInPoint = null;
            NPCIsRest = false;
        }
        IEnumerator Eating(KitchenZone KitchenZone)
        {
            while (NPCIsEating && food < 100)
            {
                food++;
                if (!KitchenZone.BayAvailable())
                {
                    StopEating(KitchenZone);
                    yield break;
                }
                yield return new WaitForSeconds(0.3f);
            }
            KitchenZone.PointIsBusy = false;
            KitchenZone.NPCInPoint = null;
            NPCIsEating = false;
            if (_IWork != null) 
            {
                NextAction?.Invoke();
            }
        }
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
            _IMovable.Move(point);
            StopCoroutine(SpriteDirection());
            StartCoroutine(SpriteDirection());
        }
        protected IEnumerator SpriteDirection()
        {
            while (Goes)
            {
                Vector3 temp = transform.position;
                yield return new WaitForSeconds(0.003f); //Частота опроса изменения вектора
               if(temp.x < transform.position.x) 
                {
                    spriteRenderer.sprite = Right;        //Тернарный оператор нынче не в моде
                }
               else if(temp.x > transform.position.x)
                {
                    spriteRenderer.sprite = Left;
                }
               else if(temp.y < transform.position.y)
                {
                    spriteRenderer.sprite = Up;
                }
               else if(temp.y > transform.position.y)
                {
                    spriteRenderer.sprite = Down;
                }
            }
            yield break;
            
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
                if(rest <= 10 && restInRestZone && !NPCIsEating && !NPCIsRest && !Goes)
                {
                        for (int i = 0; i < bayList.FreeRestZone.Count; i++)
                        {
                            if (bayList.FreeRestZone[i])
                            {
                                bayList.TakeRestPoint(i, gameObject);
                                Goes = true;
                                PerformWalkMove(bayList.FreeRestZone[i]); //Идёт отдыхать, если в вызове корутины бул true
                                break;
                            }
                        }                    
                }
                yield return new WaitForSeconds(delay / WasteOfEnergyCoefficent);
            }
            StartCoroutine(Overwork(delay,restInRestZone,bayList));
            yield break;
        }
        IEnumerator Overwork(float delay, bool restInRestZone = false, BayList bayList = null)
        {
            while (CurrentHp > 0)
            {
                if (rest <= 0 && restInRestZone && !NPCIsEating && !NPCIsRest && !Goes)
                {
                    for (int i = 0; i < bayList.FreeRestZone.Count; i++)
                    {
                        if (bayList.FreeRestZone[i])
                        {
                            bayList.TakeRestPoint(i, gameObject);
                            Goes = true;
                            PerformWalkMove(bayList.FreeRestZone[i]); //Идёт отдыхать, если в вызове корутины бул true
                            break;
                        }
                    }
                }
                else if(rest > 0)
                {
                    StartCoroutine(FatigueCoroutine(delay, restInRestZone, bayList));
                    yield break;
                }
                if(!NPCIsEating && !NPCIsRest)
                {
                    CurrentHp--;
                }
                yield return new WaitForSeconds(0.3f);
            }
            yield break;
        }
        IEnumerator HungerCoroutine(float delay, bool isEatingInKitchen = false, BayList bayList = null)
        {
            while (CurrentHp >  0 && food > 0)
            {
                food--;
                if (food <= 15 && isEatingInKitchen)
                {
                    if (bayList.Kitchen.Bought && bayList.Kitchen.Active && !NPCIsEating && !NPCIsRest && !Goes)
                    {
                        for (int i = 0; i < bayList.FreeKitchenZone.Count; i++)
                        {
                            if (bayList.FreeKitchenZone[i])
                            {
                                bayList.TakeKitchenPoint(i, gameObject);
                                Goes = true;
                                PerformWalkMove(bayList.FreeKitchenZone[i]); //Идёт кушать, если в вызове корутины бул true
                                break;
                            }

                        }
                    }
                }
                yield return new WaitForSeconds(delay/WasteOfEnergyCoefficent);
            }
            StartCoroutine(HungerStrike(delay, isEatingInKitchen, bayList)); //Цирк с параметрами, не бейте
            yield break;
        }
        IEnumerator HungerStrike(float delay, bool isEatingInKitchen = false, BayList bayList = null)
        {
            while(CurrentHp > 0)
            {
                if (food == 0 && isEatingInKitchen && !NPCIsRest && !NPCIsEating && !Goes)
                {
                    if (bayList.Kitchen.Bought && bayList.Kitchen.Active && !NPCIsEating && !Goes)
                    {
                        for (int i = 0; i < bayList.FreeKitchenZone.Count; i++)
                        {
                            if (bayList.FreeKitchenZone[i])
                            {
                                bayList.TakeKitchenPoint(i, gameObject);
                                Goes = true;
                                PerformWalkMove(bayList.FreeKitchenZone[i]); //Идёт кушать, если в вызове корутины бул true
                                break;
                            }

                        }
                    }
                }
                else if(food > 0)
                {
                    StartCoroutine(HungerCoroutine(delay, isEatingInKitchen, bayList));
                    yield break;
                }
                if (!NPCIsEating && !NPCIsRest)
                {
                    CurrentHp--;
                }
                yield return new WaitForSeconds(0.3f);
            }
            yield break;
        }
    }
}
