using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRedPlatformLevel2 : MonoBehaviour
{
    // private SeperateWall seperateWall;
    public Animator redPlatform;
    public StopWall stopWall;
    // Start is called before the first frame update
    void Start()
    {
        // seperateWall = GameObject.Find("Seperate Wall").GetComponent<SeperateWall>();
    }

    // Update is called once per frame
    void Update()
    {
        if (redPlatform.GetCurrentAnimatorStateInfo(0).IsName("greyPlatformStatic"))
        {
            stopWall.finishAnim = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player2")) {
            // seperateWall.freezed = true;
            redPlatform.SetBool("stopWall", true);
            redPlatform.speed = 1;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player2")) {
            // seperateWall.freezed = false;
            redPlatform.speed = 0;
        }
    }
}
