using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformsLeftLevel3 : MonoBehaviour
{
    public Transform transform;
    public bool touched = false; 
    public MovingPlatformRightLevel3 movingPlatformRightLevel3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!movingPlatformRightLevel3.touched)
        {
            if (!touched)
            {
                transform.position = new Vector2(5f, 43.5f);
            }
            else 
            {
                transform.position = new Vector2(16.5f, 43.5f);
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
