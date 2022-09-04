using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformLevel2 : MonoBehaviour
{
    private Transform transform;
    public bool check_stop = false;
    // Start is called before the first frame update
    void Start()
    {
        transform = GameObject.Find("simple platform (2)").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > -10.4f || transform.position.x < -13.6f){
            check_stop = !check_stop;
        }
        if(!check_stop){
            Vector2 wallPos = new Vector2(transform.position.x + 0.02f, transform.position.y);
            transform.position = wallPos;
        }
        else{
            Vector2 wallPos = new Vector2(transform.position.x - 0.02f, transform.position.y);
            transform.position = wallPos;
        }
    }
}
