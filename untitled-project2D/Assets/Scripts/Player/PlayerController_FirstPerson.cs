using UnityEngine;

namespace Kp4wsGames.Player
{
	public class PlayerController_FirstPerson : MonoBehaviour
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

        ////Player changes direction while stopped and moving
        //private void MoveHorizontal()
        //{
        //    Vector3 direction = new Vector3(playerInput.movementInput.x, 0, playerInput.movementInput.z).normalized;

        //    //Moves player
        //    if (direction.magnitude >= player.minThreshold)
        //    {
        //        float moveAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCam.eulerAngles.y;
        //        Vector3 moveDir = Quaternion.Euler(0f, moveAngle, 0f) * Vector3.forward;
        //        controller.Move(moveDir.normalized * GetHorizontalSpeed() * Time.deltaTime);
        //    }

        //    //Turns player
        //    float targetAngle = mainCam.eulerAngles.y;
        //    float turnAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, player.turnSmoothTime);
        //    transform.rotation = Quaternion.Euler(0f, turnAngle, 0f);
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
    }
}