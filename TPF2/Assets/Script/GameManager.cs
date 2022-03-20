using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public bool isGameOver;
    public bool isWin;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoresText;
    public GameObject gameOverPanel;
    public GameObject WinPanel;

    public int Objects;
    public int Enemy;
    
   
    /*A continuación creamos las funciones que haremos que funcionen en otros script pero que controlan el Ui 
      del canvas que controla el player. La puntuacióny los paneles de winner y loser*/ 

    public void UpdateObject(int pointToAdd)
    {
        Objects += pointToAdd;
        scoreText.text = Objects.ToString();
    }

    public void UpdateEn(int pointToAdd)
    {
        Enemy += pointToAdd;
        scoresText.text = Enemy.ToString();
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void Win()
    {
        isWin = true;
        WinPanel.SetActive(true);
    }
}
