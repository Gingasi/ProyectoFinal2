using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSniper : MonoBehaviour
{
    
    public Vector2 turn;



    // Update is called once per frame
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
