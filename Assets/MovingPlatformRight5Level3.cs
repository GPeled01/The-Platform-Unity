using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformRight5Level3 : MonoBehaviour
{
    public Transform transform;
    public bool touched = false; 
    public MovingPlatformLeft5Level3 movingPlatformLeft5Level3;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!movingPlatformLeft5Level3.touched)
        {
            if (!touched)
            {
                transform.position = new Vector2(-20.42f, 57.2f);
            }
            else
            {
                transform.position = new Vector2(-16.4f, 57.2f);
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
