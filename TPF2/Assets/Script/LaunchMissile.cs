using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchMissile : MonoBehaviour
{
    public GameObject Misil;
    public GameObject canon;
    private AudioSource explosion;
    public AudioClip Boom;
  
    public GameObject fum;
    float coolDown = 2f;
    float LastShoot;
    void Start()
    {

        explosion = GetComponent<AudioSource>();
    }

    //Indicamos que se dispare el misil si el juego no está pausado y se clica el botón.
    //Esto lo hacemos para que cuando estemos en el menú no se dispare un misil cada vez que sse clica

    void Update()
    {
       if (!PauseMenu.GameIsPaused && Input.GetMouseButtonDown(0)) 
        {
            
            Missile();
        }

       
    }
    //Función del misil que engloba la instanciación de este, la animación de particulas el cooldown y la activación del 
    void Missile()
    {
        if(Time.time - LastShoot < coolDown)
        {
            return;
        }
        LastShoot = Time.time;

        explosion.PlayOneShot(Boom, 1f);
        Instantiate(Misil, transform.position,
               canon.transform.rotation);
       

        Instantiate(fum, transform.position, transform.rotation);
    }

    



} 

