using UnityEngine;

namespace Kp4wsGames.State
{
	public abstract class StateMachine : MonoBehaviour
	{
		private State currentState;

        public void SwitchState(State newState)
        {
            currentState?.Leave();
            currentState = newState;
            currentState?.Enter();
        }

        private void Update()
        {
            //Null conditional operator (doesn't work for monobehaviors or scriptable objects)
            currentState?.Tick(Time.deltaTime);
        }
    }
}