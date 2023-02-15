using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RockProjectile : MonoBehaviour
{
   public float speed;

   private bool touchedGround = false;
    public float time = 8f;
    public float timeLeft;
    public GameObject explosionParticles;
    private bool particlesInstantiated = false;
    [SerializeField] private float explosionForce = 50f;
    private Rigidbody2D rb;
     public Animator anim;
    
    [SerializeField] private float explosionRadius;
    [SerializeField] private LayerMask layerToHit;
    
    void Start()
    {
          timeLeft = time;
          rb = GetComponent<Rigidbody2D>();
          anim = GetComponent<Animator>();

    }
    void Update()
    {
         transform.Translate(Vector2.up * speed * Time.deltaTime);
         Timer();
         if(particlesInstantiated)
         {
          Instantiate(explosionParticles, transform.position,Quaternion.identity);
          particlesInstantiated = false;
         }
         Physics2D.IgnoreLayerCollision(9,6);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
     if(col.gameObject.CompareTag("Player") && touchedGround == false)
     {
          Explosion();
          gameObject.GetComponent<SpriteRenderer>().enabled = false;
          Instantiate(explosionParticles, transform.position,Quaternion.identity);
          Destroy(gameObject,1);
     }
     else if (col.gameObject.CompareTag("Ground"))
     {
         anim.SetTrigger("Tick");
         touchedGround = true;
         gameObject.layer = 7;
         speed = 0f;  
         Destroy(gameObject,7f);
         
     }
    }

     private void Explosion()
     {
         Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position,explosionRadius,layerToHit);

         foreach(Collider2D obj in objects)
         {
          Vector2 direction = obj.transform.position - transform.position;
          obj.GetComponent<Rigidbody2D>().AddForce(Vector2.right*explosionForce);
         // obj.GetComponent<PlayerHealth>().currentHealth -= 2;
         PlayerHealth.currentHealth -=2;
          FindObjectOfType<HealthBar>().slider.value -= 2;
          GameObject.Find("2D Camera").GetComponent<Animator>().SetTrigger("ShakeHarder");
          GameObject.Find("DamageScreen").GetComponent<Animator>().SetTrigger("Flash");
          GameObject.Find("DamageScreen").GetComponent<Animator>().SetTrigger("Idle");
          


         }
     }
    
    void Timer()
    {
          timeLeft -= Time.deltaTime;
          if(timeLeft <0)
          {
               gameObject.GetComponent<SpriteRenderer>().enabled = false;
               particlesInstantiated = true;
               Explosion();
               timeLeft = 3f;
               

          }
    }
}
