using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPhase : MonoBehaviour
{
    public Animator anim;
    public Animator camAnim;
    [SerializeField] private GameObject normalEyeBall1,normalEyeBall2,mouth,thirdEye,arm,healtBar,punchingHand,spikes;
    public static bool ThirdPhaseDone = false;
    [SerializeField] private Transform punchHandSpawn;
    public ThirdPhaseHealth thirdPhaseHealth;
    private Rigidbody2D rb;

    private bool firstAttackDone = false;
    private bool secondAttackDone = false;

    public int maxHealth = 140;
    int currentHealth;
    void Start()
    {
        anim.GetComponent<Animator>();
        camAnim.SetBool("ShakeFinalBoss",true);

        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
        thirdPhaseHealth.SetMaxHealth(maxHealth);
    }

    
    void Update()
    {
        if(SecondPhase.SecondPhaseDone)
        {
            WakeUp();
            StartCoroutine(Shooting());
        }
    }

     void WakeUp()
    {
        anim.SetTrigger("WakeUp");
        

    }

    private IEnumerator Shooting()
    {
        yield return new WaitForSeconds(7);
        camAnim.SetBool("ShakeFinalBoss", false);
        camAnim.SetTrigger("Idle");
        normalEyeBall2.SetActive(true);
        normalEyeBall1.SetActive(true);
        mouth.SetActive(true);
        arm.SetActive(true);
        thirdEye.SetActive(true);
        healtBar.SetActive(true);
        spikes.SetActive(true);
    }

     void Die()
   {
        ThirdPhaseDone= true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        
    
   }

   void Attack()
   {
        Instantiate(punchingHand,punchHandSpawn.position,Quaternion.identity);
    
   }

   public void TakeDamage(int damage)
   {
        currentHealth -= damage;
       thirdPhaseHealth.SetHealth(currentHealth);

        if(currentHealth <= 100 && !firstAttackDone)
        {
            Attack();
            firstAttackDone = true;
        }
        else if(currentHealth <= 50 && !secondAttackDone)
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
