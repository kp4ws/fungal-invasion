using UnityEngine;
using UnityEngine.Events;

namespace Kp4wsGames.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] UnityEvent onHit;

        public void OnHit()
        {
            onHit.Invoke();
        }
    }
}
