using Kp4wsGames.Player;
using UnityEngine;

namespace Kp4wsGames.Entities.Enemy
{
	public class AIController : MonoBehaviour
	{
        [SerializeField] private Transform target;

        private void Start()
        {
            target = FindObjectOfType<PlayerController_2D>().gameObject.transform;
        }

        private void Update()
        {
            float step = 5f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}