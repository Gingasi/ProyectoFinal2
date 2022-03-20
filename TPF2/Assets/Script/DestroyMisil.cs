using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DestroyMisil : MonoBehaviour
{
    public GameObject explosioneffect;
    public GameManager gameManagerScript;
    public PlayerHealth playerhealthscript;
    float countdown;
    public float delay = 2f;
    public int Opoints;
    public int Epoints;
    private bool IsWin;
   

    //En el start que encuentre todos los script y los puntos con los que se empieza la partida
    void Start()

    {

        gameManagerScript = FindObjectOfType<GameManager>();
        playerhealthscript = FindObjectOfType<PlayerHealth>();
        countdown = delay;

        Epoints = 0;
        Opoints = 0;
    }

    void Update()
    {   
        //Cuenta atrás para que la bala explote y se destruya si no choca con nada. 
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
           
            Explode();
            Destroy(gameObject);

        }

        if (!IsWin && Epoints == 20)
        {
            StartCoroutine(YouWin());
            IsWin = true;
        }
    }
    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Enemy"))
        {
            Epoints++;
            gameManagerScript.UpdateEn(Epoints);
            Explode();
            Destroy(gameObject);
            Destroy(otherCollider.gameObject);
        }

        if (otherCollider.gameObject.CompareTag("Objetivo"))
        {
            Opoints++;
            //gameManagerScript.UpdateObject(Opoints);
            Explode();
            Destroy(gameObject);
            Destroy(otherCollider.gameObject);

        }
        if (otherCollider.gameObject.CompareTag("Life"))
        {
            playerhealthscript.HealDamage(70);
            Destroy(otherCollider.gameObject);

        }
    }

    //Courrutina de que has ganado
    private IEnumerator YouWin()
    {
        gameManagerScript.Win();
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Cursor.lockState = CursorLockMode.Confined;
    }

    //Función de particulas para la destrucción de la bala
        void Explode()
    {
        
       Instantiate(explosioneffect, transform.position, transform.rotation);

    }
  


}

