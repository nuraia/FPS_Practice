
using UnityEngine;
using System;


public class AmmoIncreasePickable : MonoBehaviour
{
    public static event Action OnAmmoIncreaseCollected;
    public void Pickup()
    {
     
        OnAmmoIncreaseCollected?.Invoke();
        gameObject.SetActive(false);
    }

    void OnGUI()
    {
        if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Space)
        {
            Pickup();
        }
    }
}
