using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    /**
 * This script provides functionality for the Flashlight.
 *
 * Currently implemented features:
 *   Toggle flashlight on/off [see ToggleLight() function]
 *   Battery Level
 *     battery level reduces during use [batterDrain] 
 *     automatically turn off if battery empty
 *     prevent turning on if battery empty
 *     Add Battery functionality [see AddBattery() function]
 *
 * Future features:
 *   flicker effect activation when on low battery
 *   audio for low battery (buzzing?) activation during flicker
 *   audio for toggling flashlight activation
 *   
 */
    public class Flashlight : MonoBehaviour
    {
        public AudioSource onOffAudioSource;
        private GameObject _light;            // Child game object representing the light
        public static float batteryLevelMax = 100f;  // Maximum battery level
        public static float batteryDrain = 1f;      // Battery drain per second

        public Slider _batteryUISlider; //Slider for Battery UI
    
    
    
        public static float BatteryLevel => _batteryLevel;   // Public Read-only property
        private static float _batteryLevel;                  // Current battery level
    
        public bool isLightOn;                       // Current light state flag
        // changed the state to public so that I can access from another script
        // Start is called before the first frame update
        void Start()
        {
            // Getting spot light child object
            _light = transform.Find("Spot Light").gameObject;
        
            // Starting light state
            isLightOn = true;
        
            // Starting battery level
            _batteryLevel = batteryLevelMax;
        }

        // Update is called once per frame
        void Update()
        {
            // User input
            if (Input.GetButtonDown("Flashlight"))
            {
                // Update Light state
                ToggleLight();
            }

            // Actions to complete when light is on
            if (isLightOn)
            {
                // Battery drain over time during use
                _batteryLevel -= batteryDrain * Time.deltaTime;
                if (_batteryLevel <= 0f)
                {
                    // Removing negative battery
                    _batteryLevel = 0f;
                
                    //TODO activate audio of flashlight running out of battery
                    //TODO activate flicker effect
                
                    // Turning light off
                    ToggleLight();
                }
            }

            _batteryUISlider.value = _batteryLevel/batteryLevelMax * _batteryUISlider.maxValue; //update UI

            /*/ ** Debug ********************

        if (Input.GetButtonDown("ReadNote"))
        {
            AddBattery(25f);
        }
        
        print(_batteryLevel);
        // */       
        }

        /**
     *  Toggles the light state between on and off. Can only turn on if battery level is
     *  greater than zero.
     */
        private void ToggleLight()
        {
            // Can't turn on if no battery
            if (!isLightOn && _batteryLevel <= 0) { return; }
        
            // Toggle light state flag
            isLightOn = !isLightOn;
        
            // Setting new light state
            _light.SetActive(isLightOn);
        
            // Activating audio of flashlight turning on/off
            onOffAudioSource.Play();
        }

        /**
     * Adds to the battery level of the flashlight.
     * <param name="percent">The percentage of battery level to add (i.e. 10, 25, 100, etc.) </param>
     */
        public static void AddBattery(float percent)
        {
            var amount = percent/100f * batteryLevelMax;
            _batteryLevel = (_batteryLevel + amount > batteryLevelMax) ? batteryLevelMax : _batteryLevel + amount;
        }
    }
}
