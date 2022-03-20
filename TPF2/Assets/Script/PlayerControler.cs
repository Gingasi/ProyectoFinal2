using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private float speed = 25f;
    private float verticalInput;
    private float horizontalInput;
    private float turnspeed = 100f;
    private Rigidbody PlayerRigidbody;
    
    [SerializeField] private float Force = 400f;


    private void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
        
        Time.timeScale = 1f;

    }




    // Update is called once per frame
    void Update()
    {

        Movement();

    }

    void Movement()
    {

        if (!PauseMenu.GameIsPaused)
        {
            verticalInput = Input.GetAxis("Vertical");

            transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * turnspeed * Time.deltaTime * horizontalInput);
            PlayerRigidbody.AddForce(Vector3.down * Force, ForceMode.Impulse);


            
        }
        else
        {
            Time.timeScale = 0f;
            
        }



    }
}
