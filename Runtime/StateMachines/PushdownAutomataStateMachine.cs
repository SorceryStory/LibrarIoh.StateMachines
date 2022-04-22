using System.Collections.Generic;

namespace SorceressSpell.LibrarIoh.StateMachines
{
    public class PushdownAutomataStateMachine<TState> : StateMachine<TState>
        where TState : State<TState>
    {
        #region Fields

        protected readonly Stack<TState> StateStack;

        #endregion Fields

        #region Constructors

        public PushdownAutomataStateMachine()
            : base()
        {
            StateStack = new Stack<TState>();
        }

        #endregion Constructors

        #region Methods

        public override TState GetCurrentState()
        {
            if (StateStack.Count > 0)
            {
                return StateStack.Peek();
            }
            else
            {
                return null;
            }
        }

        protected virtual void PushdownAutomataStateMachine_OnStatePop(TState poppedState)
        {
        }

        protected virtual void PushdownAutomataStateMachine_OnStatePush(TState pushedState)
        {
        }

        protected override void StateMachine_ChangeState(TState state)
        {
            if (
                StateStack.Count > 1 &&
                state == StateStack.Peek()
                )
            {
                // Pop it!
                StateStack.Peek().OnExit();
                TState previousState = StateStack.Pop();
                PushdownAutomataStateMachine_OnStatePop(previousState);

                StateStack.Peek().OnResume(previousState);
            }
            else if (state != null)
            {
                // Push it in!
                TState previousState = null;

                if (StateStack.Count > 0)
                {
                    previousState = StateStack.Peek();
                    previousState.OnPause();
                }

                StateStack.Push(state);
                PushdownAutomataStateMachine_OnStatePush(state);

                StateStack.Peek().OnEnter(previousState);
            }
        }

        #endregion Methods
    }
}
