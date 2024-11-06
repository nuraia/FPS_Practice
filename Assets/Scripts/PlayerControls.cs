using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private PlayerInput m_playerInput;
    private InputAction moveAction;
    private InputAction jump;
    private bool IsGrounded;
    private Vector3 m_playerVelocity;
    private float jumpHeight = 5f;
    private float gravityValue = -9.81f;
    private CharacterController _characterController;
    void Start()
    {
        _characterController = GetComponent<CharacterController>(); 
        m_playerInput = GetComponent<PlayerInput>();
        moveAction = m_playerInput.actions.FindAction("Movement");
        jump = m_playerInput.actions.FindAction("Jump");
     
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

    }

    private void MovePlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(direction.x, 0, direction.y);
        _characterController.Move(move * Time.deltaTime);

    }

    private void JumpPlayer()
    {
        m_playerVelocity.y += Mathf.Sqrt(jumpHeight * gravityValue * -2f);

       
       
    }

   
}
