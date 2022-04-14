using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    //respawn
    private Transform respawnPoint;
    private Transform playerPos;

    //colectables to be reset on death
    [SerializeField]
    private GameObject collectables;
    private GameObject collectablesCopy;


    void Start()
    {
        //timer's format. you need to change "40" according to the time you set
        countText.text = string.Format("{1:00}:{0:31}", minutes, seconds);
        //timer is off at the start point
        TimerOn = false;
        timerIsRunning = false;
        //messages are off at the start point
        startText.enabled = false;
        gameEndText.enabled = false;
        //get the player's position for respawning in the first position
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;

        //find and sets collectable object
        collectables = GameObject.FindGameObjectWithTag("Collectables");
        collectablesCopy = Instantiate(collectables, collectables.transform.position, collectables.transform.rotation);
        collectablesCopy.SetActive(false);
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
            //switch scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

        // for water bottle collectible
        if(other.gameObject.tag == "Bottle")
        {
            BottleCollectable bottle = other.gameObject.GetComponent<BottleCollectable>();
            if(bottle != null)
            {
                timeRemaining += bottle.secondsAdded;
            }
            Destroy(other.gameObject);
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
                else if(timeRemaining <= 0)
                {
                    Debug.Log("time over");
                    fishDie();
                }
            }
        }
        else
        {
            timeRemaining = 0;
            timerIsRunning = false;

        }
    }
    void fishDie()
    {
        //show message "time over"
        //gameEndText.enabled = true;
        //hide player's game object so that player know he is no longer able to play game
        //gameObject.SetActive(false);
        //respawn to the first position 
        //playerPos.position = new Vector3(respawnPoint.position.x, respawnPoint.position.y, respawnPoint.position.z);
        SceneManager.LoadScene(0);

        //show menu so that player can choose "restart, or "back to menu"

        timeRemaining = 33;

       //collectables managment

        Destroy(collectables);
        collectablesCopy.SetActive(true);
        collectables = Instantiate(collectablesCopy, collectablesCopy.transform.position, collectablesCopy.transform.rotation); ;
        collectablesCopy.SetActive(false);
    }
}