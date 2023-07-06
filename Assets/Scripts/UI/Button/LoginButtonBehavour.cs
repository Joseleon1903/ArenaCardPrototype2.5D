using Assets.Scripts.Logs;
using Assets.Scripts.Player;
using Assets.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginButtonBehavour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("iniciando Login...");
        LoggerFile.Instance.INFO_LINE("iniciando boton de login...");

        PlayerComponent player = PlayerUtil.FindPlayerDefaultInstance().GetComponent<PlayerComponent>();

        player.Username = "Guest_001";
        player.Alias = "Guest";


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
