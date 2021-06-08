using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CargoShuttle : MonoBehaviour // ������ ������������ ��� ���������� ��������� ������ � ���� � ����������� ������������� ���� ��������� ��� ������ ���������. ����� ���� �� ������� ������ ������ �����, �� � ���� ������� �������������
{
    public Tilemap tileMap; // �������� � ����� ����������

    public List<Vector3> availablePlaces; // ���������� ������ �� ��������
    
   private void Awake()
    {
        tileMap = GameObject.Find("CargoShittleFloor").GetComponent<Tilemap>();
        availablePlaces = new List<Vector3>();

        for (int n = tileMap.cellBounds.xMin; n < tileMap.cellBounds.xMax; n++)
        {
            for (int p = tileMap.cellBounds.yMin; p < tileMap.cellBounds.yMax; p++)
            {
                Vector3Int localPlace = new Vector3Int(n, p, (int)tileMap.transform.position.z);
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
