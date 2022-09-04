using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportLevel2Right : MonoBehaviour
{
    private Transform transformPlayer1;
    public Animator teleport;

    // Start is called before the first frame update
    void Start()
    {
        transformPlayer1 = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
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
        transformPlayer1.position = new Vector2(21.25f, 28.5f);
    }
}
