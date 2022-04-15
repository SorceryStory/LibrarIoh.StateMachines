namespace SorceressSpell.LibrarIoh.StateMachines
{
    public class FiniteStateMachine<TState> : StateMachine<TState>
        where TState : State<TState>
    {
        #region Fields

        protected TState CurrentState;

        #endregion Fields

        #region Constructors

        public FiniteStateMachine()
            : base()
        { }

        #endregion Constructors

        #region Methods

        public override TState GetCurrentState()
        {
            return CurrentState;
        }

        protected override void StateMachine_ChangeState(TState state)
        {
            TState previousState = CurrentState;
            previousState.OnExit();

            CurrentState = state;
            CurrentState.OnEnter(previousState);
        }

        #endregion Methods
    }
}
