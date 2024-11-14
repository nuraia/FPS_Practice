using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartInteract : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public void Increase()
    {
        UIManager.Instance.Score++;
        UIManager.Instance.LifeIncrease(); 
        UIManager.Instance.PointIncrease();
        Destroy(gameObject);
    }
}
