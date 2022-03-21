using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int almostDead = 30;
    public int minHealth =0;
    public int currentHealth;
    public HealthBar healthBar;
    public cameraShake cameraShake;
    public GameObject explosioneffect;
    public Animator lowLife;
    public bool AlmostDead;
    private GameManager gameManagerScript;
    private float YLim = -0.1f;

    public bool isLowLiveActive;

    void Start() //En el start llamamos al script gamemanager, indicamos la salud actual y la barra de vida
    {
        gameManagerScript = FindObjectOfType<GameManager>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
      

    }
    public void HealDamage(int heal) //Como indicamos la salud que podemos recuperar
    {
        currentHealth -= heal;
        healthBar.SetHealth(currentHealth);
    }


    void TakeDamage(int damage) //Como indicamos el daño que nos harán
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void OnCollisionEnter(Collision otherCollider) //Los objetos que nos haran daño y cuanto nos hacen. 
    {
        if (otherCollider.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20);
            StartCoroutine (cameraShake.Shake(.15f, .4f));
        }

        if (otherCollider.gameObject.CompareTag("Life"))
        {
            HealDamage(70);
        }

    }

    void Update() //A continuación una serie de funciones donde activamos la animación de poca vida e indicamos que es lo que hará que murammos y active la courrutina de muerte. 
    {

        if (currentHealth <= almostDead && !isLowLiveActive)
        {
            lowLife.SetBool("AlmostDead", true);
            isLowLiveActive = true;
        }
   

        if (currentHealth <= minHealth)
        {
            Instantiate(explosioneffect, transform.position, transform.rotation);
            gameManagerScript.GameOver();
            StartCoroutine(Death());
        }

        if(transform.position.y <= YLim)
        {
            Instantiate(explosioneffect, transform.position, transform.rotation);
            gameManagerScript.GameOver();
            StartCoroutine(Death());
        }
    }

    private IEnumerator Death() //Courrutina de muerte
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Cursor.lockState = CursorLockMode.Confined;
    }
    


}
