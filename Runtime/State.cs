namespace SorceressSpell.LibrarIoh.StateMachines
{
    public abstract class State<TState>
        where TState : class
    {
        #region Constructors

        protected State()
        { }

        #endregion Constructors

        #region Methods

        public void OnEnter(TState previousState)
        {
            State_OnEnter(previousState);
        }

        public void OnExit()
        {
            State_OnExit();
        }

        public void OnPause()
        {
            State_OnPause();
        }

        public void OnResume(TState previousState)
        {
            State_OnResume(previousState);
        }


        protected virtual void State_OnEnter(TState previousState)
        {
        }

        protected virtual void State_OnExit()
        {
        }

        protected virtual void State_OnPause()
        {
        }

        protected virtual void State_OnResume(TState previousState)
        {
        }

        #endregion Methods
    }
}
