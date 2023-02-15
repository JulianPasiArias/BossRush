using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamiaLife : MonoBehaviour
{
     public int maxHealth = 100;
    
     public static int currentHealth;
     public EnemyHealthBar enemyHealtBar;
    void Start()
    {
         currentHealth = maxHealth;
        enemyHealtBar.SetMaxHealth(maxHealth);
    }

   
    void Update()
    {
        
    }

      public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        enemyHealtBar.SetHealth(currentHealth);

    
        

    }

   
}
