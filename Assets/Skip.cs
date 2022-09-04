using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Skip : MonoBehaviour
{
    // public bool paused = false;
    // public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SkipIntro()
    {
       SceneManager.LoadScene(1);
    }

    // public void Pause1()
    // {
    //     if (paused)
    //     {
    //         paused = !paused;
    //         videoPlayer.Continue();
    //         Time.timeScale = 1;
    //     }
    //     else
    //     {
    //         paused = !paused;
    //         videoPlayer.Pause();
    //         Time.timeScale = 0;
    //     }
    // }
}
