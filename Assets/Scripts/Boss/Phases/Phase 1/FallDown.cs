using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour
{
    
    public Animator camAnim;
    public static bool firstPhaseDone = false;
    public Rigidbody2D rb;

    [SerializeField] GameObject lifeBar;
    
  
    void Awake()
    {
       
        

    }
    void Start()
    {
        firstPhaseDone = true;
        rb.bodyType = RigidbodyType2D.Dynamic; 
        camAnim.SetTrigger("ShakeHarder");
        camAnim.SetTrigger("Idle");
        Destroy(gameObject,3);
        lifeBar.SetActive(false);
        
    }


}
