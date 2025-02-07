using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InvetorySystem : MonoBehaviour
{
    public List<Item> Items = new List<Item>();
    public static InvetorySystem Instance;
    public GameObject itemPrefab;
    public GameObject player;
    public Transform inventoryContent;
 
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
        //Debug.Log($"{item.itemName} added");
        Image objImage = itemPrefab.GetComponentInChildren<Image>();
        objImage.sprite = item.image;
        GameObject obj = Instantiate(itemPrefab, inventoryContent);
        Transform objt = obj.GetComponent<Transform>();
        objt.localPosition = Vector3.zero;
        objt.localScale = Vector3.one;
        obj.transform.SetParent(inventoryContent, false);
        var itemBase = obj.GetComponent<UIItemBase>();
        itemBase.SetInfo(item.itemName, item.id, item.itemObject);
    }

    public void RemoveItem(GameObject obj)
    {
        UIItemBase itemBase = obj.GetComponent<UIItemBase>();
        Item itemtoRemoved = Items.Find(item => item.id == itemBase.itemId);
        if (itemtoRemoved != null)
        {
            Items.Remove(itemtoRemoved);
            Vector3 newPos = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
            var newobj =  Instantiate(itemBase.itemPrefab, newPos, Quaternion.identity);
            Destroy(obj);
        }
    }
}
