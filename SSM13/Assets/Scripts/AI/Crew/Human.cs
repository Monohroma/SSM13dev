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
            Debug.Log("���");
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
                                PerformWalkMove(bayList.FreeRestZone[i]); //��� ������, ���� � ������ �������� ��� true
                                break;
                            }
                        }                    
                }
                yield return new WaitForSeconds(delay / WasteOfEnergyCoefficent);
            }
            Debug.LogWarning("����� � �����");
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
                        Debug.Log("���� ������");
                        for (int i = 0; i < bayList.FreeKitchenZone.Count; i++)
                        {
                            if (bayList.FreeKitchenZone[i])
                            {
                                bayList.TakeKitchenPoint(i, gameObject);
                                PerformWalkMove(bayList.FreeKitchenZone[i]); //��� ������, ���� � ������ �������� ��� true
                                break;
                            }

                        }
                    }
                }
                yield return new WaitForSeconds(delay/WasteOfEnergyCoefficent);
            }
            StartCoroutine(HungerStrike());
            Debug.LogWarning("���������!!");
            yield break;
        }
        IEnumerator HungerStrike()
        {
            while(CurrentHp > 0 && food <= 0)
            {
                CurrentHp--;
                yield return new WaitForSeconds(0.3f);
            }
            Debug.LogWarning("����� �� ������");
            yield break;
        }
    }
}
