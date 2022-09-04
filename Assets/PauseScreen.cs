using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public bool check = false;
    public Teleport teleport;
    public SeperateWall seperateWall;
    public Transform transformPlayer1;
    public Transform transformPlayer2;
    public GameObject OnOff; 
    public Animator redLight;
    public void Setup()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            gameObject.SetActive(true);
            seperateWall.stopped = true;
        }
        else
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
            seperateWall.stopped = false;
        }
    }

    public void RestartButton()
    {
       if (teleport.level0)
       {
           Time.timeScale = 1;
           gameObject.SetActive(false);
           seperateWall.stopped = false;
           SceneManager.LoadScene(1);
           OnOff.SetActive(false);
           redLight.SetBool("lightOn", false);
       }
       if (teleport.level1)
       {
           Time.timeScale = 1;
           gameObject.SetActive(false);
           seperateWall.stopped = false;
           Vector2 wallPos1 = new Vector2(seperateWall.transform.position.x, -25.22f);
           seperateWall.transform.position = wallPos1;
           transformPlayer1.position = new Vector2(20.1f, -8.44f);
           transformPlayer2.position = new Vector2(-20f, -8.44f);
           OnOff.SetActive(false);
           redLight.SetBool("lightOn", false);
       }
       if (teleport.level2)
       {
           Time.timeScale = 1;
           gameObject.SetActive(false);
           seperateWall.stopped = false;
           Vector2 wallPos1 = new Vector2(seperateWall.transform.position.x, 0f);
           seperateWall.transform.position = wallPos1;
           transformPlayer1.position = new Vector2(20.1f, 16.78f);
           transformPlayer2.position = new Vector2(-20f, 16.78f);
           OnOff.SetActive(false);
           redLight.SetBool("lightOn", false);
       }
       if (teleport.level3)
       {
           Time.timeScale = 1;
           gameObject.SetActive(false);
           seperateWall.stopped = false;
           Vector2 wallPos1 = new Vector2(seperateWall.transform.position.x, 25.22f);
           seperateWall.transform.position = wallPos1;
           transformPlayer1.position = new Vector2(20.1f, 42f);
           transformPlayer2.position = new Vector2(-20f, 42f);
           OnOff.SetActive(false);
           redLight.SetBool("lightOn", false);
       }
    }


    public void MainMenuButton()
    {
       SceneManager.LoadScene(0);
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        seperateWall.stopped = false;
    }
}
