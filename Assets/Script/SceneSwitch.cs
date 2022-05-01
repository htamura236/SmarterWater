using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitch : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private Animator fishAnim;

    private Vector3 lockPos;
    private bool locked;
    private bool timerGoing;

    private void Awake()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        timerGoing = false;
    }

    private void Update()
    {
        PauseMenu();
        if (locked && player != null)
        {
            player.transform.position = lockPos;
        }

        if(Input.GetKeyDown("space") && locked)
        {
            Resume();
        }
    }

    public void LoadSceneRefresh(int sceneNum)
    {
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("GameController"));
        GameController.levelNumber = sceneNum;
        GameController.bottlesCollected = 0;
        GameController.secondsRemaining = 0;
        GameController.Trophypickedup = false;
        GameController.score = 0;
        SceneManager.LoadScene(sceneNum);
    }

    public void ReloadScene()
    {
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("GameController"));
        GameController.levelNumber = SceneManager.GetActiveScene().buildIndex;
        GameController.bottlesCollected = 0;
        GameController.secondsRemaining = 0;
        GameController.Trophypickedup = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(int sceneNum)
    {
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("GameController"));
        SceneManager.LoadScene(sceneNum);
    }

    public void RevealOrHide(GameObject gObject)
    {
        if(gObject != null)
        {
            if (gObject.activeSelf == true)
            {
                gObject.SetActive(false);
            }
            else
            {
                gObject.SetActive(true);
            }
        }
    }

    private void PauseMenu()
    {
        if(player != null && player.activeSelf)
        {
            camraControl camra = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<camraControl>();
            timerScript timer = player.GetComponent<timerScript>();

            if (Input.GetKeyDown("p"))
            {
                if (pauseMenu != null)
                {
                    if (pauseMenu.activeSelf == true)
                    {
                        pauseMenu.SetActive(false);
                        Cursor.visible = false;
                        camra.enabled = true;
                        Cursor.lockState = CursorLockMode.Locked;
                        locked = false;
                        player.GetComponent<BoxCollider>().enabled = true;

                        if (timerGoing)
                        {
                            timer.timerIsRunning = true;
                        }

                        fishAnim.enabled = true;
                    }
                    else
                    {
                        pauseMenu.SetActive(true);
                        Cursor.visible = true;
                        camra.enabled = false;
                        Cursor.lockState = CursorLockMode.None;
                        lockPos = player.transform.position;
                        locked = true;
                        player.GetComponent<BoxCollider>().enabled = false;
 
                        if (timer.timerIsRunning)
                        {
                            timerGoing = true;
                        }

                        timer.timerIsRunning = false;
                        fishAnim.enabled = false;
                    }
                }
            }
        }

    }

    public void Resume()
    {
        if (player != null)
        {
            camraControl camra = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<camraControl>();
            timerScript timer = player.GetComponent<timerScript>();

            if (pauseMenu != null)
            {
                if (pauseMenu.activeSelf == true)
                {
                    pauseMenu.SetActive(false);
                    Cursor.visible = false;
                    camra.enabled = true;
                    Cursor.lockState = CursorLockMode.Locked;
                    locked = false;
                    player.GetComponent<BoxCollider>().enabled = true;

                    if (timerGoing)
                    {
                        timer.timerIsRunning = true;
                    }

                    fishAnim.enabled = true;
                }
            }
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
