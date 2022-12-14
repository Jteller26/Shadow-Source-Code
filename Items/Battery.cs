using Player;
using UnityEngine;

namespace Items
{
    public class Battery : MonoBehaviour
    {
        public float batteryValue = 50;
        public AudioSource audioSource;
        private bool _isPlayingAudio = false;
    
        private void Update()
        {
            if (_isPlayingAudio == true && !audioSource.isPlaying)
            {
                Destroy(transform.gameObject);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!_isPlayingAudio)
            {
                Flashlight.AddBattery(batteryValue);
                audioSource.Play();
                _isPlayingAudio = true;
            }
        
        }
    }
}
