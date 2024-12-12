using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvetorySystem : MonoBehaviour
{
    public List<Item> Items = new List<Item>();
    public static InvetorySystem Instance;

    void Awake()
    {
        Instance = this;
        ItemPickup.OnPickedUp += AddItem;
    }

    private void OnDestroy()
    {
        ItemPickup.OnPickedUp -= AddItem;
    }
    public void AddItem(Item item)
    {
        Items.Add(item);
        Debug.Log($"{item.itemName} added");
    }
}
