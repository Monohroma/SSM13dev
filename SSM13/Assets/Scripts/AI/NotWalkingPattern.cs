using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotWalkingPattern : IMovable
{

    // ласс дл€ того, если человек мог ходить, но утратил эту возможность (вс€ко лучше чем плодить другие интерфейсы и костыли)
     
    public Vector3 GetMoveDirection()
    {
        throw new System.NotImplementedException(); //ќн ходить не умеет, лол, на что ты надеелс€?
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
