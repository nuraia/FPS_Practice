using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
    public int Score ;
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

    }

    public void OnClickPlay()
    {
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
}
