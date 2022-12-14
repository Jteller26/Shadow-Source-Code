using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class CarPartPickup : MonoBehaviour
{
    public AudioSource audioSource;
    public int quest_id;
    private GameObject activeQuest;
    private bool _isPlayingAudio = false;
    
    private void Start() {
        activeQuest = GameObject.Find("Active Quests");
    }
    private void Update()
    {
        if (_isPlayingAudio == true && !audioSource.isPlaying)
        {
            activeQuest.GetComponent<ActiveQuests>().completeQuest(quest_id);
            Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isPlayingAudio)
        {
            audioSource.Play();
            _isPlayingAudio = true;
        }
    }
}
