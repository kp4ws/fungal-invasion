using Kp4wsGames.Saving;
using UnityEngine;

namespace Kp4wsGames.Player
{
	public class PlayerController_ThirdPerson : MonoBehaviour//, ISaveable
	{
        //[SerializeField] private PlayerBrain player;
        //[SerializeField] private Transform mainCam;

        //private PlayerInput playerInput;
        //private CharacterController controller;
        //private Vector3 playerVelocity;
        //private bool groundedPlayer;
        //private float turnSmoothVelocity;

        //void Awake() //TODO awake or start?
        //{
        //    playerInput = GetComponent<PlayerInput>();
        //    controller = GetComponent<CharacterController>();
        //}

        //private void Update()
        //{
        //    PhysicsCheck();
        //    MoveHorizontal();
        //    MoveVertical();

        //}

        //private void PhysicsCheck()
        //{
        //    groundedPlayer = controller.isGrounded;

        //    //Set vertical velocity to min threshold if grounded
        //    if (groundedPlayer && playerVelocity.y < 0)
        //    {
        //        playerVelocity.y = -0.01f;
        //    }
        //}

        ////Player only changes direction while moving
        //private void MoveHorizontal()
        //{
        //    Vector3 direction = new Vector3(playerInput.movementInput.x, 0, playerInput.movementInput.z).normalized;

        //    //Moves and turns player
        //    if (direction.magnitude >= player.minThreshold)
        //    {
        //        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCam.eulerAngles.y;
        //        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, player.turnSmoothTime);
        //        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        //        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        //        controller.Move(moveDir.normalized * GetHorizontalSpeed() * Time.deltaTime);
        //    }
        //}

        //private void MoveVertical()
        //{
        //    //Jump
        //    if (playerInput.jumpPressed && groundedPlayer)
        //    {
        //        playerVelocity.y += Mathf.Sqrt(player.jumpHeight * -3.0f * player.gravityValue);
        //    }

        //    playerVelocity.y += player.gravityValue * Time.deltaTime;
        //    controller.Move(playerVelocity * Time.deltaTime);
        //}

        //private float GetHorizontalSpeed()
        //{
        //    return playerInput.runHeld ? player.runSpeed : player.moveSpeed;
        //}

        //public object CaptureState()
        //{
        //    return new SerializableVector3(transform.position);
        //}

        //public void RestoreState(object state)
        //{
        //    SerializableVector3 position = (SerializableVector3)state;
        //    controller.enabled = false;
        //    transform.position = position.ToVector();
        //    controller.enabled = true;
        //}
    }
}