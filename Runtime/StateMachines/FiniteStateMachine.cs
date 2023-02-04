namespace SorceressSpell.LibrarIoh.StateMachines
{
    public class FiniteStateMachine<TState> : StateMachine<TState>
        where TState : State<TState>
    {
        #region Fields

        private TState _currentState;

        #endregion Fields

        #region Properties

        public override TState CurrentState
        {
            get
            {
                return _currentState;
            }
        }

        #endregion Properties

        #region Constructors

        public FiniteStateMachine()
            : base()
        { }

        #endregion Constructors

        #region Methods

        protected virtual void FiniteStateMachine_OnChangeStateFailure(TState state)
        {
        }

        protected virtual void FiniteStateMachine_OnChangeStateSuccess(TState state)
        {
        }

        protected virtual void FiniteStateMachine_OnStart()
        {
        }

        protected virtual void FiniteStateMachine_OnStop()
        {
            _currentState?.OnExit();
        }

        protected override sealed bool StateMachine_ChangeState(TState state)
        {
            TState previousState = null;

            if (_currentState != null)
            {
                previousState = _currentState;
                previousState.OnExit();
            }

            _currentState = state;
            _currentState.OnEnter(previousState);

            return true;
        }

        protected override sealed void StateMachine_OnChangeStateFailure(TState state)
        {
            FiniteStateMachine_OnChangeStateFailure(state);
        }

        protected override sealed void StateMachine_OnChangeStateSuccess(TState state)
        {
            FiniteStateMachine_OnChangeStateSuccess(state);
        }

        protected override sealed void StateMachine_OnStart()
        {
            FiniteStateMachine_OnStart();
        }

        protected override sealed void StateMachine_OnStop()
        {
            FiniteStateMachine_OnStop();
            _currentState = null;
        }

        #endregion Methods
    }
}
