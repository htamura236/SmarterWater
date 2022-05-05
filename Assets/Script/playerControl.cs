using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public bool isJumping;
    public bool lock_A_Key;
    public bool lock_D_Key;
    public float distanceGround;
    
    public bool test;

    public float speed = 7.0f;
    private float translation;
    private float straffe;

    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        isJumping = false;
        
        test = false;
        

        distanceGround = GetComponent<Collider>().bounds.extents.y;
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;


        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        


        if (Input.GetButton("Jump"))
        {
            isJumping = false;
            lock_A_Key = false;
            lock_D_Key = false;

            test = true;
           
        }
        if (Input.GetButton("Jump") == false)
        {
            test = false;
            isJumping = true;
            if (lock_A_Key == true || lock_D_Key == true)
            {
               lock_A_Key = false;
               lock_D_Key = false;
            }
        }
        


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.W) && Input.GetButton("Jump"))
        {
            rb.AddForce(speed * transform.forward);
            if (Input.GetKey(KeyCode.D) && isJumping == true && lock_D_Key == false   ||   Input.GetButton("Jump") && Input.GetKey(KeyCode.D) && isJumping == true && lock_D_Key == false )
            {
                rb.AddForce((speed / 2) * transform.right);              
                lock_A_Key = true;
                
            }
            if (Input.GetKey(KeyCode.A) && isJumping == true && lock_A_Key == false   ||   Input.GetButton("Jump") && Input.GetKey(KeyCode.A) && isJumping == true && lock_A_Key == false )
            {
                rb.AddForce((speed / 2) * -transform.right);            
                lock_D_Key = true;

            }
        }
        

        
            // translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            //straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            //transform.Translate(straffe, 0, translation);

            if (Input.GetKeyDown("escape"))
        {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }

        if (isJumping == true && lock_A_Key == true)
        {

        }


        
    }

    /*
    private void FixedUpdate()
    {
        if(Physics.Raycast(transform.position, -Vector3.up, distanceGround + 0.1f))
        {
            inAir = false;
            print("In the air");
        }
        else
        {
            inAir = true;
            print("On the ground");
        }
    }

    
    private void OnCollisionEnter(Collision other)
    {
        if (gameObject.CompareTag("ground"))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
        */
    }

