using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformRight3Level3 : MonoBehaviour
{
    public Transform transform;
    public bool touched = false; 
    public MovingPlatformLeft3Level3 movingPlatformLeft3Level3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!movingPlatformLeft3Level3.touched)
        {
            if (!touched)
            {
                transform.position = new Vector2(-4.84f, 50f);
            }
            else
            {
                transform.position = new Vector2(-11.86f, 50f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            touched = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            touched = false;
        }
    }
}
