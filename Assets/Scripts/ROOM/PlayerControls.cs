using System.Linq.Expressions;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;


public class PlayerControls : MonoBehaviour
{
    [Header("Movement Speeds")]
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float sprintMultiplier = 2f;

    [Header("Camera Settings")]
    [SerializeField] private bool invertYAxis = false;

    [Header("Jump Parameters")]
    [SerializeField] private float gravityValue = 9.81f;
    [SerializeField] private float jumpForce = 5f;

    [Header("Look Parameters")]
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float updownRange = 80f;

    private CharacterController _characterController;
    private Camera mainCamera;
    public FPSController _fpsController;

    private Vector3 currentMovement;
    private float verticalRotation;

    public GameObject instatiatedPanel;
    public BulletController bulletController;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();

        mainCamera = Camera.main;
    }


    void Update()
    {
        HandleMovement();
        HandleRotation();
       
    }
    void HandleMovement()
    {
        Vector3 inputDirection = new Vector3(_fpsController.MoveInput.x, 0f, _fpsController.MoveInput.y);
        Vector3 worldDirection = transform.TransformDirection(inputDirection);
        worldDirection = worldDirection.normalized;

        currentMovement.x = worldDirection.x * walkSpeed;
        currentMovement.z = worldDirection.z * walkSpeed;

        HandleJumping();
        _characterController.Move(currentMovement * Time.deltaTime);
    }

    void HandleJumping()
    {
        currentMovement.y = -0.5f;
        if(_fpsController.JumpInput)
        {
            currentMovement.y = jumpForce;
        }
        else
        {
            currentMovement.y -= gravityValue * Time.deltaTime;
        }
    }

    void HandleRotation()
    {
        float mouseYRotation = invertYAxis ? - _fpsController.LookInput.y : _fpsController.LookInput.y;
        float mouseXRotation = _fpsController.LookInput.x * mouseSensitivity;
        transform.Rotate(0, mouseXRotation, 0);

        verticalRotation -=  mouseYRotation * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -updownRange, updownRange);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
    
    //IEnumerator PanelStay(GameObject intantiatedPanel)
    //{
    //    yield return new WaitForSeconds(3);
    //    if (instatiatedPanel != null) Destroy(intantiatedPanel);
    //}
    //private void OnTriggerEnter(Collider col)
    //{
    //    if (col.gameObject.CompareTag("Door"))
    //    { //Debug.Log("ENTER");
    //        moveCamera.offset = new Vector3(1.5f, 1.2f, -1.2f);
    //        // moveCamera.GetComponentInChildren<LooKAroundController>().enabled = false;
    //    }
    //}

    //private void OnTriggerExit(Collider col)
    //{
    //    if (col.gameObject.CompareTag("Door"))
    //    {
    //        //Debug.Log("EXIT");
    //        moveCamera.offset = Vector3.zero;
    //        //moveCamera.GetComponentInChildren<LooKAroundController>().enabled = true;
    //        UIManager.Instance.POPUpGamePlayPanel();

    //    }
    //}

}
