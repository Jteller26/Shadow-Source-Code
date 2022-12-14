using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesRead : MonoBehaviour
{
    public GameObject player;
    public GameObject noteUI;
    public GameObject Text;
    public bool inReach;
    public AudioSource audioSource;
    public bool isOn = false;
    
    
    void Start()
    {
        noteUI.SetActive(false);
        Text.SetActive(false);

        inReach = false;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            Text.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            Text.SetActive(false);
        }
    }
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && inReach && !isOn)
        {
            if (Time.timeScale != 0) 
            {
                noteUI.SetActive(true);
                //Cursor.visible = true;
                //Cursor.lockState = CursorLockMode.None;
                audioSource.Play();
                // Turning off note outline
                gameObject.layer = LayerMask.NameToLayer("Default");
                isOn = true;
            }
        }

        else if (Input.GetKeyUp(KeyCode.E) && isOn) {
            noteUI.SetActive(false);
            isOn = false;
        }

        if (Input.GetKeyUp(KeyCode.Escape) && inReach) {
            Text.SetActive(!Text.activeSelf);
        }

        if(isOn) {
            if (Input.GetKeyUp(KeyCode.Escape)) {
                noteUI.SetActive(false);
                isOn = false;
            }
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance > 6) {
                noteUI.SetActive(false);
                isOn = false;
            }
        }

    }
    public void ExitButton()
    {
        noteUI.SetActive(false);
        //Cursor.visible = false;
    }
}