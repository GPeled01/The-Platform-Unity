using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot2 : MonoBehaviour
{
    private Inventory2 inventory;
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Player2").GetComponent<Inventory2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && inventory.isFull[0])
            DropItem();
        if (transform.childCount <= 0)
            inventory.isFull[i] = false;

    }

    public void DropItem() {
        foreach (Transform child in transform) {
            child.GetComponent<Spawn>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }
}
