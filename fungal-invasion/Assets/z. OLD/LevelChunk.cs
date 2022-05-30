using Kp4wsGames.Player;
using System;
using UnityEngine;

namespace Kp4wsGames.Default
{
    /// <summary>
    /// Note to self, the LevelChunk colliders are not set to the maximum width because this gets rid of a bug 
    /// where if the player immediately goes back to the previous chunk, sometimes its not set as active
    /// </summary>
	public class LevelChunk : MonoBehaviour
	{
        [SerializeField] private float cullDistance = 1000f;

        private const string PLAYER = "Player";
        LevelManager manager;

        public void SetManager(LevelManager manager)
        {
            this.manager = manager;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag != PLAYER)
                return;

            if (manager == null)
                return;

            manager.SetActiveLevelChunk(this);
        }

        PlayerController_2D player;

        //private void Start()
        //{
        //    player = FindObjectOfType<PlayerController_2D>();
        //}

        //private void OnEnable()
        //{
        //    float distance = Vector2.Distance(transform.position, player.transform.position);

        //    if (distance > cullDistance)
        //    {
        //        gameObject.SetActive(true);
        //    }
        //    else
        //    {
        //        gameObject.SetActive(false);
        //    }
        //}
    }
}