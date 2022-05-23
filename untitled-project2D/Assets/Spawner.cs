using System.Collections;
using UnityEngine;

namespace Kp4wsGames.Default
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] GameObject[] enemyPrefabs;

        private void Start()
        {
            StartCoroutine(SpawnEnemiesContinously());
        }

        private IEnumerator SpawnEnemiesContinously()
        {
            while(true)
            {
                int randomIndex = 0;
                GameObject selectedEnemy = enemyPrefabs[randomIndex];
                GameObject enemy = Instantiate(selectedEnemy, new Vector3(2, 1, 0), Quaternion.identity);
                enemy.transform.parent = gameObject.transform;
                yield return new WaitForSeconds(2f);
            }
        }
    }
}