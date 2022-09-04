using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformLevel2Left : MonoBehaviour
{
    public Transform transform;
    public bool check_stop = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > -8f || transform.position.x < -12f){
            check_stop = !check_stop;
        }
        if(!check_stop){
            Vector2 wallPos = new Vector2(transform.position.x + 0.03f, transform.position.y);
            transform.position = wallPos;
        }
        else{
            Vector2 wallPos = new Vector2(transform.position.x - 0.03f, transform.position.y);
            transform.position = wallPos;
        }
    }
}
