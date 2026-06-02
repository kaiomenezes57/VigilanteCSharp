using Godot;

namespace Game.Systems.StateMachine
{
    public abstract partial class BaseStateMachine : Node, IStateMachine
    {
        protected abstract IState FirstState { get; }
        public IState CurrentState { get; private set; }

        public override void _Ready() 
            => ChangeState(FirstState);

        public override void _Process(double delta) 
            => CurrentState?.Tick(this, delta);

        public override void _ExitTree() 
            => CurrentState?.Exit(this);

        public void ChangeState(IState state)
        {
            CurrentState?.Exit(this);

            CurrentState = state;

            CurrentState?.Enter(this);
        }
    }
}