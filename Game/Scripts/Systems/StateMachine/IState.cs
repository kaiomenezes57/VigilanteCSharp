namespace Game.Systems.StateMachine
{
    public interface IState
    {
        void Enter(IStateMachine stateMachine);
        void Tick(IStateMachine stateMachine, double delta);
        void Exit(IStateMachine stateMachine);
    }
}