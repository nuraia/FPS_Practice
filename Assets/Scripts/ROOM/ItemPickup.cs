using UnityEngine;
using System;
using UnityEngine.InputSystem;
public class ItemPickup : MonoBehaviour
{
    public static Action<Item> OnPickedUp;
    public static event Action OnCoinCollected;
    public Item item;
    public bool inRange = false;

    private void OnEnable()
    {
        FPSController.instance.collectAction.performed += OnPickedUpItem;
    }
    private void OnDisable()
    {
        FPSController.instance.collectAction.performed -= OnPickedUpItem;
    }
    public void Pickup()
    {
        OnPickedUp?.Invoke(item);
        OnCoinCollected?.Invoke();
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider col)
    {
        inRange = true;
    }

    void OnTriggerExit(Collider col)
    {
        inRange = false;
    }
    public void OnPickedUpItem(InputAction.CallbackContext context)
    {
        if (inRange)
        {
            Pickup();
        }

    }
    //void OnGUI()
    //{
    //    if (inRange && Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Space)
    //    {
    //        Pickup();
    //    }
    //}

}
