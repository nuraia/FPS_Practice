using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotHandler : MonoBehaviour, IDropHandler
{
    private GameObject dropped;
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            dropped = eventData.pointerDrag;
            DraggableItem draggbleItem = dropped.GetComponent<DraggableItem>();
            draggbleItem.ParentAfterDrag = transform;
        }
      
    }

    public int CheckSlotItem()
    {
        return dropped.GetComponent<UIItemBase>()?.itemId ?? -1;
        
    }

    private void OnEnable()
    {
        CraftSystem.OnClearSlot += EmptySlot;
    }

    private void OnDisable()
    {
        CraftSystem.OnClearSlot -= EmptySlot;
    }

    public void EmptySlot()
    {
        Destroy(dropped);
    }
}
