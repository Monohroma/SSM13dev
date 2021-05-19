using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPointGenerator : MonoBehaviour
{
    public MapLimit MapLimit;
    public Transform Point;
   public Transform RandomPointGenerate(BayTypes levelAccess)
    {
        Vector2 RandomPoint;
        RandomPoint.x = Random.Range(MapLimit.XminCameraDistance, MapLimit.XmaxCameraDistance);
        RandomPoint.y = Random.Range(MapLimit.YminCameraDistance, MapLimit.YmaxCameraDistance);
        Point.transform.position = RandomPoint;
        RaycastHit hit;
        Ray ray = new Ray(RandomPoint, Vector2.down);
        Physics.Raycast(ray, out hit);
        if (hit.collider.gameObject.GetComponent<BayTrigger>().Type == levelAccess)
        {
            return Point;
        }
        RandomPointGenerate(levelAccess);
        return null;
    }
}
