using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Character
{

    [RequireComponent(typeof(CharacterControler))]
    public class PlatformerUserControl : MonoBehaviour
    {
        private CharacterControler m_Character;
        private bool m_Jump;

        private Vector2 movementInput;


        private void Awake()
        {
            m_Character = GetComponent<CharacterControler>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                //m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
           // float horizontalM = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
          //  m_Character.Move(horizontalM, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
