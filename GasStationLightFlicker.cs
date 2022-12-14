using System.Collections;
using System.Collections.Generic;
using Lights;
using UnityEngine;

public class GasStationLightFlicker : MonoBehaviour
{
    private GameObject normal_lights;
    private GameObject emergency_lights;
    private LightFlicker[] normal_lights_arr;
    private Light[] emer_lights_arr;
    public bool activated = false;
    public float length;
    public float timer = 0;

    private void Start() {
        normal_lights = GameObject.Find("Normal Lights");
        emergency_lights = GameObject.Find("Emergency Lights");
        normal_lights_arr = normal_lights.GetComponentsInChildren<LightFlicker>();
        emer_lights_arr = emergency_lights.GetComponentsInChildren<Light>();
    }

    private void Update() {
        if (activated) {
            if (timer < length)
                timer += Time.deltaTime;
            else {
                off_all();
                this.gameObject.SetActive(false);
            }
        }
    }

    public void trigger_flicker() {
        if (activated == false) {
            activated = true;
            activate_flicker();
        }
    }

    private void activate_flicker() {
        foreach (LightFlicker light in normal_lights_arr ) {
            light.flickerNow();
        }
    }

    private void off_all() {
        normal_lights.SetActive(false);
        foreach (Light light in emer_lights_arr) {
            light.enabled = true;
        }
        emergency_lights.GetComponent<AudioSource>().Play();
    }
}
