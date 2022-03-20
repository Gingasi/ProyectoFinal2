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

    void Start()
    {
        gameManagerScript = FindObjectOfType<GameManager>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
      

    }
    public void HealDamage(int heal)
    {
        currentHealth -= heal;
        healthBar.SetHealth(currentHealth);
    }


    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void OnCollisionEnter(Collision otherCollider)
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

    void Update()
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

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Cursor.lockState = CursorLockMode.Confined;
    }
    


}
