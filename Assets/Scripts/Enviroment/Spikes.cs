using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    public AudioSource audioS;
   void Update()
   {
    Physics2D.IgnoreLayerCollision(9,10);
   }
   
   
    void OnCollisionEnter2D(Collision2D col)
    {
        audioS.Play();
        Destroy(gameObject);
   
    }
}
