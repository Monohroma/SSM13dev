using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotWalkingPattern : IMovable
{

    //����� ��� ����, ���� ������� ��� ������, �� ������� ��� ����������� (����� ����� ��� ������� ������ ���������� � �������)
     
    public Vector3 GetMoveDirection()
    {
        throw new System.NotImplementedException(); //�� ������ �� �����, ���, �� ��� �� ��������?
    }

    public void Move(Transform point)
    {
        throw new System.NotImplementedException();
    }

    public float SetMoveSpeed(float speed)
    {
        throw new System.NotImplementedException();
    }
}
