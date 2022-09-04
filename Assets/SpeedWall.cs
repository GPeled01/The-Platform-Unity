using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedWall : MonoBehaviour
{
    public SeperateWall seperateWall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player2")) {
            seperateWall.speedLevel2 = 0.01f;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player2")) {
            seperateWall.speedLevel2 = 0.003f;
        }
    }
}
