using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonRotation : MonoBehaviour
{
   
    public Vector2 turn;
    
    

    /*A continuación indicamos que si el juego no estña pausado cumpla con su proposito de rotar de izquierda a derecha y de que esconda y centre el ratón en el centro
     Si el juego está pausado esto se ignora*/
    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            turn.x += Input.GetAxis("Mouse X");

            transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0f; 
        }

    }
}
