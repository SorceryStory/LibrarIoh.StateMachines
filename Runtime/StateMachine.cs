namespace SorceressSpell.LibrarIoh.StateMachines
{
    public abstract class StateMachine<TState> : IStateMachine<TState>
        where TState : State<TState>
    {
        #region Fields

        protected bool Started;

        #endregion Fields

        #region Properties

        public abstract TState CurrentState { get; }

        #endregion Properties

        #region Constructors

        protected StateMachine()
        {
            Started = false;
        }

        #endregion Constructors

        #region Methods

        public void ChangeState(TState state)
        {
            if (Started)
            {
                ChangeStatePrimitive(state);
            }
        }

        public void Start(TState startingGameState)
        {
            if (!Started && startingGameState != null)
            {
                ChangeStatePrimitive(startingGameState);

                StateMachine_OnStart();

                Started = true;
            }
        }

        public void Stop()
        {
            if (Started)
            {
                StateMachine_OnStop();

                Started = false;
            }
        }

        protected void ChangeStatePrimitive(TState state)
        {
            if (state != null)
            {
                if (StateMachine_ChangeState(state))
                {
                    StateMachine_OnChangeStateSuccess(state);
                }
                else
                {
                    StateMachine_OnChangeStateFailure(state);
                }
            }
        }

        /// <summary>
        /// Strategy stub to change the state.
        /// </summary>
        /// <param name="state">The state to change into.</param>
        /// <returns><c>true</c> if the state change was succesful, <c>false</c> if not.</returns>
        protected abstract bool StateMachine_ChangeState(TState state);

        /// <summary>
        /// Strategy stub to process a state change failure.
        /// </summary>
        /// <param name="state">The state the machine failed to changed to.</param>
        protected virtual void StateMachine_OnChangeStateFailure(TState state)
        {
        }

        /// <summary>
        /// Strategy stub to process a state change success.
        /// </summary>
        /// <param name="state">The state the machine changed to.</param>
        protected virtual void StateMachine_OnChangeStateSuccess(TState state)
        {
        }

        protected virtual void StateMachine_OnStart()
        {
        }

        protected virtual void StateMachine_OnStop()
        {
        }

        #endregion Methods
    }
}
