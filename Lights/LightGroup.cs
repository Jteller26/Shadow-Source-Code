using System.Collections.Generic;
using UnityEngine;

namespace Lights
{
    /**
 * This script is meant to control the activation of a group of lights simultaneously.
 * For instance, when the player crosses a certain point (designated by a trigger in the
 * prefab), a set of lights will illuminate at once. The trigger has a specific script,
 * LightGroupTrigger.cs that will activate this script. It was done in this manner to
 * simplify placing of triggers as a child object in the LightGroup object.
 *
 * When Activate() is called, it will activate all child lights containing the script
 * LampLight.cs.
 */
    public class LightGroup : MonoBehaviour
    {
        public bool debugeActivate = false;
        private bool wasActivated; // to prevent reactivation with trigger after activated

        private List<LampLight> children;

        // Start is called before the first frame update
        void Start()
        {
            // Getting a list of child lights
            children = new List<LampLight>();
            foreach (Transform child in transform)
            {
                LampLight script = child.GetComponent<LampLight>();
            
                if (script != null) // ignore in case of child object without LampLight script
                {
                    children.Add(script);
                }
            }
        
        }

        // for debugging/testing
        void Update()
        {
            if (debugeActivate)
            {
                Activate();
                debugeActivate = false;
            }
        }

        /**
     * Activates child lights
     */
        public void Activate()
        {
            foreach (LampLight child in children)
            {
                child.ActivateLight();
            }
        }
    }
}

