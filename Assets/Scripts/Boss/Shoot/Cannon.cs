using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
     private Transform player;

    public GameObject projectile;
    private float shootCooldown;
    public float startShootCooldown;
    void Start()
    {
        shootCooldown = startShootCooldown;
         player = GameObject.FindGameObjectWithTag("Player").transform;

    }

   
    void Update()
    {
       if(!ThirdPhase.ThirdPhaseDone) 
       {
         if(GameObject.FindGameObjectWithTag("Player"))
        {
           Vector2 direction = new Vector2(player.position.x - transform.position.x,  player.position.y - transform.position.y);
        
            transform.up = direction;

        }
        if(shootCooldown <= 0 )
        {
            Instantiate(projectile, transform.position, transform.rotation);
            shootCooldown = startShootCooldown;
            
        }else
        {
            shootCooldown -= Time.deltaTime;
        }
        
       }
        
        
    }
}
