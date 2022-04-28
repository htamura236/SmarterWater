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

    public Text sBottleText;
    public Text BottleText;
    public Text trophyText;


    void Start ()
    {
        displayMessage.enabled = true;
        isCountDownOn = false;


        sBottleText.enabled = false;
        BottleText.enabled = false;
        trophyText.enabled = false;
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
        if (other.gameObject.CompareTag("Trophy"))
        {
            trophyText.enabled = true;
        }
        if (other.gameObject.CompareTag("sBottle"))
        {
            sBottleText.enabled = true;
        }
        if (other.gameObject.CompareTag("Bottle"))
        {
            BottleText.enabled = true;
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
