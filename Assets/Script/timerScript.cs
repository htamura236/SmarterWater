using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerScript : MonoBehaviour
{

    //Reference: https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
   
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public float seconds, minutes;

    public Text countText;
    public Text startText;
    public Text gameEndText;

    void Start()
    {

        timerIsRunning = true;
        startText.enabled = false;
        gameEndText.enabled = false;


    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining >0)
            {
                timeRemaining -= Time.deltaTime;
                displayTime(timeRemaining);
            }
        }
        else
        {
            timeRemaining = 0;
            timerIsRunning = false;
            //let player know fish died, game is over
            Debug.Log("time over");
            gameEndText.enabled = true;

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("start"))
        {
            Debug.Log("collided start object");
            other.gameObject.SetActive(false);

            startText.enabled = true;
            startText.text = "Game Start!";
        }

        if (other.gameObject.CompareTag("goal"))
        {
            Debug.Log("collided goal object");

        }
    }

    void setTimer()
    {
        timeRemaining -= Time.deltaTime;
        displayTime(timeRemaining);
    }

    void displayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        countText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}