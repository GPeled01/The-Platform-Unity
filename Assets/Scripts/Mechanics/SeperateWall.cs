using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeperateWall : MonoBehaviour
{
    private Transform wallLevel1;
    private Transform stars;
    // private Transform wallLevel2;
    private Transform camera;
    public bool stopped = false;
    public bool freezed = false;
    public bool chekc1 = false;
    public float speedLevel0 = 0.005f;

    public float speedLevel1 = 0.005f;
    public float speedLevel2 = 0.003f;
    public float speedLevel3 = 0.004f;
    public float speedLevel4 = 0.005f;
    public float speedStars = 0.01f;

    // public GameObject gameObjectwallLevel2;
    
    // public float speed = 2f;
    public Teleport teleport;

    private Shake shake;

    public Animator animator;
    public Animator redLight;
    public Animator explodeLevel0;
    public GameObject OnOff;


    public GameOverScreen GameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        wallLevel1 = GameObject.Find("Seperate Wall").transform;
        stars = GameObject.Find("stars").transform;
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
        if (!stopped && !freezed && teleport.level0)
        {
            Vector2 wallPos1 = new Vector2(wallLevel1.position.x, wallLevel1.position.y + speedLevel1);
            wallLevel1.position = wallPos1;
        }
        if (!stopped && !freezed && teleport.level1)
        {
            Vector2 wallPos1 = new Vector2(wallLevel1.position.x, wallLevel1.position.y + speedLevel1);
            wallLevel1.position = wallPos1;
        }
        if (!stopped && !freezed)
        {
            Vector2 moveStars = new Vector2(stars.position.x, stars.position.y + speedStars);
            stars.position = moveStars;
        }

        if (wallLevel1.position.y >= camera.position.y - 3.5) 
        {
            stopped = true;
            GameOver();
        }
        if (wallLevel1.position.y >= camera.position.y - 4) 
        {
            animator.SetBool("explode", true);
        }
        if (wallLevel1.position.y >= camera.position.y - 11.3) 
        {
            redLight.SetBool("lightOn", true);
            if (redLight.GetCurrentAnimatorStateInfo(0).IsName("LightON"))
            {
                OnOff.SetActive(true);
            }
            else if (redLight.GetCurrentAnimatorStateInfo(0).IsName("LightIsOff1"))
            {
                OnOff.SetActive(false);
            }
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
            Vector2 wallPos2 = new Vector2(wallLevel1.position.x, wallLevel1.position.y + speedLevel2);
            wallLevel1.position = wallPos2;
        }

        if (!stopped && !freezed && teleport.level3)
        {
            Vector2 wallPos2 = new Vector2(wallLevel1.position.x, wallLevel1.position.y + speedLevel3);
            wallLevel1.position = wallPos2;
        }

        if (!stopped && !freezed && teleport.level4)
        {
            Vector2 wallPos2 = new Vector2(wallLevel1.position.x, wallLevel1.position.y + speedLevel4);
            wallLevel1.position = wallPos2;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player") || other.CompareTag("Player2"))
        {
            // Time.timeScale = 0;
            explodeLevel0.SetBool("explode", true);
            stopped = true;
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.3f);
        GameOver();
    }
}

