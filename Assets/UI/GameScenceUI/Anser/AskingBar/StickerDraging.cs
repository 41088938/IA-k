using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class StickerDraging : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField]  Image sticker;
    RectTransform rec;
   
    [SerializeField] Canvas canvas;
    void Awake()
    {
        rec = GetComponent<RectTransform>();
        sticker = GetComponent<Image>();
        
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
      
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        rec.anchoredPosition += eventData.delta / canvas.scaleFactor;
        sticker.raycastTarget = false;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
       
       
        sticker.raycastTarget = true;
    }
    }


  