using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CarMovementController : MonoBehaviour
{
   
    public float turnSpeed;
    public RoadSpawner roadSpawner;
    private float laneDistance = 3f;
    private int LaneNumber = 1;
    private Vector3 trargetpostion;
    void Start()
    {
       trargetpostion = transform.position;
    }

   
    void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.A))
        {
            LaneNumber--;
            Debug.Log("left " + LaneNumber);
            if (LaneNumber < 0) LaneNumber = 0;
            //Debug.Log("left");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            LaneNumber++;
            Debug.Log("right " + LaneNumber);
            if (LaneNumber > 2) LaneNumber = 2;
            //Debug.Log("right");
             
        }
        
        //trargetpostion  = new Vector3(transform.position.x, transform.position.y, transform.position.z); ;
        if (LaneNumber == 0) trargetpostion.x = -laneDistance  ;
        else if (LaneNumber == 2) trargetpostion.x = laneDistance;
        else trargetpostion.x = 0;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, trargetpostion, 2f * Time.deltaTime);
        //transform.position = trargetpostion;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("road1"))
        {
            Debug.Log("road 1");
            roadSpawner.roadSection2.transform.localPosition = roadSpawner.road1EP.position;
            
        }
        else
        {
            Debug.Log("road 2");
            roadSpawner.roadSection1.transform.localPosition = roadSpawner.road2EP.position;
            
        }
    }
}
