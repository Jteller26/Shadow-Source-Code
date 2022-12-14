using UnityEngine;

namespace Lights
{
    /**
 * Simple script to act as a one-time-only trigger. When triggered will call
 * LightGroup.Activate() method in parent object.
 */
    public class LightGroupTrigger : MonoBehaviour
    {
        private bool _wasTriggered = false;
        public void OnTriggerEnter(Collider other)
        {
            if (!_wasTriggered)
            {
                transform.parent.gameObject.GetComponent<LightGroup>().Activate();
            
                // so it's only triggered once
                _wasTriggered = true;
            }
        }
    }
}
