using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class Bouncer : MonoBehaviour
{
    private Animator animator;
    public float bounceForce = 20f;
    public PlayerController playerController;
    public float startVelocityY;
    public bool touched = false;
            

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        startVelocityY = playerController.rb.velocity.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!touched && startVelocityY > 0) 
        {
            startVelocityY -= 0.01f;
            playerController.rb.velocity = new Vector2(playerController.rb.velocity.x, startVelocityY);
            if (startVelocityY < 1) 
            {
                touched = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            touched = true;
            // playerController.jumpState = playerController.jumpState.PrepareToJump;
            playerController.rb.velocity = new Vector2(playerController.rb.velocity.x, bounceForce);
            playerController.stopJump = false;
            animator.SetBool("Bounce", true);
        }

    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            touched = false;
            playerController.stopJump = true;
            // playerController.rb.velocity = new Vector2(playerController.rb.velocity.x, startVelocityY);
            animator.SetBool("Bounce", false);
        }

    }
}
