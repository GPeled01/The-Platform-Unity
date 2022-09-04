using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class TurnLightON : MonoBehaviour
{
    public bool touched;
    public bool touched2;
    public PlayerController playerController;
    // private Transform player;
    

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.C) && touched && playerController.controlEnabled) {
    //         Teleport1();
    //     }
    //     else if (Input.GetKeyDown(KeyCode.C) && touched2 && !playerController.controlEnabled) {
    //         Teleport1();
    //     }
    // }


    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            touched = true;
        }
        else if (other.CompareTag("Player2")) {
            touched2 = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            touched = false;
        }
        else if (other.CompareTag("Player2")) {
            touched2 = false;
        }
    }
}