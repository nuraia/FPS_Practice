using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

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
        Transform objt = obj.GetComponent<Transform>();
        objt.localPosition = Vector3.zero;
        objt.localScale = Vector3.one;
        obj.transform.SetParent(inventoryContent, false);
        Image objImage = itemPrefab.GetComponentInChildren<Image>();
        objImage.sprite = item.image;
        index++;
    }

    public void RemoveItem(GameObject obj)
    {
        //Items.Remove();
        Debug.Log(obj);
    }
}
