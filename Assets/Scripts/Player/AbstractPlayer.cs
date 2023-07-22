using Assets.Scripts.Logs;
using UnityEngine;


namespace Assets.Scripts.Player
{
    public abstract class AbstractPlayer : MonoBehaviour
    {

        [SerializeField] float Health;

        public void TakeDamege(float damage) {

            Health -= damage;

            if (Health <= 0) {
                Die();
            }
        }


        public void Die() {

            Destroy(gameObject);
        }


        public void ShowHeathConsole() {
            LoggerFile.Instance.DEBUG_LINE("Player life "+ Health);
        }

    }
}