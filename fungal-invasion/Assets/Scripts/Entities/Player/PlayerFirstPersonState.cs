using Kp4wsGames.Weapons;
using UnityEngine;

namespace Kp4wsGames.State
{
    public class PlayerFirstPersonState : PlayerBaseState
    {
        public PlayerFirstPersonState(PlayerStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
        }

        public override void Tick(float deltaTime)
        {
            Vector3 movement = CalculateMovement();
            //Quaternion rotation = CalculateRotation();
            stateMachine.Controller.Move(movement * stateMachine.Modifiers.MoveSpeed * deltaTime);

            if (stateMachine.InputReader.MovementValue == Vector2.zero)
            {
                //Set walking animation to 0
                return;
            }

            //Set walking animation to 1
            //FaceMovementDirection();
        }

        public override void Leave()
        {
        }

        //public Quaternion CalculateRotation()
        //{
        //    float turnAngleHorizontal = Mathf.SmoothDampAngle(stateMachine.transform.eulerAngles.y, stateMachine.MainCameraTransform.eulerAngles.y, ref turnSmoothVelocity, 0f);
        //    float turnAngleVertical = Mathf.SmoothDampAngle(stateMachine.transform.eulerAngles.x, stateMachine.MainCameraTransform.eulerAngles.x, ref turnSmoothVelocity, 0f);
        //    return Quaternion.Euler(turnAngleVertical, turnAngleHorizontal, stateMachine.transform.eulerAngles.z);
        //}

        public Vector3 CalculateMovement()
        {
            Vector3 forward = stateMachine.MainCameraTransform.forward;
            Vector3 right = stateMachine.MainCameraTransform.right;

            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();

            //TODO Figure out how this calculation works
            return forward * stateMachine.InputReader.MovementValue.y + right * stateMachine.InputReader.MovementValue.x;
        }
    }
}