using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* FOUND BUGS: 
 * 
 * Player can hover if spamming / holding down the space bar, need jump delay? The raycast is reading it as isGrounded while the fish is still in the air
 * 
 * If placeholderFish (player character) flips over after landing, the jump won't work.


*/

public class fishJumpControls : MonoBehaviour
{


    //jump:
    public float Distance = 5;
    private Rigidbody rigid_body;
    public int JumpForce = 100;
    public bool isGrounded;


    //start is called before the first update
    void Start()
    {
        rigid_body = GetComponent<Rigidbody>();

       
       
    }

    //Update is called once per frame
    private void Update()
    {
        RaycastHit hit;

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

            //improves gravity?
             rigid_body.AddForce(new Vector3(0f, 1f, 0f));

             //enables WASD controls
             GameObject.Find("placeholderFish").GetComponent<playerControl>().enabled = true;

            
         }

     }

     


    }

    private void FixedUpdate()
    {
        
    }



    /*  
     *  ROUGH CODE IDEAS
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
     * BRAINSTORMING CODE
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

    /*  public int maxJumps;
    public float jumpForce;
    public float maxButtonHoldTime;
    public float holdForce;
    public float distanceToCollider;
    public float maxJumpSpeed;
    public float maxFallSpeed;

    //used to make gravity less floaty
    public float fallSpeed;
    //used to adjust how quickly the player falls after jumping (makes it less floaty)
    public float gravityMultiplyer;

    public LayerMask collisionLayer;

    private bool jumpPressed;
    private bool jumpHeld;
    private float buttonHoldTime;
    private float originalGravity;
    private int numberOfJumpsLeft;
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
   */
}
