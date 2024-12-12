using UnityEngine;
using System;
public class ItemPickup : MonoBehaviour
{
    public static Action<Item> OnPickedUp;
    public static event Action OnCoinCollected;
    public Item item;
    public bool inRange = false;
    public void Pickup()
    {
        OnPickedUp?.Invoke(item);
        OnCoinCollected?.Invoke();
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