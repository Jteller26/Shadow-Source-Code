using UnityEngine;

namespace Items
{
    /**
 * This script allows activation of the car part's outline by changing the layer to the item layer via
 * the Activate() function.
 */
    public class CarPart : MonoBehaviour
    {
        public Transform model;

        public bool debugActivate = false;
    
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log(model.gameObject.layer);
        }

        // Update is called once per frame
        void Update()
        {
            if (debugActivate)
            {
                Activate();
                debugActivate = false;
            }
        }

        public void Activate()
        {
            model.gameObject.layer = 3;
        }
    }
}
