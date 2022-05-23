namespace Kp4wsGames.State
{
	public abstract class PlayerBaseState : State
	{
        protected PlayerStateMachine stateMachine;
        public PlayerBaseState(PlayerStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
    }
}