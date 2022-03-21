using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        Cursor.visible = true; //Queremos que se vea el cursor
        Cursor.lockState = CursorLockMode.None; //que no se bloquee en el centro
    }
    public void PlayGame ()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1); //Pase a la siguiente escena. 

        
    }

    public void QuitGame() //Abandona el juego. 
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }

}


