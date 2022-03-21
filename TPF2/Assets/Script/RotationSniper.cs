using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSniper : MonoBehaviour
{
    
    public Vector2 turn;



  //Aquí indicamos que si el juego no está pausado se rote según el movimiento vertical del ratón. Si nó, si el juego está pausado que no se mueva. 
    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            turn.y += Input.GetAxis("Mouse Y");
            transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
}
