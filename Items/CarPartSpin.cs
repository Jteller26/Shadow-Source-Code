using UnityEngine;

namespace Items
{
    public class CarPartSpin : MonoBehaviour
    {
        public float spinSpeed = 90;
        public Transform carPart;

        private void Start()
        {
            carPart = transform;
        }

        // Update is called once per frame
        void Update()
        {
            carPart.Rotate(Vector3.up, spinSpeed * Time.deltaTime);    
        }
    }
}
