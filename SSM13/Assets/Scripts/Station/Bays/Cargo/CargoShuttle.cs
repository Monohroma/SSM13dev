using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CargoShuttle : MonoBehaviour // скрипт предназначен для добавления координат тайлов в лист и дальнейшего использования этих координат для спавна предметов. можно было бы сделать массив вместо листа, но в лист удобнее редактировать
{
    public Tilemap tileMap; // тайлмапа с полом каргошатла

    public List<Vector3> availablePlaces; // Трансформы тайлов на тайлмапе
    
   private void Awake()
    {
        tileMap = GameObject.Find("CargoShittleFloor").GetComponent<Tilemap>();
        availablePlaces = new List<Vector3>();

        for (int x = tileMap.cellBounds.xMin; x < tileMap.cellBounds.xMax; x++)
        {
            for (int y = tileMap.cellBounds.yMin; y < tileMap.cellBounds.yMax; y++)
            {
                Vector3Int localPlace = new Vector3Int(x, y, (int)tileMap.transform.position.z);
                Vector3 place = tileMap.CellToWorld(localPlace);
                
                if (tileMap.HasTile(localPlace))
                {
                    //Tile at "place"
                    availablePlaces.Add(place);
                }
                else
                {
                    //No tile at "place"
                }
            }
        }
    }
}
