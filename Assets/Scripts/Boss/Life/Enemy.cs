using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    public static bool firstLilitaIsDead = false;
    public EnemyHealthBar enemyHealtBar;
    private bool attackDone = false;
    public GameObject explosionParticles;
    [SerializeField] private float explosionForce = 50f;
     [SerializeField] private float explosionRadius;
    [SerializeField] private LayerMask layerToHit;

    [SerializeField] GameObject invisibleBarrier;

    void Start()
    {
        currentHealth = maxHealth;
        enemyHealtBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(currentHealth <= 50 && attackDone == false)
        {
            Attack();
            attackDone = true;
            Debug.Log("Attack Done");

        }

        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        enemyHealtBar.SetHealth(currentHealth);

    
         if(currentHealth <= 0)
        {
            Die();
            
        }

    }

    void Die()
    {
        Debug.Log("Enemy Died");
        GetComponent<FallDown>().enabled = true;
        Destroy(gameObject, 2);
        firstLilitaIsDead = true;
    }


    private void Attack()
    {
         Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position,explosionRadius,layerToHit);
         Instantiate(explosionParticles, transform.position,Quaternion.identity);

         foreach(Collider2D obj in objects)
         {
          Vector2 direction = obj.transform.position - transform.position;
          obj.GetComponent<Rigidbody2D>().AddForce(Vector2.right*explosionForce);
          PlayerHealth.currentHealth -=2;
          FindObjectOfType<HealthBar>().slider.value -= 2;
          GameObject.Find("2D Camera").GetComponent<Animator>().SetTrigger("ShakeHarder");
          GameObject.Find("DamageScreen").GetComponent<Animator>().SetTrigger("Flash");
          GameObject.Find("DamageScreen").GetComponent<Animator>().SetTrigger("Idle");
         }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
    

    
}
