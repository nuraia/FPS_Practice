using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour, IPooledObject
{
    
    public void OnObjectSpawn()
    {
        Debug.Log("Obs");
    }

    private void OnTriggerEnter(Collider col)
    {
        ObjectPooler.Instance.poolDictionary["cube"].Enqueue(gameObject);
        Debug.Log("Triggered");
    }
}
