using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEyesProjectile : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
       transform.Translate(Vector2.up * speed * Time.deltaTime); 
       GameObject calderoFloor = GameObject.FindGameObjectWithTag("CalderoFloor");
       Physics2D.IgnoreCollision(calderoFloor.GetComponent<Collider2D>(),GetComponent<Collider2D>());
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Ground"))
        {
            
            gameObject.layer = 7;
            speed = 0f;
            Destroy(gameObject,15);
            gameObject.tag = ("Untagged");
            
            
        }
    }
}
