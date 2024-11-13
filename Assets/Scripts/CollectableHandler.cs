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
        transform.Rotate(0f, 20 * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("car"))
        {
            UIManager.Instance.Score++;
            UIManager.Instance.PointIncrease();
            Destroy(gameObject);
            
        }
    }
    
}
