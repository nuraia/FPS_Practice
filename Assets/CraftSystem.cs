using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftSystem : MonoBehaviour
{
    public static event Action OnClearSlot;
    public List<Image> slots = new List<Image>();
    public List<Recepie> recepies = new List<Recepie>();
    private int count;
    private string recepie ;
    public GameObject craftedItem;
    public InvetorySystem inventorySys;
    public void OnClickCraft()
    {
        count = 0;
        foreach (var varE in slots)
        {
            if (varE.transform.childCount > 0) count++;
        }

        if (count >= 3) Slotcheck();
    }

    public void Slotcheck()
    {
        recepie = "";
        foreach (var varE in slots)
        {
            var slotitemid = varE.GetComponent<SlotHandler>().CheckSlotItem();
            recepie += slotitemid;
        }

        RecepieMatch(recepie);
    }

    public void RecepieMatch(string recepie)
    {
       
        foreach (var varE in recepies)
        { 
           
            if (varE.id == recepie)
            {
                inventorySys.AddItem(varE.finalRecepie);
                OnClearSlot.Invoke();
            }
        }
    }
}
