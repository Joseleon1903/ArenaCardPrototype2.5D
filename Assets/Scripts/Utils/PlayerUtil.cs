using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public static class  PlayerUtil
    {

        public static GameObject FindPlayerDefaultInstance() {
            return GameObject.FindGameObjectWithTag("Player");
        }



    }
}
