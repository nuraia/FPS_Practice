using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI Point;
    public TextMeshProUGUI Totalpoint;
    public TextMeshProUGUI LifeText;
    public TextMeshProUGUI CoinText;
    public GameObject GameOverPanel;
    public GameObject GamePlayPanel;
    public RectTransform InventoryPanel;
    public Button playButton;
    public Button InventoryButton;
    public int Score;
    public int Life;
    public int Coin;

    //[Header("Inventory Action Map Name Reference")]
    //[SerializeField] private string actionmapName2 = "InventorySystem";

    //[Header("Action Name Reference")]
   
    //[SerializeField] private string navigate = "Navigate";
    //[SerializeField] private string select = "Select";
    //[SerializeField] private string drop = "Drop";

   
    //public InputAction navigateAction;
    //public InputAction selectAction;
    //public InputAction dropAction;

    //public Vector2 MoveInput { get; private set; }
    //public Vector2 LookInput { get; private set; }
    //public bool JumpInput { get; private set; }
    //public bool FireInput { get; private set; }
    //public bool CollectInput { get; private set; }
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        Score = 0;
        Life = 0;
        Coin = 0;
        //GameOverPanel.SetActive(false);
        
    }
   
    public void GameOver()
    {
        Point.text = "";
        GameOverPanel.SetActive(true);
        Totalpoint.text = "Totalpoint : " + Score;
    }

    public void PointIncrease()
    {
        Point.text = "Points : " + Score;
    }

    public void POPUpGamePlayPanel()
    {
        GamePlayPanel.SetActive(true);
        playButton.onClick.AddListener(OnClickPlay);
    }

    public void OnClickPlay()
    {
        Debug.Log("PLAY");
        SceneManager.LoadScene(1);
    }

    public void LifeIncrease()
    {
        Life++;
        LifeText.text = Life + "";
    }

    public void CoinIncrease()
    {
        Coin++;
        CoinText.text = Coin + "";
    }

    public void OpenInventoryPanel()
    {
        InventoryPanel.DOAnchorPos(new Vector2(350, 0), 0.5f).SetUpdate(true); 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
  
    }

    public void CloseInventoryPanel()
    {
        InventoryPanel.DOAnchorPos(new Vector2(-300, 0), 0.5f).SetUpdate(true); 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FPSController.instance.playerInput.SwitchCurrentActionMap("Player");
    }
}