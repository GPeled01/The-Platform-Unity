using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class Pickup : MonoBehaviour
{
    //public GameObject item;
    private Inventory inventory;
    private Inventory2 inventory2;
    public GameObject itemButton;
    private bool touched = false;
    private bool touched2 = false;
    public PlayerController playerController;

    void Start() {
        //item = GameObject.Find("Lighter Pickup(clone)");
        //item.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        inventory2 = GameObject.Find("Player2").GetComponent<Inventory2>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //item = GameObject.FindGameObjectWithTag("LighterPickup");
        //this.gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.X) && touched && !inventory.isFull[0] && playerController.controlEnabled) {
            Pick();
        }
        if (Input.GetKeyDown(KeyCode.X) && touched2 && !inventory2.isFull[0] && !playerController.controlEnabled) {
            Pick2();
        }
    }

    private void Pick() {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false) {
                // ITEAM CAN BE ADDED TO INVENTORY !
                inventory.isFull[i] = true;
                GameObject instantiateItem = Instantiate(itemButton, inventory.slots[i].transform, false) as GameObject;
                //instantiateItem.gameObject.tag = "LighterPickup";
                //instantiateItem.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                Destroy(gameObject);
                break;
            }
        }
    }

    private void Pick2() {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory2.isFull[i] == false) {
                // ITEAM CAN BE ADDED TO INVENTORY !
                inventory2.isFull[i] = true;
                GameObject instantiateItem = Instantiate(itemButton, inventory2.slots[i].transform, false) as GameObject;
                //instantiateItem.gameObject.tag = "LighterPickup";
                //instantiateItem.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                Destroy(gameObject);
                break;
            }
        }
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
