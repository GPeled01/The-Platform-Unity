using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Transform transform;
    public bool check_stop = false;
    // Start is called before the first frame update
    void Start()
    {
        transform = GameObject.Find("move").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 12f || transform.position.x < 8f){
            check_stop = !check_stop;
        }
        if(!check_stop){
            Vector2 wallPos = new Vector2(transform.position.x + 0.01f, transform.position.y);
            transform.position = wallPos;
        }
        else{
            Vector2 wallPos = new Vector2(transform.position.x - 0.01f, transform.position.y);
            transform.position = wallPos;
        }
    }
}
