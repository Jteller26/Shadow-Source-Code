using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Lights
{
    /**
 * This script provides functionality for environmental lighting.
 *
 * Light stays on until triggered [via TriggerLight() function] then stays on for
 * an amount of seconds [ timeUntilOff ]. At low light [ lowLightTime ], flickers
 * before turning off. The light can be initialized [via InitializeLight function].
 * If initialized with a lowLightTime longer than timeUntilOff, it will flicker
 * even prior to triggering.
 * 
 * Light can be activated (turned on via script) with the Activate() function. This
 * uses either the default values for timeUntilOff and lowLightTime in this script
 * or the values in the inspector, if set.
 * 
 */
    public class LampLight : MonoBehaviour
    {
        public EnemyScript monster;
        public Collider lightCollider; 
        
        private GameObject _light; // Child game object representing the light
        private Light _lightBulb;  // The Light component of the child object
        public AudioSource audioSource;
        private float _intensity;  // default intensity of light
        private bool isLightOn;    // Current light state flag
    
        public float timeUntilOff = 10f;            // Number of seconds until light goes out (once triggered)
        public float lowLightTime = 2f;             // Number of seconds at "low light" state
        public float flickerIntervalMax = 0.4f;     // Maximum flicker interval in seconds
        public float flickerIntervalMin = 0.1f;     // Minimum flicker interval in seconds
        public float flickerIntensityFactor = 0.25f; // Amount of maximum proportional decrease in intensity
    
        private float _timer;     // current timer until off
        public bool hasTriggered; // has timer been triggered by player
    
        private float _flickerTimer;    // time since last flicker
        private float _flickerInterval; // current flicker interval (randomized)
        private bool _isFlickering;     // is light currently flickering
    
        
        
        // Start is called before the first frame update
        void Start()
        {
            // Getting spot light child object
            _light = transform.Find("Spot Light").gameObject;
            _lightBulb = _light.GetComponent<Light>();
            _intensity = _lightBulb.intensity;
        
            isLightOn = false;
            _light.SetActive(false);
        
            // Initializing flicker timer
            _flickerTimer = flickerIntervalMax;
            _flickerInterval = flickerIntervalMax;
        }

        // Update is called once per frame
        void Update()
        {
            // If timer is done or light is off, return
            if (_timer <= 0 || !isLightOn) return;
        
        
            if (!hasTriggered)
            {
                if (lowLightTime > timeUntilOff) // Special case to cause constant flickering without trigger
                {
                    // Flicker without updating main timer
                    Flicker(Time.deltaTime);
                }
                return;
            }
        
            // Saving delta time
            var deltaTime = Time.deltaTime;

            // Decrement timer
            _timer -= deltaTime;

            // If timer is not in low light time, exit
            if (!(_timer <= lowLightTime)) return;
        
            // If timer is done, deactivate light
            if (_timer <= 0)
            {
                ToggleLight();
                //_light.SetActive(false); 
                audioSource.Stop();
                return;
            }
        
            // Flicker when in low light time and still on
            Flicker(deltaTime);
        }

        private void Flicker(float deltaTime)
        {
            // Update flicker timer
            _flickerTimer += deltaTime;

            // If flicker timer not done
            if (!(_flickerTimer >= _flickerInterval)) return;
            
            // Resetting flicker timer
            _flickerTimer = 0;
            
            // Flipping flag
            _isFlickering = !_isFlickering;

            // If not flickering, restoring intensity
            if (!_isFlickering)
            {
                _lightBulb.intensity = _intensity;
                return;
            }

            // activate audio of light flickering
            audioSource.Play();
            
            // Randomizing next flicker interval
            _flickerInterval = Random.Range(flickerIntervalMin, flickerIntervalMax);
                
            // Adjusting intensity to a random value
            _lightBulb.intensity = _intensity * (Random.value * flickerIntensityFactor);
        }
    
        /**
     *  Toggles the light state between on and off. For external manual activation. 
     */
        public void ToggleLight()
        {
            // Toggle light state flag
            isLightOn = !isLightOn;
        
            // Setting new light state
            _light.SetActive(isLightOn);
            lightCollider.enabled = isLightOn;
            if (monster != null)
            {
                //this might be causing the error
                monster.startTheMonster(); 
            }
            
            // monster continues attack once light dies
            print("light is turned off and he is coming");
        }

        /** Initialized on with default deactivation times **/
        public void ActivateLight()
        {
            InitializeLight(true, timeUntilOff, lowLightTime);
        }
    
        /**
     * Initializes the light in the given state with customizable time until off and flicker time.
     * <param name="onOffState">true if light is on; false if light is off</param>
     * <param name="timeUntilLightOff">number of seconds light remains on after triggered</param>
     * <param name="timeFlickering">number of seconds light is in flicker state before turning off. If
     * greater than timeUntilOff, then will flicker even when not triggered.</param>
     */
        private void InitializeLight(bool onOffState, float timeUntilLightOff, float timeFlickering)
        {
            // Updating values
            isLightOn = onOffState;
            this.lowLightTime = timeFlickering;
            this.timeUntilOff = timeUntilLightOff;
        
            // Setting timer
            _timer = timeUntilLightOff;
        
            // Updating flags
            hasTriggered = false;
            _isFlickering = false;
        
            // Setting light state
            _light.SetActive(isLightOn);
        
        }

        /**
     * Flips the triggered flag.
     */
        public void TriggerLight()
        {
            hasTriggered = true;
        }

        private void OnTriggerEnter(Collider objectCollidingWith)
        {
            if (objectCollidingWith.name == "Player" && monster != null)
            {
                print("monster is stopped");
                monster.stopTheMonster();
                
                //                                                                                                                                                                     print("you have walked into the light");
            }
            // check if player is in the light here
            // check if light is still on
            // stop the monster
            hasTriggered = true;
        }

        private void OnTriggerExit(Collider objectCollidingWith)
        // must check when light is turned off
        {
            if (objectCollidingWith.name == "Player" && monster != null)
            {
                print("lamp light died.");
                monster.startTheMonster();
                //print("monster is moving");
            }
        }
    }
}
