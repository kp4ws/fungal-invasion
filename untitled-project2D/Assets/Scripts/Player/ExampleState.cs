using UnityEngine;

namespace Kp4wsGames.State
{
    public class ExampleState : PlayerBaseState
    {
        public ExampleState(PlayerStateMachine stateMachine) : base(stateMachine) { }
        private float timer;

        public override void Enter()
        {
            stateMachine.InputReader.JumpEvent += OnJump;
        }

        public override void Tick(float deltaTime)
        {
            timer -= deltaTime;
            Debug.Log(timer);
        }

        public override void Leave()
        {
            stateMachine.InputReader.JumpEvent -= OnJump;
        }

        private void OnJump()
        {
            stateMachine.SwitchState(new PlayerFirstPersonState(stateMachine));
        }
    }
}