using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    public Transform ParentAfterDrag;
    public Image image;
    private Image parentimg;

    void start()
    {
        //parentimg = GetComponent<Image>();
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("Begin");
        ParentAfterDrag = transform.parent;
        transform.SetParent(transform.root); //canvas k parent korlam
        transform.SetAsLastSibling(); // shobar upore jeno dekha jay
        image.raycastTarget = false;
       
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if(parentimg != null) Debug.Log("Draggin");
        
        transform.position = Input.mousePosition;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("end");
        transform.SetParent(ParentAfterDrag);
        image.raycastTarget = true;
    }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log(gameObject.name);
    }

}
