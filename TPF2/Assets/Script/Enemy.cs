using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //private Rigidbody enemyRigidbody;
    private GameObject player;
    
    [SerializeField] private float speed = 10;
    

    void Start()
    {
       
        player = GameObject.Find("PlayerTank");
    }

    void Update()
    {
        
        transform.LookAt(player.transform.position); //El enemigo busca al jugador
        transform.Translate(Vector3.forward * speed * Time.deltaTime); //El enemigo está en constante movimiento
        transform.Rotate(Vector3.right * speed * Time.deltaTime); //El enemigo puede rotar. 
    }

   
}
