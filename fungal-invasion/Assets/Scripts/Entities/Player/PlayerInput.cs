using UnityEngine;
using Kp4wsGames.Input;

namespace Kp4wsGames.Player
{
	public class PlayerInput : MonoBehaviour
	{
        //public Vector3 movementInput { get; set; }
        //public Vector2 mouseInput { get; set; }
        //public bool runHeld { get; set; }
        //public bool jumpPressed { get; set; }

        //private bool readyToClear;
        //private bool inputDisabled;
        
        //private void Update()
        //{
        //    ClearInput();

        //    if (inputDisabled)
        //        return;

        //    ReadInput();
        //}

        //private void FixedUpdate()
        //{
        //    readyToClear = true;
        //}

        //private void ClearInput()
        //{
        //    if (!readyToClear)
        //        return;

        //    movementInput = new Vector3();
        //    mouseInput = new Vector3();
        //    runHeld = false;
        //    jumpPressed = false;

        //    readyToClear = false;
        //}

        //private void ReadInput()
        //{
        //    movementInput = InputManager.playerActions.Move.ReadValue<Vector3>();
        //    mouseInput = InputManager.playerActions.Look.ReadValue<Vector2>();
        //    runHeld = InputManager.playerActions.Run.IsPressed();
        //    jumpPressed = InputManager.playerActions.Jump.triggered;
        //}

        //public void EnableInput()
        //{
        //    inputDisabled = false;
        //}

        //public void DisableInput()
        //{
        //    inputDisabled = true;
        //}
    }
}