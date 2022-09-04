using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    public void StartGame()
    {
       SceneManager.LoadScene(2);
    }

   public void SettingsButton()
   {
       SceneManager.LoadScene(1);
   }

}
