using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler
{
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Debug.Log(eventData.position);
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("按钮按下");
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("按钮抬起");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("按钮抬起");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
