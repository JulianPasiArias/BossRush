using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPhase : MonoBehaviour
{
    public Animator anim;
    public Animator camAnim;
    private Rigidbody2D rb;
    [SerializeField] private GameObject mouth,particles,finalBossLilita,arm,healtBar,punchingHand,lifeBar;

    [SerializeField] private Transform punchHandSpawn;
    public static bool SecondPhaseDone = false;
    
    
    public int maxHealth = 120;
    int currentHealth;
    public SecondPhaseLife secondPhaseLife;
    private bool firstAttackDone = false;
    private bool secondAttackDone = false;
    void Start()
    {
        anim.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
        currentHealth = maxHealth;
        secondPhaseLife.SetMaxHealth(maxHealth);
        
   
    }

    
    void Update()
    {
          if(FallDown.firstPhaseDone)
        {
            WakeUp();
            StartCoroutine(Pathing());
        }
 
    }

    void WakeUp()
    {
        anim.SetTrigger("WakeUp");
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    private IEnumerator Pathing()
    {
        yield return new WaitForSeconds(5);
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponentInChildren<ShootSecondPhase>().enabled = true;
        GameObject.Find("Eyes1").GetComponent<ShootSecondPhase>().enabled = true;
        mouth.SetActive(true);
        arm.SetActive(true);
        healtBar.SetActive(true);
 
    }

   void Attack()
   {
        Instantiate(punchingHand,punchHandSpawn.position,Quaternion.identity);
    
   }

   

   void Die()
   {
       lifeBar.SetActive(false);
        SecondPhaseDone= true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, 2);
    
   }

   public void TakeDamage(int damage)
   {
        currentHealth -= damage;
        secondPhaseLife.SetHealth(currentHealth);

        if(currentHealth <= 80 && !firstAttackDone)
        {
            Attack();
            firstAttackDone = true;
        }
        else if(currentHealth <= 40 && !secondAttackDone)
        {
            Attack();
            secondAttackDone = true;
        }
        if(currentHealth <= 0)
        {
            Die();
            StopAllCoroutines();
        }
   }

  
}
