using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialStageEvents : MonoBehaviour
{
    public float displayRemaining = 10;
    private bool isTimeRemaining;
    private bool isCountDownOn;

    public Text displayMessage;

    void Start ()
    {
        displayMessage.enabled = true;
        isCountDownOn = false;
    }
    void Update()
    {
            countDown();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isCountDownOn = true;
        }
        if (other.gameObject.CompareTag("tutorial2"))
        {

        }
        if (other.gameObject.CompareTag("tutorial3"))
        {

        }
    }

    void countDown()
    {
        if (isCountDownOn = true && displayRemaining > 0)
        {
            displayRemaining -= Time.deltaTime;
        }
        else
        {
            isTimeRemaining = false;
            displayMessage.enabled = false;
        }
    }
}
