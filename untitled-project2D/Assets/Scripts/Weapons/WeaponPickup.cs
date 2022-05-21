using Kp4wsGames.Input;
using Kp4wsGames.State;
using System.Collections;
using UnityEngine;

namespace Kp4wsGames.Weapons
{
    public class WeaponPickup : MonoBehaviour
    {
        [SerializeField] private InputReader input;
        [SerializeField] private WeaponConfig weapon = null;
        [SerializeField] private GameObject weaponGUI = null;
        [SerializeField] private float respawnTime = 5f; //TODO delete this later?

        private const string PLAYER = "Player";
        private bool inRange = false;
        private GameObject playerObject = null;


        private void OnEnable()
        {
            input.PickupEvent += OnPickup;
        }

        private void OnDisable()
        {
            input.PickupEvent -= OnPickup;
        }

        private void OnPickup()
        {
            if (!inRange)
                return;
            if (playerObject == null)
                return;

            Pickup(playerObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == PLAYER)
            {
                inRange = true;
                ShowWeaponGUI(true);
                playerObject = other.gameObject;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!inRange)
                return;
            if (other.gameObject.tag == PLAYER)
            {
                ShowWeaponGUI(false);
                playerObject = null;
            }
        }

        private void Pickup(GameObject subject)
        {
            if (weapon == null)
                return;
            if (!inRange)
                return;

            subject.GetComponent<PlayerStateMachine>().PickupWeapon(weapon);
            ShowWeaponGUI(false);
            StartCoroutine(HideForSeconds(respawnTime));
        }

        private IEnumerator HideForSeconds(float seconds)
        {
            ShowPickup(false);
            yield return new WaitForSeconds(seconds);
            ShowPickup(true);
        }

        private void ShowPickup(bool show)
        {
            foreach(Collider colliders in GetComponents<Collider>())
            {
                colliders.enabled = show;
            }
            foreach (Transform child in transform)
            {
                //If not UI layer
                if(child.gameObject.layer != 5)
                {
                    child.gameObject.SetActive(show);
                }
            }
        }

        private void ShowWeaponGUI(bool show)
        {
            weaponGUI.SetActive(show);
        }
    }
}