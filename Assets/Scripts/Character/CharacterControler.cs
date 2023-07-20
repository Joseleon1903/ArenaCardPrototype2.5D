using Assets.Scripts.Logs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Character
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterControler : MonoBehaviour
    {
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        [SerializeField] private float m_MoveSpeed = 0f;                    // The fastest the player can travel in the x axis.

        private Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody m_Rigidbody;

        private PlayerInput _PlayerInput;

        private Vector3 _Inputvalue;
        private float moveThreshold;
        private Transform _Transform;

        // ground check validate for prevent double jump 
        private float raycastDistance = 1.0f;
        public LayerMask groundLayer;

        public bool isGrounded;



        private void Awake()
        {
            // Setting up references.
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
            // ground check 
            GroundCheck();

            // add force to movement
            if (_Inputvalue == Vector3.left)
            {
                LoggerFile.Instance.INFO_LINE("press left");
                if (m_Rigidbody.velocity.z > -moveThreshold) m_Rigidbody.AddForce(new Vector3(0, 0, -m_MoveSpeed - m_Rigidbody.velocity.z), ForceMode.VelocityChange);
                transform.LookAt(transform.position + Vector3.back);
            }
            else if (_Inputvalue == Vector3.right)
            {
                LoggerFile.Instance.INFO_LINE("press right");
                if (m_Rigidbody.velocity.z < moveThreshold) m_Rigidbody.AddForce(new Vector3(0, 0, m_MoveSpeed - m_Rigidbody.velocity.z), ForceMode.VelocityChange);
                transform.LookAt(transform.position + Vector3.forward);
            }
            else {
                if (Mathf.Abs(m_Rigidbody.velocity.x) > 0) m_Rigidbody.AddForce(new Vector3(-m_Rigidbody.velocity.x, 0, 0), ForceMode.VelocityChange);
            }
/*
            if (_Transform.position.x != 0) {
                _Transform.position = new Vector3(Vector3.zero.x, _Transform.position.y, _Transform.position.z);
            }*/


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

        public void FlipHorizontally()
        {
            Vector3 newScale = _Transform.localScale;
            newScale.x *= -1; // Flip the object's scale on the x-axis
            _Transform.localScale = newScale;
        }


        public void Jump(InputAction.CallbackContext callbackContext) {
            //add jump force to player
            if (callbackContext.performed && isGrounded) {
                m_Rigidbody.AddForce(Vector3.up * m_JumpForce);
                LoggerFile.Instance.INFO_LINE("Salto Up press");
            }
        }


        public void GroundCheck() {
            RaycastHit hit;
            isGrounded = Physics.Raycast(_Transform.position, Vector3.down, out hit, raycastDistance, groundLayer);

            // Opcional: Dibuja el rayo en el editor para depurar
            Debug.DrawRay(_Transform.position, Vector3.down * raycastDistance, Color.red);

            // Ejemplo de cómo usar la variable "isGrounded"
            if (isGrounded)
            {
                // El objeto está tocando el suelo, puedes realizar acciones específicas aquí
                isGrounded = true;
            }
            else
            {
                // El objeto no está tocando el suelo, puedes realizar otras acciones aquí
                isGrounded = false;
            }
        }

    }
}