using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstaclePrefab = new List<GameObject>();
    public List<GameObject> collectablePrefab = new List<GameObject>();
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void ObjectSpawnning(GameObject road)
    {
        var instatiatedObstacle = Instantiate(obstaclePrefab[Random.Range(0, obstaclePrefab.Count-1)], road.transform);
        instatiatedObstacle.transform.position = new Vector3(Random.Range(-4, 4), 1.5f, Random.Range(0, 20));
        Debug.Log("Obs" + instatiatedObstacle);
        var instatiatedCollectable = Instantiate(collectablePrefab[Random.Range(0, collectablePrefab.Count - 1)], road.transform);
        instatiatedCollectable.transform.position = new Vector3(Random.Range(-4, 4), 1.5f, Random.Range(0, 20));
        //var instatiatedObstacle = Instantiate(obstaclePrefab, road);
    }
}
