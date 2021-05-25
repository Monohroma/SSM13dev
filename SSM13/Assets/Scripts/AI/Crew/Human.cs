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
        protected int WasteOfEnergyCoefficent = 1; // ���������� ������� �������. �.� ���� �������� - rest � food ��������� ������, ���� �� �������� - ��������.
        protected readonly int MaxHp = 100;
        public int CurrentHp = 100; //� ������� �������� �� �������� 
        public int food = 100;
        public bool IsWork; //���� ����� ��������, � ����� � �� ��������.........
        public bool NPCIsEating;
        public bool NPCIsRest;
        public bool Goes;
        protected IMovable _IMovable; // ������� ����� ������

        public void SetWalkBehaviour(IMovable behaviour)
        {
            _IMovable = behaviour; //����������� ��� ���������� �������� ������
        }
        public void ChangeMovement(IMovable movementBehavior) //������� ������� ������
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
                                PerformWalkMove(bayList.FreeRestZone[i]); //��� ��������, ���� � ������ �������� ��� true
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
                            PerformWalkMove(bayList.FreeRestZone[i]); //��� ��������, ���� � ������ �������� ��� true
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
                                PerformWalkMove(bayList.FreeKitchenZone[i]); //��� ������, ���� � ������ �������� ��� true
                                break;
                            }

                        }
                    }
                }
                yield return new WaitForSeconds(delay/WasteOfEnergyCoefficent);
            }
            StartCoroutine(HungerStrike(delay, isEatingInKitchen, bayList)); //���� � �����������, �� �����
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
                                PerformWalkMove(bayList.FreeKitchenZone[i]); //��� ������, ���� � ������ �������� ��� true
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
