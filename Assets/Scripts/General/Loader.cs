using Assets.Scripts.Logs;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.General
{
    public static class Loader
    {

        public static void Load() {

            SceneManager.LoadScene("MainMenu_scene");
        }


    }
}