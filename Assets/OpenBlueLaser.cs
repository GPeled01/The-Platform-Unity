using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBlueLaser : MonoBehaviour
{

    // private bool touched = false;
    // private bool touched2 = false;
    public Animator animator;
    public GameObject blueLaser;
    public PolygonCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        // animator = GameObject.Find("Blue Laser");
        collider = blueLaser.GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            animator.SetBool("laserIsOff", true);
            collider.enabled = false;
        }
        else if (other.CompareTag("Player2")) {
            animator.SetBool("laserIsOff", true);
            collider.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            animator.SetBool("laserIsOff", false);
            collider.enabled = true;
        }
        else if (other.CompareTag("Player2")) {
            animator.SetBool("laserIsOff", false);
            collider.enabled = true;
        }
    }
}
