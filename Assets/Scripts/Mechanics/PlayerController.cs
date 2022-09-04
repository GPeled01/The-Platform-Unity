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
    public class PlayerController : KinematicObject
    {
        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;
        private SeperateWall seperateWall;
        public bool checkText = false;
        // private Transform transform;


        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float maxSpeed = 7;
        /// <summary>
        /// Initial jump velocity at the start of a jump.
        /// </summary>
        public float jumpTakeOffSpeed = 7;

        public JumpState jumpState = JumpState.Grounded;
        public bool stopJump;
        /*internal new*/ public Collider2D collider2d;
        /*internal new*/ public AudioSource audioSource;
        public Health health;
        public bool controlEnabled = true;

        bool jump;
        Vector2 move;
        SpriteRenderer spriteRenderer;
        // internal Animator animator;
        public Animator player1;
        public Animator player2;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Bounds Bounds => collider2d.bounds;

        // public GameObject slot1;

        public Rigidbody2D rb;
        public Bouncer bouncer;
        public float startVelocityY;
        public GameObject textBubble;
        public GameObject playerText;
        public TMP_Text newPlayerText;
        public bool firstText1 = true;
        public bool firstText2 = true;
        public bool firstText3 = true;
        public bool firstText4 = true;
        public OpenBlueLaser laser1;
        public PauseScreen pauseScreen;
        void Awake()
        {
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            // animator = GetComponent<Animator>();
            // slot1 = GameObject.FindWithTag("slot1");
            bouncer = GameObject.Find("Bouncer").GetComponent<Bouncer>();
            seperateWall = GameObject.Find("Seperate Wall").GetComponent<SeperateWall>();
            startVelocityY = rb.velocity.y;
            // transform = GameObject.Find("Player).transform;
            newPlayerText = playerText.GetComponent<TMP_Text>();
            StartCoroutine(waitTextBegin());
        }

        IEnumerator waitTextBegin()
        {
            yield return new WaitForSeconds(1);
            activateText("You go left, I go right!", 2);
        }

        protected override void Update()
        {
            if (Input.GetKeyDown(KeyCode.P)) {
                controlEnabled = !controlEnabled;
                // slot1.SetActive(controlEnabled);
            }
            if (Input.GetKeyDown(KeyCode.O)) 
            {
                pauseScreen.Setup();
            }

            if (Input.GetKeyDown(KeyCode.T)) 
            {
                seperateWall.stopped = !seperateWall.stopped;
            }


            if (controlEnabled)
            {
                if (Input.GetButton("Horizontal"))
                {
                    player1.SetBool("isWalk", true);
                }
                else
                {
                    player1.SetBool("isWalk", false);
                }
                move.x = Input.GetAxis("Horizontal");
                if ((jumpState == JumpState.Grounded && Input.GetButtonDown("Jump")) || bouncer.touched)
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

            if (!laser1.collider.enabled && firstText1)
            {
                activateText("Thank you bitch!", 3);
                firstText1 = false;
                StartCoroutine(waitForText());
            }
        }

        IEnumerator waitForText()
        {
            yield return new WaitForSeconds(3);
            checkText = true;
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

            if (other.CompareTag("Bouncer"))
            {
                activateText("AHHHHHH!", 1);
            }
            

            if (other.gameObject.name == "simple platform (52)" && firstText2)
            {
                activateText("Help me you idiot!", 3);
                firstText2 = false;
            }


            if (other.gameObject.name == "simple platform (62)" && firstText3)
            {
                activateText("Finally!", 3);
                firstText3 = false;
            }
            if (other.gameObject.name == "simple platform (93)" && firstText4)
            {
                activateText("Hurry the fuck up!", 3);
                firstText4 = false;
            }
            


            // if(other.CompareTag("platformbitch") && firstText1)
            // {
            //     activateText();
            //     changeTextBubble("Shut up you bitch!");
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