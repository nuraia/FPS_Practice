using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public bool inRange = false;
    public void Pickup()
    {
        InvetorySystem.Instance.AddItem(item);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        inRange = true;
    }

    void OnTriggerExit(Collider col)
    {
        inRange = false;
    }
    void OnMouseDown()
    {
        if (inRange)
        {
            Pickup();
        }
      
    }
}
