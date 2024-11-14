using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    public Vector3 offset = Vector3.zero;
    
    void LateUpdate()
    {
        transform.position = cameraPosition.position + offset;
        //Vector3.Lerp(transform.position, cameraPosition.position, LerpTime);
    }
}
