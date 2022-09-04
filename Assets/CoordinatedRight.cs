using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinatedRight : MonoBehaviour
{
    public bool touched = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            touched = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            touched = false;
        }
    }

}
