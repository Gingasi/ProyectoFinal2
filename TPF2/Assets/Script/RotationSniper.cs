using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSniper : MonoBehaviour
{
    
    public Vector2 turn;



  //Aqu� indicamos que si el juego no est� pausado se rote seg�n el movimiento vertical del rat�n. Si n�, si el juego est� pausado que no se mueva. 
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
