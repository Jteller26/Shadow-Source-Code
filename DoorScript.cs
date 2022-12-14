using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    
    public Animator door;
    public bool inReach;
    public GameObject openText;
    public AudioSource AudioSource;
    
    void Start()
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }
    
    void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            AudioSource.Play();
            DoorOpens();
        }
        else
        {
                DoorCloses();
        }
    }

    void DoorOpens()
    {
        door.SetBool("open", true);
        door.SetBool("closed", false);
    }
    
    void DoorCloses()
    {
        door.SetBool("open", false);
        door.SetBool("closed", true);
        
    }
}
