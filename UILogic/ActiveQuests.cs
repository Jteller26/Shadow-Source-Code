using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveQuests : MonoBehaviour
{
    public GameObject UIprefab;
    public List<GameObject> quests;
    Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        origin = new Vector3(267f, 130f, 0f);
        quests = new List<GameObject>();
    }

    private GameObject createQuest(string description, int id) {
        GameObject newUI = Instantiate(UIprefab, origin, Quaternion.identity);
        newUI.GetComponent<QuestUIController>().newQuest(description, id);
        newUI.transform.SetParent(this.gameObject.transform, false);
        return newUI;
    }

    public void addQuest(string description, int id) {
        quests.Add(createQuest(description, id));
        refreshUI();
    }

    public void completeQuest(int id) {
        StartCoroutine(completeQuestHelper(id));
    }

    IEnumerator completeQuestHelper(int id) {
        for (int i = 0; i < quests.Count; i++) {
            GameObject quest = quests[i];
            if (quest.GetComponent<QuestUIController>().questID.Equals(id)) {
                quests.RemoveAt(i);
                quest.GetComponent<QuestUIController>().MarkCompleted();
                yield return new WaitForSeconds(3);
                Destroy(quest);
                refreshUI();
                break;
            }
        }
    }

    private void refreshUI() {
        float y_offset = -40;
        for (int i = 0; i < quests.Count; i++) {
            GameObject quest = quests[i];
            quest.GetComponent<RectTransform>().anchoredPosition = origin + new Vector3(0,y_offset,0) * i;
        }
    }
    
}
