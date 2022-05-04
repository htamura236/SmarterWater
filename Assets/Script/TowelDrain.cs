using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowelDrain : MonoBehaviour
{
    public float drainSpeed; 

    public Text warning;

    private void Start()
    {
        warning.enabled = false;
    }
}
