using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class MoveCamera : MonoBehaviour
{
    
    public float speed = 9f;
    public Teleport teleport;
    private Transform transformPlayer1;
    private Transform transformPlayer2;
    public Transform redLightOff;

    public Animator camAnim;
    public Animator animator;
    public Transform explode;

    public GameObject player;
    public GameObject player2;
    public Transform headRight;
    public Transform headLeft;
    // public Animator animatorCamera;
    

    void start()
    {
        transformPlayer1 = GameObject.Find("Player").transform;
        transformPlayer2 = GameObject.Find("Player2").transform;
        // animatorCamera = GetComponent<Animator>();
        // redLightOff = GameObject.Find("redLightOff").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posCamera = transform.position;
        if (teleport.level1)
        {
            camAnim.SetBool("shake2", false);
            camAnim.SetBool("shake3", false);
            camAnim.SetBool("shake", false);

            if (posCamera.y <= 0.3)
            {
                posCamera.y += speed * Time.deltaTime;
                transform.position = posCamera;
            }
            else
            {
                // Vector2 redLightMove = new Vector2(redLightOff.position.x, transform.position.y + 7.2f);
                // redLightOff.position = redLightMove;
                Vector2 headLeftTemp = new Vector2(headLeft.position.x, transform.position.y + 11f);
                headLeft.position = headLeftTemp;
                Vector2 headRightTemp = new Vector2(headRight.position.x, transform.position.y + 11f);
                headRight.position = headRightTemp;
                // animator.SetBool("explode", false);
                // Vector2 temp = new Vector2(explode.position.x, transform.position.y + 10f);
                // explode.position = temp;
                player.SetActive(true);
                player2.SetActive(true);
                teleport.animatorLeft1Level0.SetBool("openElevator", false);
                teleport.animatorRight1Level0.SetBool("openElevator", false);
            }
        }

        if (teleport.level2)
        {
            camAnim.SetBool("shake2", false);
            camAnim.SetBool("shake3", false);
            camAnim.SetBool("shake", false);

            if (posCamera.y <= 26.2)
            {
                posCamera.y += speed * Time.deltaTime;
                transform.position = posCamera;
            }
            else
            {
                Vector2 redLightMove = new Vector2(redLightOff.position.x, transform.position.y + 7.2f);
                redLightOff.position = redLightMove;
                Vector2 headLeftTemp = new Vector2(headLeft.position.x, transform.position.y + 11f);
                headLeft.position = headLeftTemp;
                Vector2 headRightTemp = new Vector2(headRight.position.x, transform.position.y + 11f);
                headRight.position = headRightTemp;
                // animator.SetBool("explode", false);
                Vector2 temp = new Vector2(explode.position.x, transform.position.y + 10f);
                explode.position = temp;
                player.SetActive(true);
                player2.SetActive(true);
                teleport.animatorLeft1.SetBool("openElevator", false);
                teleport.animatorRight1.SetBool("openElevator", false);
            }
        }

        if (teleport.level3)
        {
            camAnim.SetBool("shake2", false);
            camAnim.SetBool("shake3", false);
            camAnim.SetBool("shake", false);

            if (posCamera.y <= 52.2)
            {
                posCamera.y += speed * Time.deltaTime;
                transform.position = posCamera;
            }
            else
            {
                Vector2 redLightMove = new Vector2(redLightOff.position.x, transform.position.y + 7.2f);
                redLightOff.position = redLightMove;
                Vector2 headLeftTemp = new Vector2(headLeft.position.x, transform.position.y + 11f);
                headLeft.position = headLeftTemp;
                Vector2 headRightTemp = new Vector2(headRight.position.x, transform.position.y + 11f);
                headRight.position = headRightTemp;
                // animator.SetBool("explode", false);
                Vector2 temp = new Vector2(explode.position.x, transform.position.y + 10f);
                explode.position = temp;
                player.SetActive(true);
                player2.SetActive(true);
                teleport.animatorLeft1Level2.SetBool("openElevator", false);
                teleport.animatorRight1Level2.SetBool("openElevator", false);
            }
        }

        if (teleport.level4)
        {
            camAnim.SetBool("shake2", false);
            camAnim.SetBool("shake3", false);
            camAnim.SetBool("shake", false);

            if (posCamera.y <= 78.2)
            {
                posCamera.y += speed * Time.deltaTime;
                transform.position = posCamera;
            }
            else
            {
                Vector2 redLightMove = new Vector2(redLightOff.position.x, transform.position.y + 7.2f);
                redLightOff.position = redLightMove;
                Vector2 headLeftTemp = new Vector2(headLeft.position.x, transform.position.y + 11f);
                headLeft.position = headLeftTemp;
                Vector2 headRightTemp = new Vector2(headRight.position.x, transform.position.y + 11f);
                headRight.position = headRightTemp;
                // animator.SetBool("explode", false);
                Vector2 temp = new Vector2(explode.position.x, transform.position.y + 10f);
                explode.position = temp;
                player.SetActive(true);
                player2.SetActive(true);
                teleport.animatorLeft1Level3.SetBool("openElevator", false);
                teleport.animatorRight1Level3.SetBool("openElevator", false);
            }
        }

    }
}
