namespace SorceressSpell.LibrarIoh.StateMachines
{
    public abstract class StateMachine<TState>
        where TState : State<TState>
    {
        #region Fields

        private bool _started;

        #endregion Fields

        #region Constructors

        protected StateMachine()
        {
            _started = false;
        }

        #endregion Constructors

        #region Methods

        public void FixedUpdate(float fixedDeltaTime)
        {
            if (_started)
            {
                GetCurrentState().FixedUpdate(fixedDeltaTime);
            }
        }

        public abstract TState GetCurrentState();

        public void LateUpdate(float deltaTime)
        {
            if (_started)
            {
                GetCurrentState().LateUpdate(deltaTime);
                ChangeState(GetCurrentState().ReturnState);
            }
        }

        public void Start(TState startingGameState)
        {
            if (startingGameState != null)
            {
                ChangeState(startingGameState);

                StateMachine_OnStart();

                _started = true;
            }
        }

        public void Update(float deltaTime)
        {
            if (_started)
            {
                StateMachine_OnPreUpdate(deltaTime);

                GetCurrentState().Update(deltaTime);
                ChangeState(GetCurrentState().ReturnState);

                StateMachine_OnPostUpdate(deltaTime);
            }
        }

        protected void ChangeState(TState state)
        {
            if (state != null)
            {
                StateMachine_ChangeState(state);
                StateMachine_OnChangeState(state);
            }
        }

        protected abstract void StateMachine_ChangeState(TState state);

        protected virtual void StateMachine_OnChangeState(TState state)
        {
        }

        protected virtual void StateMachine_OnPostUpdate(float deltaTime)
        {
        }

        protected virtual void StateMachine_OnPreUpdate(float deltaTime)
        {
        }

        protected virtual void StateMachine_OnStart()
        {
        }

        #endregion Methods
    }
}
