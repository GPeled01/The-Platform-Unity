using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using Platformer.View;

public class SeperateWall2 : MonoBehaviour
{
    private Transform wallLevel1;
    // private Transform wallLevel2;
    private Transform camera;
    public bool stopped = false;
    public bool freezed = false;

    // public GameObject gameObjectwallLevel2;
    
    // public float speed = 2f;

    public Teleport teleport;

    private Shake shake;


    public GameOverScreen GameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        wallLevel1 = GameObject.Find("Seperate Wall").transform;
        // wallLevel2 = GameObject.Find("Seperate Wall2").transform;
        camera = GameObject.Find("Main Camera").transform;
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    public void GameOver()
    {
        GameOverScreen.Setup();
    }

    // Update is called once per frame
    void Update()
    {
        // shake.CamShake();
        // Debug.Log(teleport.level2);
        if (!stopped && !freezed && teleport.level1)
        {
            Vector2 wallPos1 = new Vector2(wallLevel1.position.x, wallLevel1.position.y + 0.01f);
            wallLevel1.position = wallPos1;
            // Debug.Log(camera.position.y);
        }

        if (wallLevel1.position.y >= camera.position.y - 2) 
        {
            stopped = true;
            GameOver();
        }

        if (wallLevel1.position.y >= camera.position.y - 7.53)
        {
            shake.CamShake();
        }

        if (wallLevel1.position.y >= camera.position.y - 11.25)
        {
            shake.CamShake2();
        }

        if (wallLevel1.position.y >= camera.position.y - 14.6)
        {
            shake.CamShake3();
        }


        
        if (!stopped && !freezed && teleport.level2)
        {
            Vector2 wallPos2 = new Vector2(wallLevel1.position.x, wallLevel1.position.y + 0.05f);
            wallLevel1.position = wallPos2;
        }

        
        // if (teleport.levelUp)
        // {
        //     teleport.levelUp = false;
        //     Vector2 wallPos1 = new Vector2(transform.position.x, -2f);
        //     transform.position = wallPos1;
        // }
    }
}

