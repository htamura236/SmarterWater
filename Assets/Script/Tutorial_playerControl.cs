using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_playerControl : MonoBehaviour
{
    public bool inAir;
    public bool lock_A_Key;
    public bool lock_D_Key;
    public float distanceGround;


    public float speed = 10.0f;
    private float translation;
    private float straffe;

    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        inAir = false;


        distanceGround = GetComponent<Collider>().bounds.extents.y;
        // turn off the cursor

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            inAir = false;
            lock_A_Key = false;
            lock_D_Key = false;
        }
        if (Input.GetButton("Jump") == false)
        {
            inAir = true;

        }


        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            if (Input.GetKey(KeyCode.D) && inAir == true && lock_D_Key == false)
            {

                straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
                transform.Translate(straffe, 0, 0);
                lock_A_Key = true;

            }
            if (Input.GetKey(KeyCode.A) && inAir == true && lock_A_Key == false)
            {

                straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
                transform.Translate(straffe, 0, 0);
                lock_D_Key = true;

            }
        }



        // translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //transform.Translate(straffe, 0, translation);

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

