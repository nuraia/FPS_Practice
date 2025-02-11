using System.Linq.Expressions;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;


public class PlayerControls : MonoBehaviour
{
    [SerializeField] private PlayerInput m_playerInput;
    private InputAction moveAction;
    private InputAction jump;
    private InputAction shoot;
    private bool IsGrounded;
    private Vector3 m_playerVelocity;
    private float jumpHeight = 0.5f;
    private float gravityValue = -9.81f;
    private CharacterController _characterController;
    private Transform playerCamera;
    public MoveCamera moveCamera;
    private Camera cam;
    public GameObject instatiatedPanel;
    public BulletController bulletController;
    void Start()
    {
        _characterController = GetComponent<CharacterController>(); 
        m_playerInput = GetComponent<PlayerInput>();
        moveAction = m_playerInput.actions.FindAction("Movement");
        jump = m_playerInput.actions.FindAction("Jump");
        shoot = m_playerInput.actions.FindAction("Fire");
        playerCamera = Camera.main.transform;
    }


    void Update()
    {
        IsGrounded = _characterController.isGrounded;
        MovePlayer();
        if (!IsGrounded)
        {
            m_playerVelocity.y += gravityValue * Time.deltaTime;
        }
        if (IsGrounded && m_playerVelocity.y < 0 ) m_playerVelocity.y = 0f;
        if (jump.IsPressed() && IsGrounded)
        {
            JumpPlayer();

        }
        _characterController.Move(m_playerVelocity * Time.deltaTime);

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.CompareTag("Obstacle"))
                {
                    var instatiated = Instantiate(instatiatedPanel, hit.transform);
                    instatiated.transform.rotation = Quaternion.LookRotation(gameObject.transform.forward);
                    StartCoroutine("PanelStay",instatiated); 

                    
                }
            }
        }
        if(bulletController != null)
        {
            if (shoot.IsPressed())
            {
                bulletController.GunShooting(true);
            }
        }
    }

    IEnumerator PanelStay(GameObject intantiatedPanel)
    {
        yield return new WaitForSeconds(3);
        if (instatiatedPanel != null) Destroy(intantiatedPanel);
    }

    private void MovePlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        Vector3 moveDirection = transform.forward * direction.y + transform.right * direction.x;
        _characterController.Move(moveDirection * Time.deltaTime * 3);
    }

    private void JumpPlayer()
    {
        m_playerVelocity.y += Mathf.Sqrt(jumpHeight * gravityValue * -2f);

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Door"))
        { //Debug.Log("ENTER");
            moveCamera.offset = new Vector3(1.5f, 1.2f, -1.2f);
           // moveCamera.GetComponentInChildren<LooKAroundController>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Door"))
        {
            //Debug.Log("EXIT");
            moveCamera.offset = Vector3.zero;
            //moveCamera.GetComponentInChildren<LooKAroundController>().enabled = true;
            UIManager.Instance.POPUpGamePlayPanel();
           
        }
    }

}
