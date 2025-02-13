using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSController : MonoBehaviour
{
    public static FPSController instance;
    public PlayerInput playerInput;

    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset playerControls;

    [Header("Player Action Map Name Reference")]
    [SerializeField] private string actionmapName = "Player";

    [Header("Action Name Reference")]
    [SerializeField] private string move = "Movement";
    [SerializeField] private string look = "Look";
    [SerializeField] private string jump = "Jump";
    [SerializeField] private string fire = "Fire";
    [SerializeField] private string collect = "Collect";
    [SerializeField] private string menu = "InventoryMenu";

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;
    public InputAction fireAction;
    public InputAction collectAction;
    public InputAction inventoryButtonAction;
   
    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }
    public bool JumpInput { get; private set; }
    public bool FireInput { get; private set; }
    public bool CollectInput { get; private set; }
    public bool inventoryButtonInput { get; private set; }
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        moveAction = playerControls.FindActionMap(actionmapName).FindAction(move);
        lookAction = playerControls.FindActionMap(actionmapName).FindAction(look);
        jumpAction = playerControls.FindActionMap(actionmapName).FindAction(jump);
        fireAction = playerControls.FindActionMap(actionmapName).FindAction(fire);
        collectAction = playerControls.FindActionMap(actionmapName).FindAction(collect);
        inventoryButtonAction = playerControls.FindActionMap(actionmapName).FindAction(menu);
        playerInput = GetComponent<PlayerInput>();
        RegisterInputAction();
    }
    void RegisterInputAction()
    {
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => MoveInput = Vector2.zero;

        lookAction.performed += context => LookInput = context.ReadValue<Vector2>();
        lookAction.canceled += context => LookInput = Vector2.zero;

        jumpAction.performed += context => JumpInput = true;
        jumpAction.canceled += context => JumpInput = false;

        fireAction.performed += context => FireInput = true;
        fireAction.canceled += context => FireInput = false;

        collectAction.performed += context => CollectInput = true;
        collectAction.canceled += context => CollectInput = false;

        inventoryButtonAction.performed += SwitchActionMap;
        inventoryButtonAction.canceled += SwitchActionMap;
    }
    void OnEnable()
    {
        moveAction.Enable();
        lookAction.Enable();
        jumpAction.Enable();
        fireAction.Enable();
        collectAction.Enable();
        inventoryButtonAction.Enable();

    }
    void OnDisable()
    {
        moveAction.Disable();
        lookAction.Disable();
        jumpAction.Disable();
        fireAction.Disable();
        collectAction.Disable();
        inventoryButtonAction.Disable();
    }

    public void SwitchActionMap(InputAction.CallbackContext context)
    {
        playerInput.SwitchCurrentActionMap("InventorySystem");
        UIManager.Instance.OpenInventoryPanel();
    }

    
}
