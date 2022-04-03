using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerScript : MonoBehaviour
{

    //Reference: https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/

  
    public bool TimerOn;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;

    public float seconds, minutes;

    public Text countText;
    public Text startText;
    public Text gameEndText;

    void Start()
    {
        countText.text = string.Format("{0:00}:{0:40}", minutes, seconds);
        TimerOn = false;
        timerIsRunning = false;
        //text
        startText.enabled = false;
        gameEndText.enabled = false;

    }

    void Update()
    {
        
        timerFunction();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("start"))
        {
            Debug.Log("collided start object");
            other.gameObject.SetActive(false);

            startText.enabled = true;
            startText.text = "Game Start!";
            //timer on
            TimerOn = true;
            timerIsRunning = true;
        }

        if (other.gameObject.CompareTag("goal"))
        {
            Debug.Log("collided goal object");
            other.gameObject.SetActive(false);

            gameEndText.enabled = true;
            gameEndText.text = "You Win!";
            TimerOn = false;
            timerIsRunning = false;

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

    void timerFunction()
    {
        if (TimerOn = true)
        { 
            if (timerIsRunning)
            { 
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    displayTime(timeRemaining);
                }
            }
        }
        else
        {
            timeRemaining = 0;
            timerIsRunning = false;
            //let player know fish died, game is over, but the codes below doesn't work now
            //Debug.Log("time over");
            //gameEndText.enabled = true;

        }
    }
}