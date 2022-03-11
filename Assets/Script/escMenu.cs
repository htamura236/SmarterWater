using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class escMenu : MonoBehaviour
{
   public Canvas MenuToOpen;

   void Start()
   {
   MenuToOpen = GetComponent<Canvas> ();
   }

    
   void Update()
   {

    if(Input.GetKeyDown(KeyCode.Escape))
        {
        OpenMenu();
        }
   }

   public void Options()
   {
           Debug.Log("Options clicked");

   } 
   public void Restart()
   {
           SceneManager.LoadScene(1);
           Debug.Log("Restart clicked");
   }
    public void BackMenu()
   {
           SceneManager.LoadScene(0);
           Debug.Log("Exit clicked");
   }
    public void CloseTab()
   {
           MenuToOpen.enabled = !MenuToOpen.enabled;
           Debug.Log("X clicked");
   }
    public void QuitGame()
    {
           Application.Quit();
    }
   private void OpenMenu()
   {
         MenuToOpen.enabled = !MenuToOpen.enabled;
         Debug.Log("menuOpened");
   }
}