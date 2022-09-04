using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeperateWallLevel2 : MonoBehaviour
{

    private Transform wallLevel2;
    private Transform camera;
    public bool stopped = false;
    public bool freezed = false;
    public GameOverScreen GameOverScreen;

    public GameObject gameObjectwallLevel2;
    public Teleport teleport;

    // Start is called before the first frame update
    void Start()
    {
        gameObjectwallLevel2.SetActive(false);
        wallLevel2 = GameObject.Find("Seperate Wall").transform;
        // wallLevel2 = GameObject.Find("Seperate Wall2").transform;
        camera = GameObject.Find("Main Camera").transform;
    }

    public void GameOver()
    {
        GameOverScreen.Setup();
    }

    // Update is called once per frame
    void Update()
    {
       if (!stopped && !freezed)
        {
            Vector2 wallPos2 = new Vector2(wallLevel2.position.x, wallLevel2.position.y + 0.01f);
            wallLevel2.position = wallPos2;
            // Debug.Log(camera.position.y);
        }

        if (wallLevel2.position.y >= camera.position.y - 2) 
        {
            stopped = true;
            GameOver();
        }
    }
}
