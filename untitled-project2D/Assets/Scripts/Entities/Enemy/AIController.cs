using Kp4wsGames.Player;
using UnityEngine;

namespace Kp4wsGames.Entities.Enemy
{
	public class AIController : MonoBehaviour
	{
        [SerializeField] private Transform target;
        [SerializeField] private float moveSpeed = 6f;

        public void SetSpeed(float speed)
        {
            moveSpeed = speed;
        }

        private void Start()
        {
            target = FindObjectOfType<PlayerController_2D>().gameObject.transform;
        }

        private void Update()
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag != "Player")
                return;

            //TODO hit event
            Destroy(gameObject);
        }
    }
}