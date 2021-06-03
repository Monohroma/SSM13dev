using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotWalkingPattern : IMovable
{
    //      (Паттерн стратегия)
    //Один из паттернов ходьбы для NPC, назначается в human приравниванием переменной IMovable нужному паттерну ходьбы (класс с патерном, который реализует соответствующий интерфейс)
    //Класс для того, если человек мог ходить, но утратил эту возможность (всяко лучше чем плодить другие интерфейсы и костыли)
    public void ChangeSprite()
    {
        throw new System.NotImplementedException();
    }

    public Vector2 GetMoveDirection()
    {
        throw new System.NotImplementedException(); //Он ходить не умеет, лол, на что ты надеелся?
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
