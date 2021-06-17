using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomPointGenerator : MonoBehaviour
{
    //Генерирует случайную точку из тайлампы GreyZone
    public GameObject empty;
    public Tilemap GreyZone; //Задаётся вручную
    private List<Vector3> tileWorldLocations;
    private void Awake()
    {
        empty = new GameObject();
        UpdateTileList();
    }
    public void UpdateTileList()
    {
        tileWorldLocations = new List<Vector3>();
        foreach (var pos in GreyZone.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            Vector3 place = GreyZone.CellToWorld(localPlace);
            if (GreyZone.HasTile(localPlace))
            {
                tileWorldLocations.Add(place);
            }
        }
    }
    public Transform RandomPointGenerate()
    {
        Vector2 randomPoint = tileWorldLocations[Random.Range(0, tileWorldLocations.Count)];
        var emptyTransform = Instantiate(empty.transform, randomPoint, Quaternion.identity);
        StartCoroutine(DestroyEmptyTransforms(emptyTransform.gameObject));
        return emptyTransform; //Супер костылище (в А* можно только transform передавать)
    }
    IEnumerator DestroyEmptyTransforms(GameObject transform)
    {
        yield return new WaitForSeconds(0.0002f);
        Destroy(transform);
        yield break;
    }
}
