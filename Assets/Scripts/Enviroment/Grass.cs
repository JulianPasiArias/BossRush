using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
       anim.GetComponent<Animator>(); 
    }

   
   void OnTriggerEnter2D(Collider2D col)
   {
    if(col.gameObject.CompareTag("Player"))
    {
        anim.SetTrigger("Move");
    }
   }
   void OnTriggerExit2D(Collider2D coll)
   {
    if(coll.gameObject.CompareTag("Player"))
    {
        anim.SetTrigger("Idle");
    }
   }
}
