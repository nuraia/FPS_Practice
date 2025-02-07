using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooKAroundController : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public Transform Oriantation;
    private float rotationX;
    private float rotationY;

    void LateUpdate()
    {
       // if (Input.GetMouseButton(0))
        //{
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            rotationY += mouseX;
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);

            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
            Oriantation.rotation = Quaternion.Euler(0, rotationY, 0);
        //}
    }
}
