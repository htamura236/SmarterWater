using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishRandomMovement : MonoBehaviour
{
    public bool onGround;
    public float randomJumpForce = 50f;
    public float movementSpeed = 20f;
    public float rotationSpeed = 100f;
    public bool randomMovement = true;

    private float jumpPressure;
    private float JumpForce;
    private Rigidbody rbody;

    float randomDirection;
    private float random_X_Movement;
    private float random_Z_Movement;

    private float checkForJump;
    // Start is called before the first frame update
    void Start()
    {
        //looks for the current value of jumpCheck 
        checkForJump = GetComponent<fishJumpControls>().jumpCheck;

        onGround = true;
        randomMovement = true;
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        print(checkForJump);
        //if touching the ground and randomMovement = true, start randomly moving
        if (onGround == true && randomMovement == true)
        {            
            StartCoroutine(Move());
        }
        if(Input.GetKeyDown("space"))
        {           
            StopCoroutine(Move());
            // makes the random movement script wait for the player's jump to finish before starting
           
        }
        
 
    }

    //Random movement
    IEnumerator Move()
    {
        randomMovement = true;

        //Chooses XYZ randomly 
        random_X_Movement = Random.Range(1f, 3f);
        JumpForce = Random.Range(2f, 5f);
        jumpPressure = Random.Range(1f, 3f);
        random_Z_Movement = Random.Range(1f, 3f);

        //time between each jump
        int jumpWait = 1/2; 


        randomDirection = Random.Range(1, 5);
        print(randomDirection);

        if(randomDirection == 1)
        {
            yield return new WaitForSeconds(jumpWait);

            rbody.velocity = new Vector3(random_X_Movement * random_X_Movement, jumpPressure * JumpForce, 0f);
            onGround = false;

            yield return new WaitForSeconds(jumpWait);
        }
        if(randomDirection == 2)
        {
            yield return new WaitForSeconds(jumpWait);

            rbody.velocity = new Vector3(-random_X_Movement * random_X_Movement, jumpPressure * JumpForce, 0f);
            onGround = false;

            yield return new WaitForSeconds(jumpWait);
        }
        if (randomDirection == 3)
        {
            yield return new WaitForSeconds(jumpWait);

            rbody.velocity = new Vector3(0f, jumpPressure * JumpForce, random_Z_Movement * random_Z_Movement);
            onGround = false;

            yield return new WaitForSeconds(jumpWait);
        }
        if (randomDirection == 4)
        {
            yield return new WaitForSeconds(jumpWait);

            rbody.velocity = new Vector3(0f, jumpPressure * JumpForce, -random_Z_Movement * random_Z_Movement);
            onGround = false;

            yield return new WaitForSeconds(jumpWait);
        }
    }


    /*
   
    IEnumerator waitForJump()
    {
       

        //makes the code wait until the player's jump has been executed before making randomMovement = true
        // when the player jumps, jumpCheck = 0
        // when onGround = true, jumpCheck = 1
        yield return new WaitUntil(() => checkForJump >= 1);
        //if checkForJump = 1, start random movement
        randomMovement = true;

    }
    */

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            onGround = true;
        }
    }
}
