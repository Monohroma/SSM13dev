using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//    //текст при наведении //    //текст если не наведено 
public class BackgroundBay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject yy_text;
    public void OnPointerEnter(PointerEventData eventData) 
    {
        yy_text.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        yy_text.SetActive(false);
    }
}

