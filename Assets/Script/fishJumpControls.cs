using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* FOUND BUGS: 
 * 
 * Player can hover if spamming / holding down the space bar, need jump delay? The raycast is reading it as isGrounded while the fish is still in the air
 * 
 * If placeholderFish (player character) flips over after landing, the jump won't work.
 * 
 * The WASD controls are not consistent, seems like you have to hold the space bar down to get them to work


*/

public class fishJumpControls : MonoBehaviour
{


    //jump
    [Header ("Jump Physics:")]

    public float Distance = 5;
    private Rigidbody rigid_body;
    public float JumpForce = 100;
    //public bool isGrounded;

    // Jump Charge
    private bool onGround;
    private float jumpPressure;
    private float minJump;
    private float maxJumpPressure;
    private Rigidbody rbody;
        

    //start is called before the first update
    void Start()
    {
        rigid_body = GetComponent<Rigidbody>();

        //Jump Charge
        rbody = GetComponent<Rigidbody>();
        onGround = true;
        jumpPressure = 0f;
        minJump = 2f;
        maxJumpPressure = 10f;
       
       
    }

    //Update is called once per frame
    private void Update()
    {
  
     if (onGround == true)
     {
         print("Touching Ground: Disables WASD");
        
         GameObject.Find("placeholderFish").GetComponent<playerControl>().enabled = false;
     }
     else
     {
            
            GameObject.Find("placeholderFish").GetComponent<playerControl>().enabled = true;
        }

     
        

     //Jump Charge
     if (onGround)
        {
            //if holding jump button
            if(Input.GetButton("Jump"))
            {
                if(jumpPressure < maxJumpPressure)
                {
                    jumpPressure += Time.deltaTime * 10f;
                }
                else
                {
                    jumpPressure = maxJumpPressure;
                }     
            }
            //not holding jump button
            else
            {
                //jump
                if(jumpPressure > 0f)
                {
                    jumpPressure = jumpPressure + minJump;
                    rbody.velocity = new Vector3(0f, jumpPressure * JumpForce, 0f);
                    jumpPressure = 0f;
                    onGround = false;
                }
            }
            
        }

       


    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("ground"))
        {
            onGround = true;
        }
    }


    private void FixedUpdate()
    {

    }



    /*  OLD CODE BRAINSTORMS
     *  
     *  
     *  
     *  /*
     if (Input.GetKey("space"))
     {
         if (Input.GetKey("space") && isGrounded)
         {
           
            //improves gravity
             rigid_body.AddForce(new Vector3(0f, 1f, 0f));

             //enables WASD controls
             GameObject.Find("placeholderFish").GetComponent<playerControl>().enabled = true;
         }
     }   
     *  //  print("Jump");
           //  rigid_body.AddForce(Vector3.up * JumpForce);
     *  
     *  RaycastHit hit;
      if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1.5f))
      {
          print("can't move");
          isGrounded = true;
          //disables WASD controls
          GameObject.Find("placeholderFish").GetComponent<playerControl>().enabled = false;
      }
      else
      {
          print("noGround");
          isGrounded = false;
      }

      if (Input.GetKey("space"))
      {
          if (Input.GetKey("space") && isGrounded)
          {
              print("Jump");
              rigid_body.AddForce(Vector3.up * JumpForce);
              //enables WASD controls
              GameObject.Find("placeholderFish").GetComponent<playerControl>().enabled = true;
          }
      }
      */
    /*
      if (Input.GetKeyDown(KeyCode.Space))
       {
           jumpPressed = true;
       }
       else
           jumpPressed = false;
       if (Input.GetKey(KeyCode.Space))
       {
           jumpHeld = false;
           CheckForJump();
           GroundCheck();
       }
       */
    /*
   private void CheckForJump()
   {
       if (jumpPressed)
       {
           if (!character.isGrounded && numberOfJumpsLeft == maxJumps)
           {
               character.isJumping = false;
               return;
           }
           numberOfJumpsLeft--;
           if (numberOfJumpsLeft >= 0)
           {
               Rigidbody.gravityScale = originalGravity;
               Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, 0);
               buttonHoldTime = maxButtonHoldTime;

           }
       }
   }
   /* 
     * 
     * 
     * if (Input.GetKey("w"))
        {
            transform.position = transform.position + Camera.main.transform.forward * Distance * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            transform.position = transform.position - Camera.main.transform.forward * Distance * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            transform.position = transform.position - Camera.main.transform.forward * Distance * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            transform.position = transform.position + Camera.main.transform.forward * Distance * Time.deltaTime;
        }
        if (isGrounded == true)
       {
           print("can't move");
           GameObject.Find("placeholderFish").GetComponent<playerControl>().enabled = false;
       }
        */
   
}
