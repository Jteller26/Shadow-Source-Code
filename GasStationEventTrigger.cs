using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasStationEventTrigger : MonoBehaviour
{
    public bool triggered = false;
    
    void OnTriggerEnter(Collider other) {
        if (triggered == false) {
            if (other.tag == "Player") {
                triggered = true;
                this.GetComponent<GasStationLightFlicker>().trigger_flicker();
            }
        }
    }
}
