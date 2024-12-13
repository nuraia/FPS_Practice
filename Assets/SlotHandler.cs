using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotHandler : MonoBehaviour, IDropHandler
{
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggbleItem = dropped.GetComponent<DraggableItem>();
            draggbleItem.ParentAfterDrag = transform;
        }
      
    }
}
