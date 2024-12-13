using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvetorySystem : MonoBehaviour
{
    public List<Item> Items = new List<Item>();
    public static InvetorySystem Instance;
    public GameObject itemPrefab;
    public GameObject slotPrefab;
    public Transform inventoryContent;
    private int index;
    void Awake()
    {
        Instance = this;
        ItemPickup.OnPickedUp += AddItem;
        index = 0;
    }

    private void OnDestroy()
    {
        ItemPickup.OnPickedUp -= AddItem;
    }
    public void AddItem(Item item)
    {
        Items.Add(item);
        //Debug.Log($"{item.itemName} added");
        GameObject obj = Instantiate(itemPrefab, inventoryContent);
        RectTransform objRect = obj.GetComponent<RectTransform>();
        objRect.localPosition = Vector3.zero;
        objRect.localScale = Vector3.one;
        obj.transform.SetParent(inventoryContent, false);
        Image objImage = itemPrefab.GetComponentInChildren<Image>();
        objImage.sprite = item.image;
        index++;
    }


}
