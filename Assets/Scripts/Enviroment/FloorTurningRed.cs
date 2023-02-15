using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTurningRed : MonoBehaviour
{
   public Animator anim;
   public float cooldown = 1f;
   private bool playerIsOnGround = false;
   
    void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    
    void Update()
    {
        if(UndergroundPathing.LamiaIsUnderground)
        {
            anim.SetBool("GetRed", true);
            
           
        }
        else
        {
            anim.SetBool("GetRed", false);
            
        }
        if(cooldown <= 0 && playerIsOnGround)
        {
            PlayerHealth.currentHealth -=1;
            FindObjectOfType<HealthBar>().slider.value -=1;
            GameObject.Find("2D Camera").GetComponent<Animator>().SetTrigger("ShakeHarder");
            GameObject.Find("2D Camera").GetComponent<Animator>().SetTrigger("Idle");
            GameObject.Find("DamageScreen").GetComponent<Animator>().SetTrigger("Flash");
          GameObject.Find("DamageScreen").GetComponent<Animator>().SetTrigger("Idle");
            cooldown = 1f;
        }

       

        
    }

  

   void OnTriggerStay2D(Collider2D col)
   {
    if(col.gameObject.CompareTag("Player") && UndergroundPathing.LamiaIsUnderground)
    {
       cooldown -= Time.deltaTime;
       playerIsOnGround = true;
    }
   
   }

   void OnTriggerExit2D(Collider2D col)
   {
    if(col.gameObject.CompareTag("Player"))
    {
        playerIsOnGround = false;
        cooldown = 1;
    }
   }
}
