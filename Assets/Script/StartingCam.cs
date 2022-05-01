using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingCam : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objectsToHide;

    // Start is called before the first frame update
    private void Start()
    {
        foreach (GameObject item in objectsToHide)
        {
            item.SetActive(false);
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void startLevel()
    {
        foreach (GameObject item in objectsToHide)
        {
            item.SetActive(true);
        }

        gameObject.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
