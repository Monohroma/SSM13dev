using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotWalkingPattern : IMovable
{
    //      (������� ���������)
    //���� �� ��������� ������ ��� NPC, ����������� � human �������������� ���������� IMovable ������� �������� ������ (����� � ��������, ������� ��������� ��������������� ���������)
    //����� ��� ����, ���� ������� ��� ������, �� ������� ��� ����������� (����� ����� ��� ������� ������ ���������� � �������)
    public void ChangeSprite()
    {
        throw new System.NotImplementedException();
    }

    public Vector2 GetMoveDirection()
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
