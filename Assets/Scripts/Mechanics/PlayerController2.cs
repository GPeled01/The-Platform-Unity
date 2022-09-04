using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;
using UnityEngine.Serialization;
using Cinemachine;
using TMPro;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class PlayerController2 : KinematicObject
    {
        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;


        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float maxSpeed = 7;
        /// <summary>
        /// Initial jump velocity at the start of a jump.
        /// </summary>
        public float jumpTakeOffSpeed = 7;

        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        /*internal new*/ public Collider2D collider2d;
        /*internal new*/ public AudioSource audioSource;
        public Health health;
        public bool controlEnabled = false;

        bool jump;
        Vector2 move;
        SpriteRenderer spriteRenderer;
        // internal Animator animator;
        public Animator player2;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Bounds Bounds => collider2d.bounds;

        // public GameObject slot2;

        SpriteRenderer rend;
        public float startVelocityY;
        public Rigidbody2D rb;
        public GameObject textBubble;
        public GameObject playerText;
        public TMP_Text newPlayerText;
        public bool firstText1 = true;
        public bool firstText2 = true;
        public bool firstText3 = true;
        public PlayerController playerController;
        // public PauseScreen pauseScreen;
        void Awake()
        {
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            // animator = GetComponent<Animator>();
            // slot2 = GameObject.FindWithTag("slot2");
            // slot2.SetActive(false);
            startVelocityY = rb.velocity.y;
            newPlayerText = playerText.GetComponent<TMP_Text>();
            StartCoroutine(waitTextBegin());
        }

        IEnumerator waitTextBegin()
        {
            yield return new WaitForSeconds(3);
            activateText("Don't give me orders!", 2);
        }

        protected override void Update()
        {
            if (playerController.checkText)
            {
                playerController.checkText = false;
                activateText("Shut up scumbag!", 3);
                // firstText1 = false;
            }

            if (Input.GetKeyDown(KeyCode.P)) {
                controlEnabled = !controlEnabled;
                //GameObject.Find("Slot (1)").renderer.material.color = Color (1,1,1,0.5);
                // slot2.SetActive(controlEnabled);
            }
            // if (Input.GetKeyDown(KeyCode.O)) 
            // {
            //     pauseScreen.Setup();
            // }


            if (controlEnabled)
            {
                if (Input.GetButton("Horizontal"))
                {
                    player2.SetBool("isWalk2", true);
                    if (Input.GetButton("Jump")) 
                    {
                        player2.SetBool("isJump2", true);
                    }
                    else 
                    {
                        player2.SetBool("isJump2", false);
                    }
                }
                else
                {
                    player2.SetBool("isWalk2", false);
                }

                move.x = Input.GetAxis("Horizontal");
                if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
                    jumpState = JumpState.PrepareToJump;
                else if (Input.GetButtonUp("Jump"))
                {
                    stopJump = true;
                    //Schedule<PlayerStopJump>().player = this;
                }
            }
            else
            {
                move.x = 0;
            }
            UpdateJumpState();
            base.Update();
        }

        void UpdateJumpState()
        {
            jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    jump = true;
                    stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        //Schedule<PlayerJumped>().player = this;
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        //Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
            }
        }

        protected override void ComputeVelocity()
        {
            if (jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed * model.jumpModifier;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * model.jumpDeceleration;
                }
            }

            if (move.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = true;

            // animator.SetBool("grounded", IsGrounded);
            // animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
        }
        
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.CompareTag("platform"))
            {
                // touched = true;
                rb.velocity = new Vector2(rb.velocity.x, startVelocityY);
                stopJump = true;
                // animator.SetTrigger("Bounce");
            }

            // if (other.gameObject.name == "simple platform (41)" && firstText1 && !playerController.firstText1)
            // {
            //     activateText("Shut up scumbag!", 3);
            //     firstText1 = false;
            // }


            if (other.gameObject.name == "Teleport1" && firstText2)
            {
                activateText("WTF?", 1);
                firstText2 = false;
            }


            if (other.gameObject.name == "simple platform (43)" && firstText3)
            {
                activateText("I'm so frustrated!", 3);
                firstText3 = false;
            }
            


            // if(other.gameObject.name == "simple platform (4)" && firstText1)
            // {
            //     activateText("Shut up scumbag!");
            //     firstText1 = false;
            // }

        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }

        public void activateText(string txt, int sec)
        {
            textBubble.SetActive(true);
            changeTextBubble(txt);
            StartCoroutine(waitText(sec));
            // yield return new WaitForSeconds(5);
        }

        IEnumerator waitText(int sec)
        {
            yield return new WaitForSeconds(sec);
            textBubble.SetActive(false);
        }

        public void changeTextBubble(string txt)
        {
            newPlayerText.text = txt;
        }
    }
}