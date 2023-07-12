using Assets.Scripts.Logs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Character
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterControler : MonoBehaviour
    {
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        [SerializeField] private float m_MoveSpeed = 0f;                    // The fastest the player can travel in the x axis.

        [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;            // Whether or not the player is grounded.
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody m_Rigidbody;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.

        private PlayerInput _PlayerInput;

        private Vector3 _Inputvalue;

        private Transform _Transform;

        private float horizontalInput;
        private float moveThreshold;


        private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody = GetComponent<Rigidbody>();
            _PlayerInput = GetComponent<PlayerInput>();
            _Transform = GetComponent<Transform>();
        }

        private void Start()
        {
            // just a cpu save for the FixedUpdate check to prevent floating precision issues
            moveThreshold = 0.95f * m_MoveSpeed;
        }


        private void Update()
        {
            _Inputvalue = _PlayerInput.actions["Move"].ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            // add force to movement
            if (_Inputvalue == Vector3.left)
            {
                LoggerFile.Instance.INFO_LINE("press left");
                if (m_Rigidbody.velocity.z > -moveThreshold) m_Rigidbody.AddForce(new Vector3(0, 0, -m_MoveSpeed - m_Rigidbody.velocity.z), ForceMode.VelocityChange);
            }
            else if (_Inputvalue == Vector3.right)
            {
                LoggerFile.Instance.INFO_LINE("press right");
                if (m_Rigidbody.velocity.z < moveThreshold) m_Rigidbody.AddForce(new Vector3(0, 0, m_MoveSpeed - m_Rigidbody.velocity.z), ForceMode.VelocityChange);
            }
            else {
                if (Mathf.Abs(m_Rigidbody.velocity.x) > 0) m_Rigidbody.AddForce(new Vector3(-m_Rigidbody.velocity.x, 0, 0), ForceMode.VelocityChange);
            }


            /* m_Grounded = false;

             // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
             // This can be done using layers instead but Sample Assets will not overwrite your project settings.
             Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
             for (int i = 0; i < colliders.Length; i++)
             {
                 if (colliders[i].gameObject != gameObject)
                     m_Grounded = true;
             }
             m_Anim.SetBool("Ground", m_Grounded);

             // Set the vertical animation
             m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);*/
        }


        /*public void Move(float move, bool crouch, bool jump)
        {
            // If crouching, check to see if the character can stand up
            if (!crouch && m_Anim.GetBool("Crouch"))
            {
                // If the character has a ceiling preventing them from standing up, keep them crouching
                if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
                {
                    crouch = true;
                }
            }

            // Set whether or not the character is crouching in the animator
            m_Anim.SetBool("Crouch", crouch);

            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {
                // Reduce the speed if crouching by the crouchSpeed multiplier
                move = (crouch ? move * m_CrouchSpeed : move);

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                m_Anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                m_Rigidbody.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody.velocity.y);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }
            // If the player should jump...
            if (m_Grounded && jump && m_Anim.GetBool("Ground"))
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Anim.SetBool("Ground", false);
                m_Rigidbody.AddForce(new Vector2(0f, m_JumpForce));
            }
        }*/


        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }


        public void Jump(InputAction.CallbackContext callbackContext) {
            //add jump force to player
            if (callbackContext.performed) {
                m_Rigidbody.AddForce(Vector3.up * m_JumpForce);
                LoggerFile.Instance.INFO_LINE("Salto Up press");
            }
        }

        /*public void MoveRight(InputAction.CallbackContext callbackContext)
        {

            float horizontalM = Input.GetAxis("Horizontal");
            LoggerFile.Instance.INFO_LINE("Mover Right press");

            //add move force to player
            if (callbackContext.performed)
            {
                m_Rigidbody.velocity = new Vector3(m_MaxSpeed, m_Rigidbody.velocity.y, m_Rigidbody.velocity.z);
                //m_Rigidbody.velocity = new Vector3(horizontalM * m_MaxSpeed, m_Rigidbody.velocity.z);
            }
        }*/

    }
}