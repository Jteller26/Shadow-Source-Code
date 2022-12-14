using System.Collections;
using UnityEngine;

namespace Lights
{
    public class LightFlicker : MonoBehaviour
    {
        public bool isFlickering = false;
        public float timeDelay;

        public bool on = false;

        private void Update() {
            if (isFlickering == false && on == true) {
                StartCoroutine(flicker());
            }
        }

        public void flickerNow() {
            on = true;
        }
        IEnumerator flicker() {
            isFlickering = true;
            this.gameObject.GetComponent<Light>().enabled = false;
            GetComponent<AudioSource>().Play();
            timeDelay = Random.Range(0.3f, 0.5f);
            yield return new WaitForSeconds(timeDelay);
            this.gameObject.GetComponent<Light>().enabled = true;
            timeDelay = Random.Range(0.3f, 0.5f);
            yield return new WaitForSeconds(timeDelay);
            isFlickering = false;
        }
    }
}
