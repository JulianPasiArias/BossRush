using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public int attackDamage;

    public int rageIncreased;
    public AudioSource audioS;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            Attack();
        }
    }

    void Attack()
    {
       Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayer);

       foreach(Collider2D enemy in hitEnemies)
       {
        if(Enemy.firstLilitaIsDead == false)
        {
             enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
        else if(Enemy.firstLilitaIsDead && !SecondPhase.SecondPhaseDone)
        {
            enemy.GetComponent<SecondPhase>().TakeDamage(attackDamage);
        }
        else if(SecondPhase.SecondPhaseDone && !ThirdPhase.ThirdPhaseDone)
        {
            enemy.GetComponent<ThirdPhase>().TakeDamage(attackDamage);
        }
        else if(StartLamiaBattle.LamiaBattleStarted && ThirdPhase.ThirdPhaseDone)
        {
            enemy.GetComponent<LamiaLife>().TakeDamage(attackDamage);
        }

        audioS.Play();
         
         gameObject.GetComponent<CreateRage>().IncreaseRage(rageIncreased);
         
       }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
