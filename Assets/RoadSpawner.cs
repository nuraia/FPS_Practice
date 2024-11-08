using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject roadSection1;
    public GameObject roadSection2;
    public Transform road1EP;
    public Transform road2EP;
    public float speed;
    void Start()
    {
        roadSection1.transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }

    
    void FixedUpdate()
    {

        roadSection1.transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        roadSection2.transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }

}
