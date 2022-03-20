using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour
{

  
    public Text scoreText;
    public Text HighscoreText;
    int score = 0;
    int highscore = 0;

    public void Awake()
    {
       
    }

    void Start()
    {
        scoreText.text = score.ToString();
        HighscoreText.text = highscore.ToString();
    }

    public void AddZombiePoint()
    {
        score += 1;
        scoreText.text = score.ToString();
    }
    
    public void AddBoxesPoint()
    {
        
            highscore += 1;
            HighscoreText.text = highscore.ToString();
        
    }
    

}



 