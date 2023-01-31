using System.Collections.Generic;

namespace SorceressSpell.LibrarIoh.StateMachines
{
    public class PushdownAutomataStateMachine<TState> : StateMachine<TState>
        where TState : State<TState>
    {
        #region Fields

        protected readonly Stack<TState> StateStack;

        #endregion Fields

        #region Properties

        public override TState CurrentState
        {
            get
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
        }

        #endregion Properties

        #region Constructors

        public PushdownAutomataStateMachine()
            : base()
        {
            StateStack = new Stack<TState>();
        }

        #endregion Constructors

        #region Methods

        protected virtual void PushdownAutomataStateMachine_ChangeStateStrategy(TState state)
        {
            base.StateMachine_ChangeStateStrategy(state);
        }

        protected virtual void PushdownAutomataStateMachine_OnChangeStateFailure(TState state)
        {
        }

        protected virtual void PushdownAutomataStateMachine_OnChangeStateSuccess(TState state)
        {
        }

        protected virtual void PushdownAutomataStateMachine_OnStart()
        {
        }

        protected virtual void PushdownAutomataStateMachine_OnStatePop(TState poppedState)
        {
        }

        protected virtual void PushdownAutomataStateMachine_OnStatePush(TState pushedState)
        {
        }

        protected virtual void PushdownAutomataStateMachine_OnStop()
        {
        }

        protected override sealed bool StateMachine_ChangeState(TState state)
        {
            if (StateStack.Count > 1 && state == StateStack.Peek())
            {
                // Pop it!
                StateStack.Peek().OnExit();
                TState previousState = StateStack.Pop();
                PushdownAutomataStateMachine_OnStatePop(previousState);

                if (StateStack.TryPeek(out TState topState))
                {
                    topState.OnResume(previousState);
                }
                else
                {
                    Started = false;
                }

                return true;
            }
            else if (StateStack.Contains(state))
            {
                // Do not allow the same item to appear twice on the stack.
                return false;
            }
            else
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

                return true;
            }
        }

        protected override sealed void StateMachine_ChangeStateStrategy(TState state)
        {
            PushdownAutomataStateMachine_ChangeStateStrategy(state);
        }

        protected override sealed void StateMachine_OnChangeStateFailure(TState state)
        {
            PushdownAutomataStateMachine_OnChangeStateFailure(state);
        }

        protected override sealed void StateMachine_OnChangeStateSuccess(TState state)
        {
            PushdownAutomataStateMachine_OnChangeStateSuccess(state);
        }

        protected override sealed void StateMachine_OnStart()
        {
            PushdownAutomataStateMachine_OnStart();
        }

        protected override sealed void StateMachine_OnStop()
        {
            PushdownAutomataStateMachine_OnStop();
            StateStack.Clear();
        }

        #endregion Methods
    }
}
