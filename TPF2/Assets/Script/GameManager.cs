using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public bool isGameOver;
    public bool isWin;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoresText;
    public GameObject gameOverPanel;
    public GameObject WinPanel;
    private bool IsWin;
    public int Opoints;
    public int Epoints;

    void Start()

    {

        Epoints = 19;
        Opoints = 9;
    }

    /*A continuación creamos las funciones que haremos que funcionen en otros script pero que controlan el Ui 
      del canvas que controla el player. La puntuacióny los paneles de winner y loser*/
    private void Update()
    {
        if (!IsWin && Epoints == 20 && Opoints == 10)
        {
            StartCoroutine(YouWin());
            IsWin = true;
        }
    }
    public void UpdateObject()
    {
        Opoints ++;
        scoreText.text = Opoints.ToString();
    }

    public void UpdateEn()
    {
        Epoints ++;
        scoresText.text = Epoints.ToString();
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

    private IEnumerator YouWin()
    {
        Win();
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Cursor.lockState = CursorLockMode.Confined;
    }
}
