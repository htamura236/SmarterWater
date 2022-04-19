using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public GameObject player;
    public float cameraHeight = 40.0f;

    void Update()
    {
        Vector3 pos = player.transform.position;
        pos.z += cameraHeight;
        transform.position = pos;
    }
}
