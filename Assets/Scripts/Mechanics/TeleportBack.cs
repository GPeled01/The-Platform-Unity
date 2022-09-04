using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class TeleportBack : MonoBehaviour
{
    public bool touched;
    public bool touched2;
    public PlayerController playerController;
    private Transform player;
    

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && touched && playerController.controlEnabled) {
            Teleport1();
        }
        else if (Input.GetKeyDown(KeyCode.C) && touched2 && !playerController.controlEnabled) {
            Teleport1();
        }
    }

    private void Teleport1() {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if (playerController.controlEnabled) {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else {
            player = GameObject.Find("Player2").transform;
        }
        //Vector2 playerPos = new Vector2(player.position.x, player.position.y + 0.5f);
        player.position = new Vector2(71.46896f, -2.575f);
        // Instantiate(item, playerPos, Quaternion.identity);
    }


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
