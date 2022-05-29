using System.Collections;
using UnityEngine;

namespace Kp4wsGames.Player
{
	public class Shooting : MonoBehaviour
	{
        //TODO Create Serialize component for these fields
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float bulletForce = 20f; 
        [SerializeField] private float fireRate = 0.1f;
        [SerializeField] private float destroyDelay = 3f;
        
        private Coroutine shootRoutine;
        private PlayerController_2D player;

        private void Awake()
        {
            player = GetComponent<PlayerController_2D>();
        }

        private void OnEnable()
        {
            player.InputReader.ShootEvent += OnShoot;
        }

        private void OnDisable()
        {
            player.InputReader.ShootEvent -= OnShoot;
        }


        public void OnShoot()
        {
            if(shootRoutine == null)
            {
                shootRoutine = StartCoroutine(ShootContinuously());
            }
            else
            {
                StopCoroutine(shootRoutine);
                shootRoutine = null;
            }
        }

        private IEnumerator ShootContinuously()
        {
            while(true)//TODO Add condition for reloading
            {
                //TODO object pool
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bullet.transform.parent = gameObject.transform;

                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                
                Destroy(bullet, destroyDelay);
                yield return new WaitForSeconds(fireRate);
            }
        }
    }
}