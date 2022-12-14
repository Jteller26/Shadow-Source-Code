using UnityEngine;

namespace Player
{
    public class CharacterMovement : MonoBehaviour
    {
        public CharacterController controller;

        public float speed;
        public float gravity;
        public float jumpHeight;
        private float sprint;

        public Transform ground;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;

        private Vector3 velocity;
        private bool isGrounded;
        private SprintStamina stamina;
        private float takeStamina = .15f;
        public AudioSource JumpAudioSource;
        public AudioSource WalkAudioSource;
        public AudioSource RunAudioSource;
        public AudioSource BreathingAudio;
        public AudioSource runBreathingAudio;
    
        void Start()
        {
            stamina = GetComponent<SprintStamina>();
        }


        void Update()
        {
            BreathingAudio.enabled = true;
            isGrounded = Physics.CheckSphere(ground.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
        
            if (Input.GetKey(KeyCode.LeftShift) && stamina.currentStamina >= 0f)
            {
                sprint = speed / .60f;
                stamina.DownStamina(takeStamina);
            }
            else
            {
                sprint = speed;
            }
        
            float xMove = Input.GetAxis("Horizontal");
            float zMove = Input.GetAxis("Vertical");

            Vector3 move = (transform.right * xMove + transform.forward * zMove).normalized;
            controller.Move(move * speed * sprint * Time.deltaTime);
            
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    WalkAudioSource.enabled = false;
                    RunAudioSource.enabled = true;
                    BreathingAudio.enabled = false;
                    runBreathingAudio.enabled = true;
                }
                else
                {
                    BreathingAudio.enabled = true;
                    WalkAudioSource.enabled = true;
                    RunAudioSource.enabled = false;
                    runBreathingAudio.enabled = false;
                }
            }
            else
            {
                BreathingAudio.enabled = true;
                WalkAudioSource.enabled = false;
                RunAudioSource.enabled = false;
                runBreathingAudio.enabled = false;
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                JumpAudioSource.Play();
            }
        
        
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    
    }
}
