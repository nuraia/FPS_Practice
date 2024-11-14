using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject road1; 
    public GameObject road2;
    public GameObject road3;  
    public float roadSpeed = 10f; 
    public float roadLength = 150f;  
    private Vector3 road1StartPos;
    private Vector3 road2StartPos;
    private Vector3 road3StartPos;
    void Start()
    {
        road1StartPos = road1.transform.position;
        road2StartPos = road2.transform.position;
        road3StartPos = road3.transform.position;
    }

    
    void FixedUpdate()
    {
        MoveRoad(road1);
        MoveRoad(road2);
        MoveRoad(road3);

        CheckAndResetRoad(road1, road1StartPos);
        CheckAndResetRoad(road2, road2StartPos);
        CheckAndResetRoad(road3, road3StartPos);

    }
    void MoveRoad(GameObject road)
    {
        road.transform.Translate(Vector3.back * roadSpeed * Time.deltaTime);
    }

   
    void CheckAndResetRoad(GameObject road, Vector3 roadStartPos)
    {
        if (road.transform.position.z <= -74 )
        {
            road.transform.position = Vector3.Lerp(road.transform.position, roadStartPos + new Vector3(0, 0, roadLength * 2), Time.deltaTime);

            roadStartPos = road.transform.position;
        }
        
    }
}
