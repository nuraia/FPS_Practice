using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    
    void LateUpdate()
    {
        transform.position = cameraPosition.position;
        //Vector3.Lerp(transform.position, cameraPosition.position, LerpTime);
    }
}
