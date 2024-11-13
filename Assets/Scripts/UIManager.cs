using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI Point;
    public TextMeshProUGUI Totalpoint;
    public GameObject GameOverPanel;
    public int Score ;
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        Score = 0;
        GameOverPanel.SetActive(false);
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
}
