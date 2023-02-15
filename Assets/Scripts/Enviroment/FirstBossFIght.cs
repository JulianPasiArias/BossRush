using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossFIght : MonoBehaviour
{
    public static bool FirstBossApproaching = false;
   

   void OnTriggerEnter2D(Collider2D col)
   {
    if(col.gameObject.CompareTag("Player"))
    {
        FirstBossApproaching = true;
    }
   }

   
}
