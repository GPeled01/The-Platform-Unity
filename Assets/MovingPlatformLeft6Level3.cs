using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformLeft6Level3 : MonoBehaviour
{
    public Transform transform;
    public bool touched = false;
    public MovingPlatformRight6Level3 movingPlatformRight6Level3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!movingPlatformRight6Level3.touched)
        {
            if (!touched)
            {
                transform.position = new Vector2(19.73f, 60.5f);
            }
            else 
            {
                transform.position = new Vector2(8.77f, 60.5f);
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
