using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInteract : MonoBehaviour, IInteractable
{
    public void Increase()
    {
        UIManager.Instance.Score ++;
        UIManager.Instance.PointIncrease();
        Destroy(gameObject);
    }
}
