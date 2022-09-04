using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class Teleport : MonoBehaviour
{
    private Transform transformPlayer1;
    private Transform transformPlayer2;
    private Transform transformCamera;
    public Transform wall;
    private Transform stars;
    public MoveCamera moveCamera;

    public SeperateWall seperateWall;
    public GameObject gameObjectwallLevel2;
    public GameObject gameObjectwallLevel1;
    
    public GameObject player;
    public GameObject player2;
    public bool openElevatorLeftLevel0 = false;
    public bool openElevatorRightLevel0 = false;
    public bool openElevatorLeftLevel1 = false;
    public bool openElevatorRightLevel1 = false;
    public bool openElevatorLeftLevel2 = false;
    public bool openElevatorRightLevel2 = false;
    public bool openElevatorLeftLevel3 = false;
    public bool openElevatorRightLevel3 = false;
    public bool level0 = true;
    public bool level1 = false;
    public bool level2 = false;
    public bool level3 = false;
    public bool level4 = false;
    // public GameObject seperate;

    public Animator animator;
    public Transform explode;
    public Animator animatorLeftLevel0;
    public Animator animatorRightLevel0;

    public Animator animatorLeft1Level0;
    public Animator animatorRight1Level0;


    public Animator animatorLeft;
    public Animator animatorRight;

    public Animator animatorLeft1;
    public Animator animatorRight1;

    public Animator animatorLeftLevel2;
    public Animator animatorRightLevel2;

    public Animator animatorLeft1Level2;
    public Animator animatorRight1Level2;

    public Animator animatorLeftLevel3;
    public Animator animatorRightLevel3;

    public Animator animatorLeft1Level3;
    public Animator animatorRight1Level3;

    // Start is called before the first frame update
    void Start()
    {
        transformPlayer1 = GameObject.Find("Player").transform;
        transformPlayer2 = GameObject.Find("Player2").transform;
        transformCamera = GameObject.Find("Main Camera").transform;
        // seperateWall = GameObject.Find("Seperate Wall").GetComponent<SeperateWall>();
        // wall = GameObject.Find("Seperate Wall").transform;
        stars = GameObject.Find("stars").transform;
    }


    // Update is called once per frame
    void Update()
    {
        // Debug.Log(level0);
        if (level0)
        {
            if (transformPlayer1.position.x >= 19 && transformPlayer1.position.x <= 21)
            {
                openElevatorLeftLevel0 = true;
                animatorLeftLevel0.SetBool("openElevator", true);
            }
            else
            {
                openElevatorLeftLevel0 = false;
                animatorLeftLevel0.SetBool("openElevator", false);
            }

            if (transformPlayer2.position.x >= -21 && transformPlayer2.position.x <= -19)
            {
                openElevatorRightLevel0 = true;
                animatorRightLevel0.SetBool("openElevator", true);

            }
            else
            {
                openElevatorRightLevel0 = false;
                animatorRightLevel0.SetBool("openElevator", false);
            }

            if (openElevatorRightLevel0 && openElevatorLeftLevel0)
            {
                moveCamera.camAnim.enabled = false;
                seperateWall.stopped = true;
                StartCoroutine(waitLevel0());
                StartCoroutine(wait2Level0());
            }
        }

        if (level1)
        {
            if (transformPlayer1.position.x >= 1 && transformPlayer1.position.x <= 3.45 && transformPlayer1.position.y >= 10.5)
            {
                openElevatorLeftLevel1 = true;
                animatorLeft.SetBool("openElevator", true);
            }
            else
            {
                openElevatorLeftLevel1 = false;
                animatorLeft.SetBool("openElevator", false);
            }

            if (transformPlayer2.position.x >= -2.9 && transformPlayer2.position.x <= -0.45 && transformPlayer2.position.y >= 10.5)
            {
                openElevatorRightLevel1= true;
                animatorRight.SetBool("openElevator", true);
            }
            else
            {
                openElevatorRightLevel1 = false;
                animatorRight.SetBool("openElevator", false);
            }

            if (openElevatorRightLevel1 && openElevatorLeftLevel1)
            {
                moveCamera.camAnim.enabled = false;
                seperateWall.stopped = true;
                StartCoroutine(waitLevel1());
                StartCoroutine(wait2Level1());
            }
        }

        if (level2)
        {
            if (transformPlayer1.position.x >= 1 && transformPlayer1.position.x <= 3.45 && transformPlayer1.position.y >= 10.5)
            {
                openElevatorLeftLevel2 = true;
                animatorLeftLevel2.SetBool("openElevator", true);
            }
            else
            {
                openElevatorLeftLevel2 = false;
                animatorLeftLevel2.SetBool("openElevator", false);
            }

            if (transformPlayer2.position.x >= -2.9 && transformPlayer2.position.x <= -0.45 && transformPlayer2.position.y >= 10.5)
            {
                openElevatorRightLevel2= true;
                animatorRightLevel2.SetBool("openElevator", true);
            }
            else
            {
                openElevatorRightLevel2 = false;
                animatorRightLevel2.SetBool("openElevator", false);
            }

            if (openElevatorRightLevel2 && openElevatorLeftLevel2)
            {
                moveCamera.camAnim.enabled = false;
                seperateWall.stopped = true;
                StartCoroutine(waitLevel2());
                StartCoroutine(wait2Level2());
            }
        }

        if (level3)
        {
            if (transformPlayer1.position.x >= 1 && transformPlayer1.position.x <= 3.45 && transformPlayer1.position.y >= 10.5)
            {
                openElevatorLeftLevel3 = true;
                animatorLeftLevel3.SetBool("openElevator", true);
            }
            else
            {
                openElevatorLeftLevel3 = false;
                animatorLeftLevel3.SetBool("openElevator", false);
            }

            if (transformPlayer2.position.x >= -2.9 && transformPlayer2.position.x <= -0.45 && transformPlayer2.position.y >= 10.5)
            {
                openElevatorRightLevel3= true;
                animatorRightLevel3.SetBool("openElevator", true);
            }
            else
            {
                openElevatorRightLevel3 = false;
                animatorRightLevel3.SetBool("openElevator", false);
            }

            if (openElevatorRightLevel3 && openElevatorLeftLevel3)
            {
                moveCamera.camAnim.enabled = false;
                seperateWall.stopped = true;
                StartCoroutine(waitLevel3());
                StartCoroutine(wait2Level3());
            }
        }
    }


    IEnumerator waitLevel0()
    {
        yield return new WaitForSeconds(1);
        level0 = false;
        level1 = true;
        // animator.SetBool("explode", true);
        TeleportLevel0();
    }
    IEnumerator wait2Level0()
    {
        yield return new WaitForSeconds(5);
        // seperate.SetActive(true);
        Vector2 wallPos1 = new Vector2(wall.position.x, -25.22f);
        wall.position = wallPos1;
        seperateWall.stopped = false;
        // moveCamera.camAnim.enabled = true;
    }
    IEnumerator waitLevel1()
    {
        yield return new WaitForSeconds(1);
        level1 = false;
        level2 = true;
        // animator.SetBool("explode", true);
        TeleportLevel1();
    }
    IEnumerator wait2Level1()
    {
        yield return new WaitForSeconds(5);
        Vector2 wallPos1 = new Vector2(wall.position.x, 0f);
        wall.position = wallPos1;
        seperateWall.stopped = false;
        // moveCamera.camAnim.enabled = true;
    }

    IEnumerator waitLevel2()
    {
        yield return new WaitForSeconds(1);
        level2 = false;
        level3 = true;
        // animator.SetBool("explode", true);
        TeleportLevel2();
    }
    IEnumerator wait2Level2()
    {
        yield return new WaitForSeconds(5);
        Vector2 wallPos1 = new Vector2(wall.position.x, 25.22f);
        wall.position = wallPos1;
        seperateWall.stopped = false;
        // moveCamera.camAnim.enabled = true;
    }

    IEnumerator waitLevel3()
    {
        yield return new WaitForSeconds(1);
        level3 = false;
        level4 = true;
        // animator.SetBool("explode", true);
        TeleportLevel3();
    }
    IEnumerator wait2Level3()
    {
        yield return new WaitForSeconds(5);
        Vector2 wallPos1 = new Vector2(wall.position.x, 50.44f);
        wall.position = wallPos1;
        seperateWall.stopped = false;
        // moveCamera.camAnim.enabled = true;
    }


    private void TeleportLevel0() {
        // seperateWall.redLight.SetBool("lightOn", false);
        // seperateWall.OnOff.SetActive(false);
        // stars.position = new Vector2(0f, 14.5f);
        transformPlayer1.position = new Vector2(20.1f, -8.44f);
        animatorLeft1Level0.SetBool("openElevator", true);
        player.SetActive(false);
        transformPlayer2.position = new Vector2(-20f, -8.44f);
        animatorRight1Level0.SetBool("openElevator", true);
        player2.SetActive(false);
    }
    private void TeleportLevel1() {
        seperateWall.redLight.SetBool("lightOn", false);
        seperateWall.OnOff.SetActive(false);
        stars.position = new Vector2(0f, 14.5f);
        transformPlayer1.position = new Vector2(20.1f, 16.78f);
        animatorLeft1.SetBool("openElevator", true);
        player.SetActive(false);
        transformPlayer2.position = new Vector2(-20f, 16.78f);
        animatorRight1.SetBool("openElevator", true);
        player2.SetActive(false);
    }

    private void TeleportLevel2() {
        seperateWall.redLight.SetBool("lightOn", false);
        seperateWall.OnOff.SetActive(false);
        stars.position = new Vector2(0f, 38f);
        transformPlayer1.position = new Vector2(20.1f, 42f);
        animatorLeft1Level2.SetBool("openElevator", true);
        player.SetActive(false);
        transformPlayer2.position = new Vector2(-20f, 42f);
        animatorRight1Level2.SetBool("openElevator", true);
        player2.SetActive(false);
    }

    private void TeleportLevel3() {
        seperateWall.redLight.SetBool("lightOn", false);
        seperateWall.OnOff.SetActive(false);
        stars.position = new Vector2(0f, 67.3f);
        transformPlayer1.position = new Vector2(20.1f, 67.22f);
        animatorLeft1Level3.SetBool("openElevator", true);
        player.SetActive(false);
        transformPlayer2.position = new Vector2(-20f, 67.22f);
        animatorRight1Level3.SetBool("openElevator", true);
        player2.SetActive(false);
    }


}
