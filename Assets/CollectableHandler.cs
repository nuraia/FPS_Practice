using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectableHandler : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    { Debug.Log("HEHE");
        if (col.gameObject.CompareTag("car"))
        {
            UIManager.Instance.score++;
            UIManager.Instance.PointIncrease();
            Destroy(gameObject);
        }
    }
}
