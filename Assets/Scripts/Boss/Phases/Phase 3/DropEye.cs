using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropEye : MonoBehaviour
{
   private Rigidbody2D rb;

   private bool droppedEye = false;
   public Transform player;

   public static bool playerHasTheEye = false;

   [SerializeField] private GameObject floor,hole,eyeOnPlayer,lightHole,lilitaHP;
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();

    }

    
    void Update()
    {
        if(ThirdPhase.ThirdPhaseDone && !droppedEye)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            droppedEye = true;
            gameObject.layer = 7;
            lightHole.SetActive(true);
            lilitaHP.SetActive(false);
            
        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        { 
            playerHasTheEye = true;
            floor.SetActive(false);
            hole.SetActive(true);
            eyeOnPlayer.SetActive(true);
            Destroy(gameObject);

        }
    }

}
