using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DestroyMisil : MonoBehaviour
{
    public GameObject explosioneffect;
    public GameManager gameManagerScript;
    public PlayerHealth playerhealthscript;
    float countdown;
    public float delay = 2f;
    
    private AudioSource Selecction;
    public AudioClip Select;
   

    //En el start que encuentre todos los script y los puntos con los que se empieza la partida
    void Start()

    {

        gameManagerScript = FindObjectOfType<GameManager>();
        playerhealthscript = FindObjectOfType<PlayerHealth>();
        countdown = delay;
        Selecction = GetComponent<AudioSource>();


    }

    void Update()
    {   
        //Cuenta atr�s para que la bala explote y se destruya si no choca con nada. 
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
           
            Explode();
            Destroy(gameObject);

        }

        
    }
    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Enemy"))
        {
            
            gameManagerScript.UpdateEn();
            Explode();
            Destroy(gameObject);
            Destroy(otherCollider.gameObject);
        }

        if (otherCollider.gameObject.CompareTag("Objetivo"))
        {
            Selecction.PlayOneShot(Select, 1f);
           
            gameManagerScript.UpdateObject();
            Explode();
            Destroy(gameObject);
            Destroy(otherCollider.gameObject);
            

        }
        if (otherCollider.gameObject.CompareTag("Life"))
        {
            Selecction.PlayOneShot(Select, 1f);
            playerhealthscript.HealDamage(70);
            Destroy(otherCollider.gameObject);
        }
    }

    //Courrutina de que has ganado
    

    //Funci�n de particulas para la destrucci�n de la bala
        void Explode()
    {
        
       Instantiate(explosioneffect, transform.position, transform.rotation);

    }
  


}

