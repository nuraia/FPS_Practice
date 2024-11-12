using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CarMovementController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 Direction;
    public float forwardSpeed;
    private float laneDistance = 3f;
    private int LaneNumber = 1;
    private Vector3 trargetpostion;
    void Start()
    {
       trargetpostion = transform.position;
       controller = GetComponent<CharacterController>();
    }

   
    void Update()
    {
        Direction.z = forwardSpeed;
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

        trargetpostion = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (LaneNumber == 0) trargetpostion.x = -laneDistance  ;
        else if (LaneNumber == 2) trargetpostion.x = laneDistance;
        else trargetpostion.x = 0;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, trargetpostion, 2f * Time.deltaTime);
        controller.Move(Direction * Time.fixedDeltaTime);
    }

   
    
}
