using UnityEngine;
using Kp4wsGames.Input;
using UnityEngine.InputSystem;
using Kp4wsGames.Attributes;
using TMPro;

namespace Kp4wsGames.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController_2D : MonoBehaviour
    {
        [field: SerializeField] public InputReader InputReader { get; private set; }
        [field: SerializeField] public Rigidbody2D RigidBody { get; private set; }
        [field: SerializeField] public PlayerBrain Modifiers { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }

        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private TextMeshProUGUI scoreText;

        private int score = 0;

        public Camera MainCameraTransform { get; private set; }

        private Vector2 targetPosition;

        private void Awake()
        {
            if (RigidBody == null)
            {
                RigidBody = GetComponent<Rigidbody2D>();
            }
        }

        private void Start()
        {
            MainCameraTransform = Camera.main;
            healthText.text = "Health: " + GetComponent<Health>().getHealth();
            scoreText.text = "Score: " + score;
            SpawnPlayer(); 
        }

        private void Update()
        {
            PhysicsCheck();
            targetPosition = MainCameraTransform.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void SpawnPlayer()
        {
            //TODO make these calculations dynamic
            //const float PPU = 67.5f;
            //const float levelSize = 99; //0 - 99 = 100
            //const float resX = 1920;
            //const float resY = 1080;

            //float minX = 0;
            //float maxX = (resX / PPU) * (levelSize + 1);
            //float minY = 0;
            //float maxY = (resY / PPU) * (levelSize + 1);

            float x = Random.Range(2, 98);
            float y = Random.Range(2, 98);

            Vector2 spawnPosition = new Vector2(x, y);
            RigidBody.position = spawnPosition;
        }

        private void PhysicsCheck()
        {

        }

        private void Move()
        {
            RigidBody.MovePosition(RigidBody.position + InputReader.MovementValue * Modifiers.MoveSpeed * Time.fixedDeltaTime);

            Vector2 lookDir = targetPosition - RigidBody.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f; //Typically have to set this to -90 degress if player is pointing that way
            RigidBody.rotation = angle;
        }

        public void OnHit()
        {
            var health = GetComponent<Health>();
            health.TakeDamage(null, 10);//TODO dynamic damage amount
            healthText.text = "Health: " + health.getHealth();
        }

        public void OnEnemyDestroyed(int points)
        {
            score += points;
            scoreText.text = "Score: " + score;
        }
    }
}