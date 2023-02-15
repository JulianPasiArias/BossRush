using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
   public Transform upPoint;
   public GameObject projectile;
   private float shootCooldown;
    public float startShootCooldown;

    

    void Start()
    {
        shootCooldown = startShootCooldown;
    }

    
    void Update()
    {
      
      
       Vector2 direction = new Vector2(upPoint.position.x - transform.position.x,  upPoint.position.y - transform.position.y);
       transform.up = direction;
       
        if(shootCooldown <= 0 )
        {
            Instantiate(projectile, transform.position, transform.rotation);
            shootCooldown = startShootCooldown;
        }
        else
        {
            shootCooldown -= Time.deltaTime;
        }
    }
}
