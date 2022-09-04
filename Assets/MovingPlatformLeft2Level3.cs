using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformLeft2Level3 : MonoBehaviour
{
    public Transform transform;
    public bool touched = false; 
    public MovingPlatformRight2Level3 movingPlatformRight2Level3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!movingPlatformRight2Level3.touched)
        {
            if (!touched)
            {
                transform.position = new Vector2(21.39f, 45f);
            }
            else 
            {
                transform.position = new Vector2(14f, 45f);
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
