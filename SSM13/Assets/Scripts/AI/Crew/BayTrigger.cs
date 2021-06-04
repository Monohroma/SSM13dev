using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ark; // Арк - гига пространство имён арса с двумя классами
using AI;
using UnityEngine.Events;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;


public class BayTrigger : MonoBehaviour
{
    public Tilemap coliderTileMap;
    public GameObject selectOutline;
    public GameObject disabledOutline;
    public GameObject buymess;
    public int Index; // Для дебага
    private Bay bay;
    public bool Bought { get { return bay.Purchased; } set { value = bay.Purchased;} } //Комментарии излишни 
    public bool Active { get { return bay.Active; } set { value = bay.Active; } }
    [HideInInspector]  public BayTypes Type;
    public UnityEvent OnClick;
    private void Start()
    {
        bay = GetComponent<Bay>();
        Type = bay.Type;
        if (bay.Purchased)
        {
            disabledOutline.SetActive(false);
        }
        else
        {
            disabledOutline.SetActive(true);
        }
        GenerateColliders();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Crew>())
        {
            if (collision.gameObject.GetComponent<Crew>().AccessLevel == Type)
            {
                bay.OnCrewEnter(collision.GetComponent<Crew>());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Crew>())
        {
            if (collision.gameObject.GetComponent<Crew>().AccessLevel == Type)
            {
                bay.OnCrewExit(collision.GetComponent<Crew>());
            }
        }
    }

    private void OnMouseOver()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (selectOutline != null && bay.Purchased)
                selectOutline.SetActive(true);
        }
        else
        {
            selectOutline.SetActive(false);
        }
    }

    private void OnMouseExit()
    {
        if (selectOutline != null && bay.Purchased)
            selectOutline.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            OnClick.Invoke();
        }
    }

    private void Update()
    {
        if (disabledOutline != null)
        {
            if (bay.Purchased)
            {
                disabledOutline.SetActive(false);
            }
            else
            {
                disabledOutline.SetActive(true);
            }
        }
    }

    // Тут лучше ничего не менять и не пытаться разобраться
    private void GenerateColliders()
    {
        if (coliderTileMap != null)
        {
            BoundsInt b = coliderTileMap.cellBounds;
            TileBase[] allTiles = coliderTileMap.GetTilesBlock(b);
            List<BoundsInt> colliders = new List<BoundsInt>();
            List<Vector2Int> allredyUsed = new List<Vector2Int>();
            TileBase tb;
            int i = 0, j = 0;
            for (i = b.xMin; i < b.xMax; i++)
            {
                for (j = b.yMin; j < b.yMax; j++)
                {
                    if (!allredyUsed.Contains(new Vector2Int(i, j)))
                    {
                        tb = coliderTileMap.GetTile(new Vector3Int(i, j, 0));
                        if (tb != null)
                        {
                            colliders.Add(CheckColider(i, j, b, ref allredyUsed));
                        }
                    }
                }
            }
            foreach (var item in colliders)
            {
                BoxCollider2D bc2 = gameObject.AddComponent<BoxCollider2D>();
                bc2.isTrigger = true;
                bc2.offset = item.center * 0.32f;
                bc2.size = ((Vector3)item.size) * 0.32f;
            }
        }
    }

    private BoundsInt CheckColider(int x, int y, BoundsInt bi, ref List<Vector2Int> usedP)
    {
        int i = 0, j = 0;
        int maxj = int.MaxValue;
        TileBase tb;
        for(i = x; i < bi.xMax; i++)
        {
            for(j = y; j < bi.yMax &&j < maxj; j++)
            {
                tb = coliderTileMap.GetTile(new Vector3Int(i, j, 0));
                if(tb == null || usedP.Contains(new Vector2Int(i, j)))
                {
                    break;
                }
            }
            if(maxj == int.MaxValue)
                maxj = j;
            else if(j != maxj)
            {
                return new BoundsInt(x, y, 0, i - x, maxj - y, 0);
            }
            for(j=y; j < bi.yMax && j<maxj;j++)
            {
                usedP.Add(new Vector2Int(i, j));
            }
        }
        return new BoundsInt(x, y, 0, i - x, maxj - y, 0);
    }
}
