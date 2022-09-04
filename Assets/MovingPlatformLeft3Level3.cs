using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformLeft3Level3 : MonoBehaviour
{
    public bool touched = false; 
    // public MovingPlatformRight2Level3 movingPlatformRight2Level3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player2"))
        {
            touched = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player2"))
        {
            touched = false;
        }
    }
}
