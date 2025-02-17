
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
   
    public void SpawnObstaclesOnRoad(GameObject road)
    { 
        
        float roadLength = 150f; 
        Debug.Log(road);
       
        int numberOfObstacles = 10; 
        for (int i = 0; i < numberOfObstacles; i++)
        {
            float randomZPos = road.transform.position.z + Random.Range(0f, roadLength /2 );
            Vector3 randomPosition = new Vector3(Random.Range(-4f, 4), road.transform.position.y + 1.5f, randomZPos);
            var instantiatedObstacle =  ObjectPooler.Instance.SpawnFromPool("cube", randomPosition, Quaternion.identity);
            instantiatedObstacle.transform.SetParent(road.transform);
        }
    }
}
