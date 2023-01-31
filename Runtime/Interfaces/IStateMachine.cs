namespace SorceressSpell.LibrarIoh.StateMachines
{
    public interface IStateMachine<TState>
        where TState : State<TState>
    {
        #region Methods

        void ChangeState(TState state);

        void Start(TState startingGameState);

        void Stop();

        #endregion Methods
    }
}
