using Assets.Scripts.Logs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Game.Weapon
{ 

    public abstract class Bullet : MonoBehaviour
    {

         public float Damage { get; set; }


        //game bullet collision logic 
        public void OnTriggerEnter(Collider other)
        {
            LoggerFile.Instance.DEBUG_LINE("Bullet collider " + other.tag);
            LoggerFile.Instance.DEBUG_LINE("Damage " + Damage);


            if (other.tag == "Player")
            {
                var player = other.gameObject.GetComponent<CharacterPlayer>();
                player.TakeDamege(Damage);
                player.ShowHeathConsole();
            }

            Destroy(gameObject);

        }


    }
}