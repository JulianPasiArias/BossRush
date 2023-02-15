using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeAttackStun : MonoBehaviour
{
   
   [SerializeField] GameObject particles;
   public Transform spawnParticles;
   public float attackRange = 2f;
   public LayerMask enemyLayer;
    public int attackDamage;

    public static bool EyeAttackDone = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(CreateRage.EyeAttackIsReady && Input.GetKeyDown(KeyCode.F))
        {
            SpecialAttack();
            Debug.Log("Special Attack Done");
        }
    }

    void SpecialAttack()
    {
        
        EyeAttackDone = true;
        Instantiate(particles,spawnParticles.position,Quaternion.identity);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(spawnParticles.position,attackRange,enemyLayer);

       foreach(Collider2D enemy in hitEnemies)
       {
             GameObject.Find("Lamia").GetComponent<EnemyBehaivour>().enabled = false;
             GameObject.Find("Lamia").GetComponent<Lamia>().enabled = false;
             StartCoroutine(SetEnemyBehaivourBack());

       }
    }

    void OnDrawGizmosSelected()
    {
        if(spawnParticles == null)
        {
            return;
        }
        
        Gizmos.DrawWireSphere(spawnParticles.position,attackRange);
    }

    IEnumerator SetEnemyBehaivourBack()
    {
        yield return new WaitForSeconds(5);
        GameObject.Find("Lamia").GetComponent<EnemyBehaivour>().enabled = true;
        GameObject.Find("Lamia").GetComponent<Lamia>().enabled = true;
        

    }
}
