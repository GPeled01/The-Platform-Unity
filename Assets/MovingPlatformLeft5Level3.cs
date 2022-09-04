using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformLeft5Level3 : MonoBehaviour
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
