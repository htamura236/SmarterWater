using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    private float xRotation;
    [SerializeField]
    private float yRotation;
    [SerializeField]
    private float zRotation;


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(xRotation, yRotation, zRotation);
    }
}
