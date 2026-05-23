using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JSInputHandler : MonoBehaviour ,IPointerDownHandler,IDragHandler,IPointerUpHandler
{

    public RectTransform baseImage;
    public RectTransform handle;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHandleTransform(Vector2.zero);
    }

   public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)


    {



    }


    private void UpdateHandleTransform(Vector2 pos)
    {
        handle.anchoredPosition = pos;
    }

}
