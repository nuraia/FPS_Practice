using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> RoadTile = new List<GameObject>();
    public List<GameObject> activeRoad = new List<GameObject>();
    public float zSpawn = 0;
    public float roadLength = 150;
    public int NumberofRoad = 2;
    public Transform PlayerTransform;
    public float roadMoveSpeed = 5f;
    void Start()
    {
        SpawnRoad(0);
        SpawnRoad(1);
       
        //for (int i = 0; i < NumberofRoad; i++)
        //{
        //    if(i == 0) SpawnRoad(0);
        //    else SpawnRoad(Random.Range(0, RoadTile.Count -1));
        //}
    }

    
    void Update()
    {
        MoveRoadForward();
        if (activeRoad[0].transform.position.z * -1 >  roadLength / 2)
        {
            
            SpawnRoad(Random.Range(0, RoadTile.Count-1));
            DeleteTile();
        }

    }
    private void MoveRoadForward()
    {
        foreach (GameObject road in activeRoad)
        {
            road.transform.Translate(Vector3.back * roadMoveSpeed * Time.deltaTime);
        }
    }

    private void DeleteTile()
    {
        Destroy(activeRoad[0]);
        activeRoad.RemoveAt(0);
    }
   
    public void SpawnRoad(int index)
    {
        Vector3 spawnPosition = new Vector3(0, 0, zSpawn);
        GameObject newRoad = Instantiate(RoadTile[index], spawnPosition, transform.rotation);
        activeRoad.Add(newRoad);
        zSpawn = activeRoad[0].transform.position.z + 150;
        Debug.Log("Spawning Road at z position: " + zSpawn);
    }
}
