using Assets.Scripts.Logs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerSimpleUI : MonoBehaviour
{

    public void LoadSceneByName(string name) {
        LoggerFile.Instance.INFO_LINE("Go to scene : "+ name);
        SceneManager.LoadScene(name);
    
    }

   
}
