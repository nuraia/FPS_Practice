using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        Score = 0;
        Life = 0;
        Coin = 0;
        //GameOverPanel.SetActive(false);
        InventoryButton.onClick.AddListener(OpenInventoryPanel);
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
    void OnGUI()
    {
        if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.I)
        {
            OpenInventoryPanel();
        }
    }
    public void OpenInventoryPanel()
    {
        InventoryPanel.DOAnchorPos(new Vector2(350, 0), 0.5f).SetUpdate(true); 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void CloseInventoryPanel()
    {
        InventoryPanel.DOAnchorPos(new Vector2(-300, 0), 0.5f).SetUpdate(true); 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
}