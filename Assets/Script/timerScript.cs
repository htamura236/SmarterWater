using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timerScript : MonoBehaviour
{
    //for timer
    public float targetTime = 60.0f;
    public Text countText;
    private int count;

    public bool TimerOn;

    //for win/lose screen
    public Text endText;
 
    void Start()
    {
        //hide endText at the bigining

        TimerOn = false;
        //this is not working now
    }

    void Update()
    {
        if(TimerOn = true)
        {
            setTimer();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        //collide with object tagged "start"
        if (other.gameObject.CompareTag("start"))
        {
            //activate timer and start countdown.
            TimerOn = true;
        }

        //fish gets some items
        if (other.gameObject.CompareTag("timeRecovery"))
        {
            //add some seconds to the timer.
            //hide the object
            other.gameObject.SetActive(false);
        }

        //collide with object tagged "goal"
        if (other.gameObject.CompareTag("goal"))
        {
            TimerOn = false;
            endText.text = "You Win!!";
        }
    }
    void setTimer()
    {
        targetTime -= Time.deltaTime;
        SetCountText();

        if (targetTime <= 0.0f)
        {
            timerEnd();
        }
    }

    void timerEnd()
    {
        //fish dies, game over
        //game over text
        endText.text = "You Lost!";
        //replay, back to title buttons
        //make fish uncontrollable
    }

    void SetCountText()
    {

        countText.text = "Time: " + count.ToString();
    }

}
