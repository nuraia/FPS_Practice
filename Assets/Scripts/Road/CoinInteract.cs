using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInteract : MonoBehaviour, IInteractable
{
    void Update()
    {
        transform.Rotate(0, 20 * Time.deltaTime, 0);
    }
    public void Increase()
    {
        UIManager.Instance.Score += 2;
        UIManager.Instance.CoinIncrease();
        UIManager.Instance.PointIncrease();
        Destroy(gameObject);
    }
}
