using System.Collections;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public ObstacleSpawner obstacleSpawner;
    public GameObject road1;
    public GameObject road2;
    public float roadSpeed = 10f;
    public float roadLength = 150f;
    private Vector3 road1StartPos;
    private Vector3 road2StartPos;
    public Transform ResetPosition;
    public Transform SetPosition;
    public static RoadSpawner Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        road1StartPos = road1.transform.position;
        road2StartPos = road2.transform.position;

        road2StartPos = road1StartPos + new Vector3(0, 0, roadLength);

        road2.transform.position = road2StartPos;

        StartCoroutine(CheckAndResetRoadCoroutine());
    }

  
    private IEnumerator CheckAndResetRoadCoroutine()
    {
        while (true)
        {
            CheckAndResetRoad(ref road1, ref road1StartPos);
            CheckAndResetRoad(ref road2, ref road2StartPos);
            yield return new WaitForSeconds(0.1f);  
        }
    }

    void CheckAndResetRoad(ref GameObject road, ref Vector3 roadStartPos)
    {
        if (road.transform.position.z <= ResetPosition.position.z)
        {
            road.transform.position = SetPosition.position;
            roadStartPos = road.transform.position;
            obstacleSpawner.SpawnObstaclesOnRoad(road);
        }
    }
}