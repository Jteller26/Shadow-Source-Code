using System.Collections.Generic;
using UnityEngine;

namespace UILogic
{
    public class PauseUIController : MonoBehaviour
    {
        // Start is called before the first frame update
        private List<GameObject> panels;
        private bool paused = false;
        private GameObject crosshair;
        void Start()
        {
            panels = new List<GameObject>();
            crosshair = GameObject.Find("Crosshair");
            
            for (int i = 0; i < transform.childCount; i++)
            {
                panels.Add(transform.GetChild(i).gameObject);           
            }

            ResumeGame();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                if (paused) {
                    ResumeGame();
                }
                else {
                    PauseGame();
                }
            }
            
        }

        void PauseGame()
        {
            Time.timeScale = 0;
            paused = true;
            crosshair.SetActive(false);
            
            foreach (GameObject panel in panels)
            {
                Cursor.visible = true;
                panel.SetActive(true);
            }

        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
            paused = false;
            crosshair.SetActive(true);
            
            foreach (GameObject panel in panels)
            {
                Cursor.visible = false;
                panel.SetActive(false);
            }

        }

        public void ExitGame() {
            Application.Quit();
        }
    }
}