using Kp4wsGames.Attributes;
using UnityEngine;

namespace Kp4wsGames.Default
{
    public class Bullet : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            //TODO have a range of things not to hit
            if (collision.gameObject.tag == "Player")
                return;

            Destroy(gameObject);

            Health targetHealth = collision.gameObject.GetComponent<Health>();
            if (targetHealth == null)
                return;
            if (targetHealth.IsDead())
                return;

            float damage = 25f; //TODO get dynamic value for this.
            targetHealth.TakeDamage(gameObject, damage);
        }
    }
}