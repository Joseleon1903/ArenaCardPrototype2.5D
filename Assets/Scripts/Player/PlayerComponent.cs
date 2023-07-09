using UnityEngine;

namespace Assets.Scripts.Player
{
    class PlayerComponent : MonoBehaviour
    {
        [SerializeField] string username;

        [SerializeField] string alias;


        [SerializeField] PlayerUtilConstant.Estatus playerStatus;

        [SerializeField] PlayerUtilConstant.Platform playerPlatform;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public string Username { get => username; set => username = value; }

        public string Alias { get => alias; set => alias = value; }

        /*  [SerializeField]
          public string Username { get => username; set => username = value; }

          private string alias;

          [SerializeField]
          public string Alias { get => alias; set => alias = value; }

          private string tag;

          [SerializeField]
          public string Tag { get => tag; set => tag = value; }

          [SerializeField]
          private PlayerUtilConstant.Estatus playerStatus { get; set; }

          [SerializeField]
          private PlayerUtilConstant.Platform playerPlatform { get; set; }*/









    }
}
