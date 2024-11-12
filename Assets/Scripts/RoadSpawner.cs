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
    void Start()
    {
        SpawnRoad(0);
        SpawnRoad(1);
       
        for (int i = 0; i < NumberofRoad; i++)
        {
            if(i == 0) SpawnRoad(0);
            else SpawnRoad(Random.Range(0, RoadTile.Count -1));
        }
    }

    
    void Update()
    {
        if (PlayerTransform.position.z > zSpawn - (NumberofRoad * roadLength))
        {
            SpawnRoad(Random.Range(0, RoadTile.Count-1));
            DeleteTile();
        }
       
    }


    private void DeleteTile()
    {
        Destroy(activeRoad[0]);
        activeRoad.RemoveAt(0);
    }
   
    public void SpawnRoad(int index)
    {
        activeRoad.Add(Instantiate(RoadTile[index], transform.forward * zSpawn, transform.rotation));
        zSpawn += roadLength;
    }
}
