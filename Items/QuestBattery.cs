using Player;
using UnityEngine;

public class QuestBattery : MonoBehaviour
{
    public float batteryValue = 50;
    public AudioSource audioSource;
    private GameObject activeQuests;
    public GameObject lightFlickerTrigger;
    private bool _isPlayingAudio = false;

    private void Start() {
        activeQuests = GameObject.Find("Active Quests");
    }
    private void Update()
    {
        if (_isPlayingAudio == true && !audioSource.isPlaying)
        {
            activeQuests.GetComponent<ActiveQuests>().completeQuest(1);
            lightFlickerTrigger.GetComponent<GasStationLightFlicker>().trigger_flicker();
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
