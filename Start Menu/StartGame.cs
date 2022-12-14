using UnityEngine;
using UnityEngine.SceneManagement;

namespace Start_Menu
{
    public class StartGame : MonoBehaviour
    {
        public string SceneName;
        public void start() {
            SceneManager.LoadScene(SceneName);
        }

        public void exit() {
            Application.Quit();
        }
    }
}
