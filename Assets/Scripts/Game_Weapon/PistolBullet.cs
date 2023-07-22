using Assets.Scripts.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Weapon
{
    class PistolBullet : Bullet
    {

        [SerializeField] private float _speed;

        private void Start()
        {
            LoggerFile.Instance.DEBUG_LINE("Pisto bullet Spawn");

            
        }

        public void FixedUpdate()
        {
            BulletMovement();
        }

        public void BulletMovement() {

            Vector3 bltVelocity = Vector3.forward * _speed;

            transform.Translate(bltVelocity * Time.deltaTime);
        
        }


    }
}
