using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformRedLevel2 : MonoBehaviour
{
    public Transform transform;
    public bool check_stop = false;

    // Start is called before the first frame update
    void Start()
    {
        // transform = GameObject.Find("Red platform").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 29.8f || transform.position.y < 25.5f){
            // Debug.Log("change");
            check_stop = !check_stop;
        }

        if(!check_stop){
            Vector2 wallPos = new Vector2(transform.position.x, transform.position.y + 0.03f);
            transform.position = wallPos;
        } else{
            Vector2 wallPos = new Vector2(transform.position.x, transform.position.y - 0.03f);
            transform.position = wallPos;
        }
    }
}
