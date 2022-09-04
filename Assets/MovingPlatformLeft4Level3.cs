using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformLeft4Level3 : MonoBehaviour
{
    public Transform transform;
    public bool touched = false; 
    public MovingPlatformRight4Level3 movingPlatformRight4Level3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!movingPlatformRight4Level3.touched)
        {
            if (!touched)
            {
                transform.position = new Vector2(19.88f, 53f);
            }
            else 
            {
                transform.position = new Vector2(14.22f, 53f);
            }
        }
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
