using UnityEngine;
using UnityEngine.UI;

namespace UILogic
{
    public class BatteryUIController : MonoBehaviour
    {
        public Slider batteryLevel;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        void Update() {
            //sync battery here
        }

        public void setBatteryDisplay(int level) {
            if (level < 15) {
                batteryLevel.value = level;
            }
        }


    }
}
