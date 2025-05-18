using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        public Transform m_Cam;                  // A reference to the main camera in the scenes transform

        [SerializeField]
        Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        public bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
        
        [SerializeField] private float m_SprintMultiplier = 40f; 
        private float m_MoveSpeedMultiplier = 1f;
        public bool outOfZone = false;


        private void Start()
        {

            //Set Cursor to not be visible
            Cursor.visible = false;

            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
              /*  Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them! */
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();
        }

        void OnApplicationFocus(bool status)
	{
		if (status)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}

        private void Update()
        {
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
            
            if (Input.GetKey(KeyCode.Q))
            {
                m_MoveSpeedMultiplier = m_SprintMultiplier;
            }
            else
            {
                m_MoveSpeedMultiplier = 1f;
            }

        }

        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            // read inputs
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            bool crouch = Input.GetKey(KeyCode.C);

            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3((1), 0, (1))).normalized;
                m_Move = v * m_CamForward + h * m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v * Vector3.forward + h * Vector3.right;
            }
#if !MOBILE_INPUT
            // walk speed multiplier
            if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.9f;
#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;

            //Debug.Log("Final Move Speed: " + m_Move * m_MoveSpeedMultiplier);
        }

        
    // public void OnTriggerEnter(Collider other)
    // {
    //     string newArea = "";

    //     // Area Detection
    //     Debug.Log("Triggered by: " + other.gameObject.name); 

    //     if (other.CompareTag("Forest"))
    //     {
    //         Debug.Log("Forest trigger");
    //         newArea = "Forest";
    //         //SoundManager.Instance.currentArea = "Forest";
    //         //SoundManager.Instance.PlayAreaSound();
    //     }

    //     else if (other.CompareTag("Exploration"))
    //     {
    //         Debug.Log("Exploration trigger");
    //         newArea = "Exploration";
    //         // SoundManager.Instance.currentArea = "Exploration";
    //         // SoundManager.Instance.PlayAreaSound();
    //     }

    //     else if (other.CompareTag("Untagged") || other.CompareTag("Dirt") )
    //     {
    //         outOfZone = true;
    //         newArea = "";
    //         Debug.Log("Player is out of Zone");
    //         return;
    //     }

    //     if (newArea != SoundManager.Instance.currentArea)
    //     {
    //         Debug.Log($"New Area: " + newArea + " - Current Area: " + SoundManager.Instance.currentArea);
    //         SoundManager.Instance.currentArea = newArea;
    //         Debug.Log($"2 New Area: " + newArea + " - 2 Current Area: " + SoundManager.Instance.currentArea);

    //     }

        
    // }
    }
}
