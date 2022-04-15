namespace SorceressSpell.LibrarIoh.StateMachines
{
    public abstract class State<TState>
        where TState : class
    {
        #region Properties

        public TState ReturnState { protected set; get; }

        #endregion Properties

        #region Constructors

        protected State()
        { }

        #endregion Constructors

        #region Methods

        public virtual void FixedUpdate(float fixedDeltaTime)
        {
        }

        public virtual void LateUpdate(float deltaTime)
        {
        }

        public void OnEnter(TState previousState)
        {
            ReturnState = null;

            State_OnEnter(previousState);
            RegisterInputs();
        }

        public void OnExit()
        {
            ReturnState = null;

            State_OnExit();
            UnregisterInputs();
        }

        public void OnPause()
        {
            ReturnState = null;

            State_OnPause();
            UnregisterInputs();
        }

        public void OnResume(TState previousState)
        {
            ReturnState = null;

            State_OnResume(previousState);
            RegisterInputs();
        }

        public virtual void Update(float deltaTime)
        {
        }

        protected virtual void RegisterInputs()
        {
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

        protected virtual void UnregisterInputs()
        {
        }

        #endregion Methods
    }
}
