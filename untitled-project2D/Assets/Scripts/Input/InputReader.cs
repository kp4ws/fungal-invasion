using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Kp4wsGames.Input
{
    public class InputReader : MonoBehaviour, Controls.IPlayerActions
    {
        public Vector2 MovementValue { get; private set; }
        public event Action JumpEvent;
        public event Action PickupEvent;

        private Controls controls;

        private void Start()
        {
            controls = new Controls();
            controls.Player.SetCallbacks(this);
            controls.Enable();
        }

        private void OnDestroy()
        {
            controls.Player.Disable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MovementValue = context.ReadValue<Vector2>();
        }
    }
}