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

        public void FixedUpdate(float fixedDeltaTime)
        {
            State_OnFixedUpdate(fixedDeltaTime);
        }

        public void LateUpdate(float deltaTime)
        {
            State_OnLateUpdate(deltaTime);
        }

        public void OnEnter(TState previousState)
        {
            ReturnState = null;

            State_OnEnter(previousState);
            State_RegisterInputs();
        }

        public void OnExit()
        {
            ReturnState = null;

            State_OnExit();
            State_UnregisterInputs();
        }

        public void OnPause()
        {
            ReturnState = null;

            State_OnPause();
            State_UnregisterInputs();
        }

        public void OnResume(TState previousState)
        {
            ReturnState = null;

            State_OnResume(previousState);
            State_RegisterInputs();
        }

        public void Update(float deltaTime)
        {
            State_OnUpdate(deltaTime);
        }

        protected virtual void State_OnEnter(TState previousState)
        {
        }

        protected virtual void State_OnExit()
        {
        }

        protected virtual void State_OnFixedUpdate(float fixedDeltaTime)
        {
        }

        protected virtual void State_OnLateUpdate(float deltaTime)
        {
        }

        protected virtual void State_OnPause()
        {
        }

        protected virtual void State_OnResume(TState previousState)
        {
        }

        protected virtual void State_OnUpdate(float deltaTime)
        {
        }

        protected virtual void State_RegisterInputs()
        {
        }

        protected virtual void State_UnregisterInputs()
        {
        }

        #endregion Methods
    }
}
