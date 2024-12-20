using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotHandler : MonoBehaviour, IDropHandler
{
    void IDropHandler.OnDrop(PointerEventData eventData)
    {   
        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
        if (draggableItem != null)
        {
           // Debug.Log("exist");
            dropped.transform.SetParent(gameObject.transform);
            draggableItem.ParentAfterDrag = transform;
        }
        else
        {
            //Debug.LogError("not exist");
        }
    }
}
