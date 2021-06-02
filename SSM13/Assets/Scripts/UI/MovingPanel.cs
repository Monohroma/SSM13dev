using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovingPanel : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Vector3 startPos = Vector3.zero;
    private Vector2 lastpos = Vector2.zero;
    private Vector2 tp;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        lastpos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        tp = eventData.position - lastpos;
        rectTransform.position += new Vector3(tp.x, tp.y, 0);
        lastpos = eventData.position;
    }

    public void ResetPosition()
    {
        if(rectTransform!=null)
            rectTransform.position = startPos;
    }
}
