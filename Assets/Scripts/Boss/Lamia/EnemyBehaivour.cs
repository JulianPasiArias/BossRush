using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaivour : MonoBehaviour
{
   public Transform raycast,leftLimit,rightLimit;
   public LayerMask raycastMask;
   public float raycastLenght;
   public float attackDistance; //Minimum distance for attack
   public float moveSpeed;
   public float timer;      //Cooldown between attacks




   private RaycastHit2D hit;
   private Transform target;
   //private Animator anim;
   private float distance; //Distance btw enemy and player
   private bool attackMode;
   private bool inRange;
   private bool cooling;
   private float intTimer;


   void Awake()
   {
    SelectTarget();
    intTimer = timer;
    //anim = GetComponent<Animator>();

   }


    // Update is called once per frame
    void Update()
    {
       if(!UndergroundPathing.LamiaIsUnderground)
       {
            if(!attackMode)
       {
        Move();
       }
       
       if(!InsideOfLimits() && !inRange) //&& !anim.GetCurrentAnimatorStateInfo(0).IsName("Lamia_attack") )
       {
            SelectTarget();
       }
       
        if(inRange)
        {
            hit = Physics2D.Raycast(raycast.position,transform.right,raycastLenght,raycastMask);
            RayCastDebugger();
        }

        //When player is detected
        if(hit.collider != null)
        {
            EnemyLogic();
        }
        else if(hit.collider == null)
        {
            inRange = false;
        }

        if(inRange == false)
        {
            
            StopAttack();
        }

        if(LamiaLife.currentHealth <= 100)
        {
            moveSpeed = 7f;
        }
       }
       
       
       
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            target = col.transform;
            inRange = true;
            Flip();
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position,target.position);
        if(distance > attackDistance)
        {
            
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }
        if(cooling)
        {
            CoolDown();
            //anim.SetBool("Attack",false);
        }
    }

    void Move()
    {
       //anim.SetBool("canWalk",true);
       
       //if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Lamia_attack"))
      // {
            Vector2 targetPosition = new Vector2(target.position.x,transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position,targetPosition,moveSpeed * Time.deltaTime); 
      // }
        
    }

    void Attack()
    {
        timer = intTimer;  //Reset Timer when player enters Attack Range
        attackMode = true;  //Check if the enemy can attack or not
        Debug.Log("Lamia is Attacking");

        //anim.SetBool("canWalk",false);
        //anim.SetBool("Attack", true);
    }

    void CoolDown()
    {
        timer -= Time.deltaTime;

        if(timer <=0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        //anim.SetBool("Attack", false);
    }

    void RayCastDebugger()
    {
        if(distance > attackDistance)
        {
            Debug.DrawRay(raycast.position,transform.right*raycastLenght,Color.red);
        }
        else if (attackDistance > distance)
        {
             Debug.DrawRay(raycast.position,transform.right*raycastLenght,Color.green);    
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }

    private bool InsideOfLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position,leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position,rightLimit.position);

        if(distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        }
        else
        {
            target = rightLimit;
        }

        Flip();
    }

    void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if(transform.position.x > target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }


        transform.eulerAngles = rotation;
    }
}
