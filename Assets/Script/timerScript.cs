using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timerScript : MonoBehaviour
{

    //Reference: https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/

    //used to determine how long the time added text appears, 3 by default
    [SerializeField]
    private float addTextTime = 3;
    
    //used to time how long the game start text appears
    [SerializeField]
    private int startTextTime = 2;
    private int startingTimeAmount;
  
    public float timeRemaining = 10;
    public float seconds, minutes;
    //bools to manege on/off of timer
    public bool timerIsRunning = false;
    public bool TimerOn;
    //text messages on screen
    public Text countText;
    public Text startText;
    public Text gameEndText;

    //time added text for when a bottle is picked up
    [SerializeField]
    private Text timeAddedText;
    [SerializeField]
    private Text timeLostText;


    //respawn
    private Transform respawnPoint;
    private Transform playerPos;

    //colectables to be reset on death
    [SerializeField]
    private GameObject collectables;
    private GameObject collectablesCopy;

    //score screen canvas
    [SerializeField]
    private GameObject scoreScreen;

    //death screen canvas
    [SerializeField]
    private GameObject deathScreen;

    [Header("Scorescreen Text")]
    //score screen text
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private Text bottleText;
    [SerializeField]
    private Text trophyText;
    [SerializeField]
    private Text scoreText;

    //animator
    [SerializeField]
    private Animator fishAnim;

    //youdied text fade in alpha
    private float currentAlpha = 0;

    void Awake()
    {
        if(timeAddedText != null)
        {
            timeAddedText.enabled = false;
        }
        if(timeLostText != null)
        {
            timeLostText.enabled = false;
        }

        //you died alpha setting

        CanvasRenderer[] youDied;
        youDied = new CanvasRenderer[2];
        youDied[0] = deathScreen.transform.Find("Background").GetComponent<CanvasRenderer>();
        youDied[1] = deathScreen.transform.Find("Background").transform.Find("YouDied").GetComponent<CanvasRenderer>();


        foreach (CanvasRenderer item in youDied)
        {
            item.SetAlpha(0f);
        }


        //timer's format. you need to change "40" according to the time you set
        countText.text = string.Format("{0:00}:{0:00}", minutes, seconds);
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

        //finds score screen canvas
        scoreScreen = GameObject.FindGameObjectWithTag("ScoreScreen");
        scoreScreen.SetActive(false);

        GetComponent<fishRandomMovement>().enabled = false;

        startingTimeAmount = Mathf.RoundToInt(timeRemaining);

        deathScreen.SetActive(false);
    }

    void Update()
    {
        
        timerFunction();
        //tracking for score
        GameController.secondsRemaining = timeRemaining;


        //for Animator
        if(timerIsRunning)
        {
            fishAnim.SetBool("Start", true);
        }

        if(timeRemaining < startingTimeAmount - startTextTime)
        {
            startText.enabled = false;
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("start"))
        {
            //when player touched "start" game object, timer starts count down.
            //Debug.Log("collided start object");
            other.gameObject.SetActive(false);
            //show player game starts
            startText.enabled = true;
            startText.text = "Game Start!";
            //timer on
            TimerOn = true;
            timerIsRunning = true;


            GetComponent<fishRandomMovement>().enabled = true;
        }

        if (other.gameObject.CompareTag("goal"))
        {
            //when player touched "goal" game object, timer stop count down.
            //Debug.Log("collided goal object");
            //other.gameObject.SetActive(false);
            //show a player game end
            gameEndText.enabled = true;
            gameEndText.text = "You Win!";
            //timer off
            TimerOn = false;
            timerIsRunning = false;
            //switch scene
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            //game manager and scene switch stuff - vivian
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("GameController"));
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            scoreScreen.SetActive(true);
            // value updates
            if (SceneManager.GetActiveScene().buildIndex > GameController.levelsComplete)
            {
                GameController.levelsComplete = SceneManager.GetActiveScene().buildIndex;
            }

            /*
            GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
            if (gameController != null)
            {
                GameController.score = gameController.GetComponent<GameController>().ScoreEquation(GameController.secondsRemaining, GameController.bottlesCollected, GameController.Trophypickedup);
            }
            */

            //score screen updates
            if(scoreScreen != null)
            {
                float timeScore;
                float bottleScore;
                float trophy = 1;

                timeText.text = Mathf.RoundToInt(timeRemaining) + " X " + GameController.SecondstoPointsRatio + " = " + (Mathf.RoundToInt(timeRemaining) * GameController.SecondstoPointsRatio);
                bottleText.text = GameController.bottlesCollected + " X " + GameController.bottlestoPointsRatio + " = " + (GameController.bottlesCollected * GameController.bottlestoPointsRatio);
                timeScore = (Mathf.RoundToInt(timeRemaining) * GameController.SecondstoPointsRatio);
                bottleScore = (GameController.bottlesCollected * GameController.bottlestoPointsRatio);
                if (GameController.Trophypickedup)
                {
                    trophyText.text = " X " + GameController.tropyPointMultiplyer;
                    trophy = GameController.tropyPointMultiplyer;
                }
                else if (!GameController.Trophypickedup)
                {
                    trophyText.text = " --- ";
                    trophy = 1;
                }

                GameController.score = Mathf.RoundToInt((timeScore + bottleScore) * trophy);
                scoreText.text = GameController.score.ToString();
            }
        }

        // for water bottle collectible
        if(other.gameObject.tag == "Bottle")
        {
            BottleCollectable bottle = other.gameObject.GetComponent<BottleCollectable>();
            if(bottle != null)
            {
                timeRemaining += bottle.secondsAdded;
            }
            GameController.bottlesCollected++;
            Destroy(other.gameObject);

            timeAddedText.text = " + " + bottle.secondsAdded.ToString();

            StartCoroutine("TimeAddedTextDisplay");
        }

        //for soysauce/salt piles
        if (other.gameObject.tag == "TimeLoss")
        {
            BottleCollectable bottle = other.gameObject.GetComponent<BottleCollectable>();
            if (bottle != null)
            {
                timeRemaining -= bottle.secondsAdded;
            }

            Destroy(other.gameObject);

            timeLostText.text = " - " + bottle.secondsAdded.ToString();

            StartCoroutine("TimeLossTextDisplay");
        }

        if (other.gameObject.tag == "Trophy")
        {
            GameController.Trophypickedup = true;
            Destroy(other.gameObject);

            timeAddedText.text = "Trophy Get!";
        }

        if (other.gameObject.tag =="Candle")
        {
            timeRemaining = 0.1f;
        }

        if (other.gameObject.tag == "TutorialToilet")
        {
            GameObject.Find("Scene Manager").GetComponent<SceneSwitch>().LoadSceneRefresh(5);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Towel")
        {
            print("towel collided");
            if(other.GetComponent<TowelDrain>() != null)
            {
                timeRemaining -= other.gameObject.GetComponent<TowelDrain>().drainSpeed;
                other.gameObject.GetComponent<TowelDrain>().warning.enabled = true;
            }
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Towel")
        {
            other.gameObject.GetComponent<TowelDrain>().warning.enabled = false;
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
                    //Debug.Log("time over");
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


        GameController.score = 0;

        

        deathScreen.SetActive(true);
        if(deathScreen != null)
        {
            StartCoroutine("YouDiedFadeIn");
        }

        timeText.text = "0:00";

        GameObject player = this.gameObject;
        player.GetComponent<fishRandomMovement>().enabled = false;
        player.GetComponent<playerControl>().enabled = false;
        player.GetComponent<fishJumpControls>().enabled = false;
        player.transform.Find("Main Camera").GetComponent<camraControl>().enabled = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        fishAnim.SetBool("Death", true);
       

        //DontDestroyOnLoad(GameObject.FindGameObjectWithTag("GameController"));
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);



        //show menu so that player can choose "restart, or "back to menu"


        //collectables managment
        /* no longer needed
         * 
         *         timeRemaining = 33;
         * 
         Destroy(collectables);
         collectablesCopy.SetActive(true);
         collectables = Instantiate(collectablesCopy, collectablesCopy.transform.position, collectablesCopy.transform.rotation); 
         collectablesCopy.SetActive(false);

         GameController.Trophypickedup = false;
         //resets mouse so menu is workable
         Cursor.visible = true;
         Cursor.lockState = CursorLockMode.None;
        */
    }

    private IEnumerator TimeAddedTextDisplay()
    {
        timeLostText.enabled = false;
        for (int i = 0; i < 1; i++)
        {
            timeAddedText.enabled = true;

            yield return new WaitForSeconds(addTextTime);
        }
        timeAddedText.enabled = false;
    }

    private IEnumerator TimeLossTextDisplay()
    {
        timeAddedText.enabled = false;
        for (int i = 0; i < 1; i++)
        {
            timeLostText.enabled = true;

            yield return new WaitForSeconds(addTextTime);
        }
        timeLostText.enabled = false;
    }

    private IEnumerator YouDiedFadeIn()
    {
        CanvasRenderer[] youDied;
        youDied = new CanvasRenderer[2];
        youDied[0] = deathScreen.transform.Find("Background").GetComponent<CanvasRenderer>();
        youDied[1] = deathScreen.transform.Find("Background").transform.Find("YouDied").GetComponent<CanvasRenderer>();

        foreach (CanvasRenderer item in youDied)
        {
                item.SetAlpha(0f);
        }

        for (int i = 0; i < 20; i++)
        {
            foreach (CanvasRenderer item in youDied)
            {
                currentAlpha += 0.0001f;
                item.SetAlpha(currentAlpha);

            }
            yield return new WaitForSeconds(0.25f);
        }
    }
}