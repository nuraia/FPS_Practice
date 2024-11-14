using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInteract : MonoBehaviour, IInteractable
{
    public void Increase()
    {
        UIManager.Instance.Score += 2;
        UIManager.Instance.CoinIncrease();
        UIManager.Instance.PointIncrease();
        Destroy(gameObject);
    }
}
