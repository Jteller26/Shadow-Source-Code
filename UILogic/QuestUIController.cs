using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUIController : MonoBehaviour
{
    public TextMeshProUGUI questText;
    public int questID;
    public void MarkCompleted() {
        questText.fontStyle |= FontStyles.Strikethrough;
        GetComponent<Image>().color = new Color32(29, 241, 56, 31);
    }

    void SetText(string text) {
        questText.SetText(text);
    }

    public void newQuest(string text, int id) {
        if((questText.fontStyle & FontStyles.Underline) != 0) {
            questText.fontStyle ^= FontStyles.Underline;
        }
        questID = id;
        SetText(text);
    }


}
