using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportLevel2Left : MonoBehaviour
{
    private Transform transformPlayer2;
    public Animator teleport;

    // Start is called before the first frame update
    void Start()
    {   
        transformPlayer2 = GameObject.Find("Player2").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player2")) {
            teleport.SetBool("isTeleport", true);
            StartCoroutine(wait());
        }
    }

    void OnTriggerExit2D(Collider2D other) {
            teleport.SetBool("isTeleport", false);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.1f);
        transformPlayer2.position = new Vector2(-18f, 26f);
    }
}
