// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class AnimationMove : MonoBehaviour
// {
    
//     public float MovementSpeed = 4;
//     public float JumpForce = 10;

//     private Rigidbody2D _rigidbody;
//     public Animator player1;

//     // Start is called before the first frame update
//     void Start()
//     {
//         _rigidbody = GetComponent<Rigidbody2D>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         var movement = Input.GetAxis("Horizontal");
//         transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

//         if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.1f)
//         {
//             _rigidbody.AddForce(new Vector2(0,JumpForce), ForceMode2D.Impulse);
//         }

//         if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
//             {
//                 Debug.Log("hello");
//                 player1.SetBool("isWalk", true);
//             }
//     }

    
// }
