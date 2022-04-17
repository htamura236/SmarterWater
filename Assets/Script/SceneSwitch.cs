using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(int sceneNum)
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene(sceneNum);
    } 

    public void RevealOrHide(GameObject gObject)
    {
        if(gObject.activeSelf == true)
        {
            gObject.SetActive(false);
        }
        else
        {
            gObject.SetActive(true);
        }
    }
}
