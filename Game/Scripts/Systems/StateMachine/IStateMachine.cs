namespace Game.Systems.StateMachine
{
    public interface IStateMachine
    {
        IState CurrentState { get; }
        void ChangeState(IState state);
    }
}