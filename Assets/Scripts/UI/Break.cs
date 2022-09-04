using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public bool touched;
    public bool touched2;

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
    
    private void OnTriggerEnter2D(Collider2D other) {
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
