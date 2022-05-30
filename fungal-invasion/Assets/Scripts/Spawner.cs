using System.Collections;
using UnityEngine;

using Kp4wsGames.Player;
using Kp4wsGames.Entities.Enemy;

namespace Kp4wsGames.Default
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] GameObject[] enemyPrefabs;
        [SerializeField] float maxSpawnDistance = 10f;
        [SerializeField] float spawnDelay = 1f;

        PlayerController_2D player;

        Coroutine spawn;

        private void Start()
        {
            player = FindObjectOfType<PlayerController_2D>();//TODO
            if (player == null)
                return;

            spawn = StartCoroutine(SpawnEnemiesContinously());
        }

        public void Stop()
        {
            StopCoroutine(spawn);
        }

        private IEnumerator SpawnEnemiesContinously()
        {

            float maxScale = 2f;

            while(true)
            {
                //float minX = player.transform.position.x - maxSpawnDistance;
                //float maxX = player.transform.position.x + maxSpawnDistance;
                //float minY = player.transform.position.y + maxSpawnDistance;
                //float maxY = player.transform.position.y - maxSpawnDistance;
                //float x = Random.Range(minX, maxX);
                //float y = Random.Range(minY, maxY);
                float x = Random.Range(2, 98);
                float y = Random.Range(2, 98);

                Vector2 spawnPosition = new Vector2(x,y);

                float scale = Random.Range(1, maxScale);

                int randomIndex = 0;
                GameObject selectedEnemy = enemyPrefabs[randomIndex];

                GameObject enemy = Instantiate(selectedEnemy, spawnPosition, Quaternion.identity);
                
                enemy.transform.parent = gameObject.transform;
                enemy.transform.localScale = new Vector3(scale, scale, transform.localScale.z);

                AIController ai = enemy.GetComponent<AIController>();
                ai.SetSpeed(Random.Range(4.0f, 6.0f));

                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }
}