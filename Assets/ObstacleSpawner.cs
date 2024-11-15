using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstaclePrefab = new List<GameObject>();
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void ObjectSpawnning(GameObject road)
    {
        var instatiatedObstacle = Instantiate(obstaclePrefab[Random.Range(0, obstaclePrefab.Count)], road.transform);
        instatiatedObstacle.transform.position = new Vector3(Random.Range(-4, 5), 1.5f, Random.Range( 20, 50));
        Debug.Log("Obs" + instatiatedObstacle);
        
        //var instatiatedObstacle = Instantiate(obstaclePrefab, road);
    }
}
