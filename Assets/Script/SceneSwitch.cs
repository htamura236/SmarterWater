using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
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
}
