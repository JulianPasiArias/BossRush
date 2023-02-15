using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingHand : MonoBehaviour
{
    
    [SerializeField] private float punchSpeed;
    
    

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(10,10);
    }
    
   void FixedUpdate()
   {
     rb.AddForce(Vector2.right * punchSpeed);
     Destroy(gameObject,1);
   }

   
   

   
}
