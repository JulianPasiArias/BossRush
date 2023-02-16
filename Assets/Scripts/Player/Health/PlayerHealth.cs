using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   public int maxHealth = 15;
   public static int currentHealth;
   public Animator camAnim,flashAnim;

   public HealthBar healthBar;
   
   private bool playerisHit = false;
   public static bool playerIsFullHealth = true;

   public AudioSource audioS;
   
    void Start()
    {
       currentHealth = maxHealth; 
       healthBar.SetMaxHealth(maxHealth);
     
       StartCoroutine(WaitToLoadPosition());
        
         
       
    }

    
    void Update()
    {
       
       if(currentHealth < maxHealth)
       {
        playerIsFullHealth = false;
       }
      
        if(playerisHit)
        {
            flashAnim.SetTrigger("Flash");
            camAnim.SetTrigger("ShakeHarder");
            camAnim.SetTrigger("Idle");
            flashAnim.SetTrigger("Idle");
            playerisHit = false;
            audioS.Play();
        }
        if(currentHealth == maxHealth)
        {
            playerIsFullHealth = true;
        }

        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(1);  
            
            

            if(currentHealth <=0)
            {
                GameManager.instance.gameHasEnded = true;
                FallDown.firstPhaseDone = false;
                SecondPhase.SecondPhaseDone = false;
                ThirdPhase.ThirdPhaseDone = false;
                

            }
                  
   
        }
    }
    void TakeDamage(int damage)
    {
        playerisHit = true;
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        
        
        
    }

     IEnumerator WaitToLoadPosition()
     {
        yield return new WaitUntil(()=>FindObjectOfType<GameManager>());
        transform.position = GameManager.instance.SetNewRespawn();

     }
}
