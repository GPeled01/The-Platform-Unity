using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformRightLevel3 : MonoBehaviour
{
    public Transform transform;
    public bool touched = false; 
    public MovingPlatformLeft2Level3 movingPlatformLeft2Level3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!movingPlatformLeft2Level3.touched)
        {
            if (!touched)
            {
                transform.position = new Vector2(-19.74f, 45f);
            }
            else
            {
                transform.position = new Vector2(-12.4f, 45f);
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
