using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static GameObject instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this.gameObject;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
