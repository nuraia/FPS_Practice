using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CarMovementController : MonoBehaviour
{
    public RoadSpawner roadSpawner;
    private CharacterController controller;
    private Vector3 Direction;
    public float forwardSpeed;
    private float laneDistance = 3.5f;
    private int LaneNumber = 1;
    private Vector3 trargetpostion;
    void Start()
    {
       trargetpostion = transform.position;
       controller = GetComponent<CharacterController>();
    }

   
    void Update()
    {
       // Direction.z = forwardSpeed;
        if (Input.GetKeyDown(KeyCode.A))
        {
            LaneNumber--;
            //Debug.Log("left " + LaneNumber);
            if (LaneNumber < 0) LaneNumber = 0;
            //Debug.Log("left");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            LaneNumber++;
            //Debug.Log("right " + LaneNumber);
            if (LaneNumber > 2) LaneNumber = 2;
            //Debug.Log("right");

        }

        //trargetpostion  =  transform.up * transform.position.y + transform.position.z * transform.forward;
        if (LaneNumber == 0) trargetpostion.x = -laneDistance;
        else if (LaneNumber == 2) trargetpostion.x = laneDistance;
        else trargetpostion.x = 0;
        trargetpostion.z = transform.position.z;
    }

    void FixedUpdate()
    {
       transform.position = Vector3.Lerp(transform.position, trargetpostion, 2f * Time.deltaTime);
        //transform.position = trargetpostion;
        //controller.Move(Direction * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            gameObject.GetComponent<CarMovementController>().enabled = false;
         
            roadSpawner.road1.GetComponent<RoadMovement>().enabled = false;
            roadSpawner.road2.GetComponent<RoadMovement>().enabled = false;
            //roadSpawner.road3.GetComponent<RoadMovement>().enabled = false;
            
            UIManager.Instance.GameOver();
        }
        if(col.gameObject.CompareTag("collectable"))
        {
            col.gameObject.GetComponent<IInteractable>().Increase();
        }
    }
    
}
