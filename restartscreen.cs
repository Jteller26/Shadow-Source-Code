using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Start_Menu
{
    public class restartscreen : MonoBehaviour
    {
        public void Start()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
        public string SceneName;
        public void restart() {
            SceneManager.LoadScene(SceneName);
        }

        public void exit() {
            Application.Quit();
        }
    }
}
