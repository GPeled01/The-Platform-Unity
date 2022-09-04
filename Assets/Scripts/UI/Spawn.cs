using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class Spawn : MonoBehaviour
{       
    public GameObject item;
    // public GameObject player1;
    private Transform player;

    //private Vector3 scaleChange;
    public PlayerController playerController;

    private void start() {
        //playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //scaleChange = new Vector3(0.3f, 0.3f, 0.3f);
        //this.gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        // Debug.Log(player);
    }

    // private void update() {
    //     Debug.Log(playerController.controlEnabled);
    // }

    public void SpawnDroppedItem() {
        //Debug.Log(player);
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if (playerController.controlEnabled) {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else {
            player = GameObject.Find("Player2").transform;
        }
        Vector2 playerPos = new Vector2(player.position.x, player.position.y + 0.5f);
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
