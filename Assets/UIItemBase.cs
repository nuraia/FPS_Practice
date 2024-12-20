using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIItemBase : MonoBehaviour
{
    public string itemName;
    public int itemId;


    public void SetInfo(string name, int id)
    {
        itemName = name;
        itemId = id;
    }
}
