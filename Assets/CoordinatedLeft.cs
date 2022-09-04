using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinatedLeft : MonoBehaviour
{
    public bool touched = false;
    public CoordinatedRight coordinatedRight;
    public GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (touched && coordinatedRight.touched)
        {
            gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player2")) {
            touched = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player2")) {
            touched = false;
        }
    }
}
