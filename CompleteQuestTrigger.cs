using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteQuestTrigger : MonoBehaviour
{
    private GameObject activeQuests;
    public int questID;
    private bool used = false;

    private void Start() {
        activeQuests = GameObject.Find("Active Quests");
    }

    private void OnTriggerEnter(Collider other) {
        if (used == false) {
            if (other.tag == "Player") {
                activeQuests.GetComponent<ActiveQuests>().completeQuest(questID);
                used = true;
            }
        }
    }
}
