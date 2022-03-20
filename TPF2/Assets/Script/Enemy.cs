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
        //enemyRigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("PlayerTank");
    }

    void Update()
    {
        //Vector3 direction = (player.transform.position - transform.position).normalized;
        //enemyRigidbody.AddForce(direction * speed);
        transform.LookAt(player.transform.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.right * speed * Time.deltaTime);
    }

   
}
