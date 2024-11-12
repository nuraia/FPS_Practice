using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI Point;
    public TextMeshProUGUI Totalpoint;
    public GameObject GameOverPanel;
    public int score ;
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        score = 0;
        GameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        Totalpoint.text = "Totalpoint : " + score;
    }

    public void PointIncrease()
    {
        Point.text = "Points : " + score;
    }
}
