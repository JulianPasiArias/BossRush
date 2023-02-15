using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingCrystal : MonoBehaviour
{
    
    [SerializeField] GameObject particleEffect;
    
    

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player") && PlayerHealth.playerIsFullHealth == false)
        {
            gameObject.SetActive(false);
            Instantiate(particleEffect, transform.position, Quaternion.identity);
            Destroy(gameObject,1);

        }
    }
}
