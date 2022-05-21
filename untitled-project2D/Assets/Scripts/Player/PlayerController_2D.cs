using UnityEngine;
using Kp4wsGames.Input;

namespace Kp4wsGames.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
	public class PlayerController_2D : MonoBehaviour
    {
        [field: SerializeField] public InputReader InputReader { get; private set; }
        [field: SerializeField] public Rigidbody2D Player_RigidBody { get; private set; }
        [field: SerializeField] public PlayerBrain Modifiers { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }

        private void Awake()
        {
            if (Player_RigidBody == null)
            {
                Player_RigidBody = GetComponent<Rigidbody2D>();
            }
        }

        private void Update()
        {
            PhysicsCheck();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void PhysicsCheck()
        {

        }

        private void Move()
        {
            Vector2 movement = new Vector2(InputReader.MovementValue.x * Modifiers.MoveSpeed * Time.deltaTime, 
                InputReader.MovementValue.y * Modifiers.MoveSpeed * Time.deltaTime);
            movement.Normalize();

            Player_RigidBody.AddForce(movement, ForceMode2D.Force); //TODO
        }
    }
}