using UnityEngine;

namespace Kp4wsGames.Attributes
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float healthPoints = 100f; //TODO
        private bool isDead;

        public void TakeDamage(GameObject sender, float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);

            if(healthPoints == 0)
            {
                Die();
            }
            else
            {
                //On take damage
            }
        }

        public bool IsDead()
        {
            return isDead;
        }

        private void Die()
        {
            if (isDead)
                return;

            isDead = true;
            Destroy(gameObject); //TODO
            //TODO Invoke UnityEvent?
        }
    }
}