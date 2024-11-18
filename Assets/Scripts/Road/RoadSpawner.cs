
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public ObstacleSpawner obstacleSpawner;
    public GameObject road1; 
    public GameObject road2;
    //public GameObject road3;  
    public float roadSpeed = 10f; 
    public float roadLength = 150f;  
    private Vector3 road1StartPos;
    private Vector3 road2StartPos;
    //private Vector3 road3StartPos;
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
       // road3StartPos = road3.transform.position;
        road2StartPos = road1StartPos + new Vector3(0, 0, roadLength);
       // road3StartPos = road2StartPos + new Vector3(0, 0, roadLength);

        road2.transform.position = road2StartPos;
        //road3.transform.position = road3StartPos;
    }

    
    void FixedUpdate()
    {
        CheckAndResetRoad(ref road1, ref road1StartPos);
        CheckAndResetRoad(ref road2, ref road2StartPos);
       // CheckAndResetRoad(ref road3, ref road3StartPos);
    }
   

    void CheckAndResetRoad(ref GameObject road, ref Vector3 roadStartPos)
    { Debug.Log($"road : {road}, Reset Pos : {roadStartPos}");
            if (road.transform.position.z <= ResetPosition.position.z)
            {
                
                road.transform.position =  SetPosition.position;
                roadStartPos = road.transform.position;
                obstacleSpawner.SpawnObstaclesOnRoad(road); 
                
            }
          
    }
}
