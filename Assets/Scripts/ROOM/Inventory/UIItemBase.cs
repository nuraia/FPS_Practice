using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIItemBase : MonoBehaviour
{
    public string itemName;
    public int itemId;
    public GameObject itemPrefab;

    public void SetInfo(string name, int id, GameObject item)
    {
        itemName = name;
        itemId = id;
        itemPrefab = item;
    }

    public void OnClickCancel(GameObject obj)
    {
        InvetorySystem.Instance.RemoveItem(obj);
    }
}
