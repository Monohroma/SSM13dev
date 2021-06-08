using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPointGenerator : MonoBehaviour
{
    //Генерирует случайную точку внутри коллайдера отсека, с указанным доступом в параметрах (в вызове метода)
    public Transform Point;
    private BayList bayList;
    private void Awake()
    {
        bayList = GameObject.FindObjectOfType<BayList>();
    }

    public Transform RandomPointGenerate(BayTypes levelAccess)
    {
        Vector2 RandomPoint;

        for (int i = 0;i < bayList.Bays.Count; i++ )
        {
            if (bayList.Bays[i].GetComponent<BayTrigger>().Type == BayTypes.GreyZone) //Временно
            {
                var BayCollider = bayList.Bays[i].GetComponent<BoxCollider2D>();
                RandomPoint.x = Random.Range(bayList.Bays[i].gameObject.transform.position.x - BayCollider.size.x/2, bayList.Bays[i].gameObject.transform.position.x + BayCollider.size.x/2);
                RandomPoint.y = Random.Range(bayList.Bays[i].gameObject.transform.position.y - BayCollider.size.y/2, bayList.Bays[i].gameObject.transform.position.y + BayCollider.size.y/2);
                Point.transform.position = RandomPoint;
                return Point;
            }
        }
        return null;
    }
}
