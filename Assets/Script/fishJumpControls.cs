using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* FOUND BUGS: 
 * 
 * 
 * If placeholderFish (player character) flips over after landing, the jump won't work.
 * 



*/

public class fishJumpControls : MonoBehaviour
{
    //animator
    [SerializeField]
    private Animator fishAnim;

    //jump
    [Header("Jump Force needs to be changed in fishRandomMovement script too")]
    public float JumpForce = 100;
    public float Distance = 5;
    private Rigidbody rigid_body;

   
    // Jump Charge
    public bool onGround;
    private float jumpPressure;
    private float minJump;
    private float maxJumpPressure;
    private Rigidbody rbody;

    private float buttonHoldTime;

    //Checks for player jump before executing random movement
    public float jumpCheck;


    //start is called before the first update
    void Start()
    {
        rigid_body = GetComponent<Rigidbody>();

        //Jump Charge
        rbody = GetComponent<Rigidbody>();
        onGround = true;
       // jumpCheck = 1;
        jumpPressure = 0f;
        minJump = 2f;
        maxJumpPressure = 10f;

        buttonHoldTime = 0;
    }

    //Update is called once per frame
    private void Update()
    {
        //used for animator
        if (fishAnim != null)
        {
            if(onGround)
            {
                fishAnim.SetBool("inAir", false);
            }
            else if (!onGround)
            {
                fishAnim.SetBool("inAir", true);
            }
        }


        if (onGround == true)
        {
            //Disables WASD;

            GameObject.Find("Fish").GetComponent<playerControl>().enabled = false;
        }
        else
        {
            //Enables WASD
            GameObject.Find("Fish").GetComponent<playerControl>().enabled = true;

        }

        //Jump Charge
        if (onGround == true)
        {
            //check's for player jump: if the player isn't holding space, execute random movement
            //  jumpCheck = 1;

            //if holding jump button
            if (Input.GetButton("Jump"))
            {

                
                //Jump charge bar visual goes up
                GameObject.Find("jumpChargeVisual").GetComponent<jumpChargeVisual>().isCharging = true;

                if (jumpPressure < maxJumpPressure)
                {
                    jumpPressure += Time.deltaTime * 10f;
                }
                if (maxJumpPressure >= 10f)
                {
                    // StartCoroutine(forceJump());
                }
                else
                {
                    jumpPressure = maxJumpPressure;

                }

            }
            //not holding jump button
            else
            {
                //charge bar goes down
                GameObject.Find("jumpChargeVisual").GetComponent<jumpChargeVisual>().isCharging = false;


                //jump
                if (jumpPressure > 0f)
                {
                    jumpPressure = jumpPressure + minJump;
                    rbody.velocity = new Vector3(0f, jumpPressure * JumpForce, 0f);
                    jumpPressure = 0f;
                    onGround = false;


                }


            }

        }
    }
   
    IEnumerator forceJump()
    {
        yield return new WaitForSeconds(5);
        jumpPressure = jumpPressure + minJump;
        rbody.velocity = new Vector3(0f, jumpPressure * JumpForce, 0f);
        jumpPressure = 0f;
        onGround = false;
        
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
