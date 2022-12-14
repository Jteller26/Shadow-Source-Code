using UnityEngine;

namespace Player
{
    public class CharacterLook : MonoBehaviour
    {
        public float mouseSensitivity;
        public Transform player;
        private float xMax = 0f;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }


        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xMax -= mouseY;
            xMax = Mathf.Clamp(xMax, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xMax, 0f, 0f);
            player.Rotate(Vector3.up * mouseX);
        }
    }
}
