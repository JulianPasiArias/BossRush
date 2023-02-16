using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Rb2D;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private float horizontal;

    public AudioSource audioS;
    private float speed = 10f;
    private float jumpingPower = 12f;
    private bool isFacingRight = true;

    [SerializeField] private float acceleration;
   [SerializeField]  private float decceleration;

   [SerializeField]  private float velPower;

    public GameObject dustEffect;
    private bool spawnDust;
    private float timeBtwTrail = 1f;
    private float startTimeBtwTrails = 0.5f;
    public GameObject trailEffect;

    
    public Animator playerAnim;

    //DIALOGUE
    public static bool playerIsTalking = false;
   
   


    //Dash
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    //Coyote Time
    private float HangCounter;
    [SerializeField] private float coyoteTime = 0.1f;

    public float jumpBufferLenght = .1f;
    private float jumpBufferCount;

    private bool playerIsMoving = false;


    [SerializeField] private TrailRenderer trail; 

    
    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        
       

    }

    //Checking with a sphere if the player is touching the ground
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        
    }
    
    void Update()
    {
        Flip();
        Jump();
        CoyoteTime();

        if(playerIsTalking == true)
        {
            speed = 0;
        }
        else
        {
            speed = 10f;
        }


       if(speed !=0)
       {
            playerIsMoving = true;
        
        if(timeBtwTrail <=0)
        {
            Instantiate(trailEffect,groundCheck.position,Quaternion.identity);
            timeBtwTrail = startTimeBtwTrails;

        }
        else
        {
            timeBtwTrail -= Time.deltaTime;
        }
       }
       
       if(IsGrounded())
       {
        if(spawnDust == true)
        {
           
            GameObject.Find("2D Camera").GetComponent<Animator>().SetTrigger("Shake");
            Instantiate(dustEffect, groundCheck.position, Quaternion.identity);
            spawnDust = false;
            GameObject.Find("2D Camera").GetComponent<Animator>().SetTrigger("Idle");   
        } 
       }
       else
       {
        spawnDust = true;
       }
       
       
       if(isDashing)
       {
        return;
       }
       
        horizontal = Input.GetAxisRaw("Horizontal");
        

       
  
        if(Input.GetButtonDown("Jump"))
        {
            jumpBufferCount = jumpBufferLenght;      
        }
        else
        {
            jumpBufferCount -= Time.deltaTime;
        }

        //Jump higher if we hold the button "Jump"
        if(Input.GetButtonUp("Jump") && Rb2D.velocity.y > 0f)
        {
            Rb2D.velocity = new Vector2(Rb2D.velocity.x, Rb2D.velocity.y * 0.5f);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    
    //Movement of the player
    private void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }
        
       
       
          Rb2D.velocity = new Vector2 (horizontal * speed, Rb2D.velocity.y);
          playerAnim.SetFloat("Speed", Mathf.Abs(horizontal));
        
        if(playerIsMoving && IsGrounded())
        {
            //audioS.Play();
        }
        
        
        
        /*
       //calculate the direction we want to go and the desired velocity
       float targetSpeed = horizontal * speed;
       //calculate difference between current velocity and desired velocity
       float speedDif = targetSpeed - Rb2D.velocity.x;
       //change acceleration rate depending on situation
       float accelRate = (Mathf.Abs(targetSpeed) >0.01f)? acceleration : decceleration;
       float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate,velPower) * Mathf.Sign(speedDif);
       Rb2D.AddForce(movement * Vector2.right);
       */
    }

    //Flip the character to make it face the direction its going
    private void Flip()
    {
        if(isFacingRight && horizontal <0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            gameObject.transform.localScale = localScale;
            
            
        }
    }

    //Dash
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = Rb2D.gravityScale;
        Rb2D.gravityScale = 0f;
        Rb2D.velocity = new Vector2(transform.localScale.x * dashingPower,0f);
        trail.emitting = true;
        yield return new WaitForSeconds(dashingTime);
         trail.emitting = false;
         Rb2D.gravityScale = originalGravity;
         isDashing = false;
         yield return new WaitForSeconds(dashingCooldown);
         canDash = true;


    }

    private void Jump()
    {
        if(jumpBufferCount >= 0 && HangCounter >0)
        {
            //Rb2D.velocity = new Vector2(Rb2D.velocity.x, jumpingPower);
            Instantiate(dustEffect, groundCheck.position, Quaternion.identity);
            Rb2D.AddForce(Vector2.up* jumpingPower, ForceMode2D.Impulse);
            jumpBufferCount = 0;
            audioS.Play();
            
           
        }
    }

    private void CoyoteTime()
    {
        if(IsGrounded())
        {
            HangCounter = coyoteTime;

        }
        else
        {
            HangCounter -= Time.deltaTime;
        }
    }

    //CHeck if Slippery floor is below
    /*void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("CalderoFloor"))
        {
           Rb2D.AddForce(new Vector2 (horizontal * speed, Rb2D.velocity.y));
           Debug.Log("Touching Ice");
        }
        else
        {
           Rb2D.velocity = new Vector2 (horizontal * speed, Rb2D.velocity.y);
        }
    }
    */
    
}
