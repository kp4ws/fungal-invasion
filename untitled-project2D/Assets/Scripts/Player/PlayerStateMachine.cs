using UnityEngine;
using Kp4wsGames.Input;
using Kp4wsGames.Weapons;
using Kp4wsGames.Player;

namespace Kp4wsGames.State
{
    //This class essentially acts as the Player
	public class PlayerStateMachine : StateMachine
	{
        //Properties are usually PascalCase
        [field: SerializeField] public InputReader InputReader { get; private set; }
        [field: SerializeField] public CharacterController Controller { get; private set; }
        [field: SerializeField] public PlayerBrain Modifiers { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public Transform WeaponHolder { get; private set; }
        [field: SerializeField] public WeaponConfig CurrentWeapon { get; private set; }

        //[field: SerializeField] public float FreelookMovementSpeed { get; private set; } // Look into merging this with scriptable objects (PlayerBrain)

        public Transform MainCameraTransform { get; private set; }

        private void Start()
        {
            MainCameraTransform = Camera.main.transform;
            SwitchState(new PlayerFirstPersonState(this));
        }

        public void PickupWeapon(WeaponConfig weapon)
        {
            CurrentWeapon = weapon;
            CurrentWeapon.Spawn(WeaponHolder, CurrentWeapon != null);
            UpdateControllerRadius(weapon);
        }

        private void UpdateControllerRadius(WeaponConfig weapon)
        {
            //To avoid this issue, place weapons horizontally on a table
            //Move out of wall if weapon is too large when picked up
            //if(weapon.GetRadius() > Controller.radius)
            //{
            //    float negativeAmount = Controller.radius - weapon.GetRadius();
            //    Vector3 movement = MainCameraTransform.forward * negativeAmount;
            //    Controller.Move(movement);
            //}

            Controller.radius = weapon.GetRadius();
            Controller.skinWidth = Controller.radius * 0.10f;
        }
    }
}