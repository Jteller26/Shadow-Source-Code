using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject activeQuests;
    public string questDescription;
    public int questID;
    private bool used = false;

    public GameObject questItem;

    private void Start() {
        activeQuests = GameObject.Find("Active Quests");
    }

    private void OnTriggerEnter(Collider other) {
        if (used == false) {
            if (other.tag == "Player") {
                activeQuests.GetComponent<ActiveQuests>().addQuest(questDescription, questID);
                used = true;
                if (questItem != null) {
                    questItem.SetActive(true);
                }
            }
        }
    }
}
