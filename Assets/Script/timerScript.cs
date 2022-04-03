using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerScript : MonoBehaviour
{

    //Reference: https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/

  
  
    public float timeRemaining = 10;
    public float seconds, minutes;
    //bools to manege on/off of timer
    public bool timerIsRunning = false;
    public bool TimerOn;
    //text messages on screen
    public Text countText;
    public Text startText;
    public Text gameEndText;

    void Start()
    {
        //timer's format. you need to change "40" according to the time you set
        countText.text = string.Format("{0:00}:{0:40}", minutes, seconds);
        //timer is off at the start point
        TimerOn = false;
        timerIsRunning = false;
        //messages are off at the start point
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
            //when player touched "start" game object, timer starts count down.
            Debug.Log("collided start object");
            other.gameObject.SetActive(false);
            //show player game starts
            startText.enabled = true;
            startText.text = "Game Start!";
            //timer on
            TimerOn = true;
            timerIsRunning = true;
        }

        if (other.gameObject.CompareTag("goal"))
        {
            //when player touched "goal" game object, timer stop count down.
            Debug.Log("collided goal object");
            other.gameObject.SetActive(false);
            //show a player game end
            gameEndText.enabled = true;
            gameEndText.text = "You Win!";
            //timer off
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
            //let player know fish died, game is over, but the codes below doesn't work now.
            //actually the log "time over" doesn't appear even when count became 0.

            Debug.Log("time over");
            //gameEndText.enabled = true;
            //gameObject.SetActive(false);

        }
    }
    void fishDie()
    {
        //show message "time over"
        //deactivate player's game object so that player know he is no longer able to play game
        //show menu so that player can choose "restart, or "back to menu"
    }
}