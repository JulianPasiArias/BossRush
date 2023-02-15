using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabHealth : MonoBehaviour
{
   

    public HealthBar healthBar;
   

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Crystal") && PlayerHealth.playerIsFullHealth == false)
        {
            PlayerHealth.currentHealth += 1;
            healthBar.slider.value += 1;
            Debug.Log("Crystal Picked Up");
            
        }
       
       
    }
}
