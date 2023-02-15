using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamia : MonoBehaviour
{
    
    
     [SerializeField] private float explosionForce = 50f;
     [SerializeField] private float explosionRadius;
    [SerializeField] private LayerMask layerToHit;
    public GameObject explosionParticles;

    [SerializeField] GameObject undergroundLamia,fallingRoof,colliderLife,fallingRoof2;

    private bool playerInRange;

    public float cooldownExplosion = 3.5f;

    private float undergroundTimer = 20f;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        if(playerInRange)
        {
            CooldownStart();
            if(cooldownExplosion <=0 )
                {
                    ExplosionAttack();
                    cooldownExplosion = 3.5f;
                }
        }
        if(LamiaLife.currentHealth == 300)
        {
            ActivateUnderground();
            
            undergroundTimer -= Time.deltaTime;
        }
        if(LamiaLife.currentHealth <= 100)
        {
            fallingRoof2.SetActive(true);
            
            
        }

        if(LamiaLife.currentHealth == 0)
        {
            Debug.Log("Lamia is Dead");
            Destroy(gameObject,1);
        }
        if(undergroundTimer <=0)
        {
            DesactivateUnderground();
            UndergroundPathing.LamiaIsUnderground = false;
        }
    }

  


   

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
               playerInRange = true;
                
        }
    }

    private void ExplosionAttack()
    {
         Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position,explosionRadius,layerToHit);
         Instantiate(explosionParticles, transform.position,Quaternion.identity);

         foreach(Collider2D obj in objects)
         {
          Vector2 direction = obj.transform.position - transform.position;
          obj.GetComponent<Rigidbody2D>().AddForce(Vector2.up*explosionForce);
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

    void CooldownStart()
    {
        cooldownExplosion -= Time.deltaTime;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            cooldownExplosion = 3.5f;
        }
    }

    void ActivateUnderground()
    {
       //Animacion de meterse en la sangre
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        UndergroundPathing.LamiaIsUnderground = true;
        undergroundLamia.SetActive(true);
        fallingRoof.SetActive(true);
        colliderLife.SetActive(false);
    }

    void DesactivateUnderground()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;  
        gameObject.GetComponent<BoxCollider2D>().enabled = true;  
        undergroundLamia.SetActive(false);
        fallingRoof.SetActive(false);
        colliderLife.SetActive(true);
        
        
    }
}
