using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public GameObject effect;
    private Transform player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.C))
            Use();
    }

    public void Use() {
        Instantiate(effect, player.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
