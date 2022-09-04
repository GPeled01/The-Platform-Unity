using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWall : MonoBehaviour
{
    public bool finishAnim = true;
    public SeperateWall seperateWall;
    // public Animator redPlatform;
    // private bool touched = false;
    // private bool touched2 = false;
    // Start is called before the first frame update
    void Start()
    {
        // seperateWall = GameObject.Find("Seperate Wall").GetComponent<SeperateWall>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!finishAnim)
        {
            seperateWall.freezed = false;
        }
        // if (touched || touched2) {
        //     seperateWall.freezed = true;
        // }
        // if (!touched && !touched2) {
        //     seperateWall.freezed = false;
        // }

        // if (touched2) 
        // {
        //     seperateWall.freezed = true;
        //     Debug.Log("omri");
        // }
        // else
        // {
        //     seperateWall.freezed = false;
        // }



    }

    void OnTriggerEnter2D(Collider2D other) {
        // if (other.CompareTag("Player")) {
        //     touched = true;
        // }
        if (other.CompareTag("Player2")) {
            // touched2 = true;
            if (finishAnim)
            {
            seperateWall.freezed = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        // if (other.CompareTag("Player")) {
        //     touched = false;
        // }
        if (other.CompareTag("Player2")) {
            // touched2 = false;
            if (finishAnim)
            {
            seperateWall.freezed = false;;
            }
        }
    }
}
