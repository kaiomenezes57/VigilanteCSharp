using Godot;

namespace Game.Systems.StateMachine
{
    public abstract partial class BaseState : Node, IState
    {
        public virtual void Enter(IStateMachine stateMachine)
        {
        }

        public virtual void Tick(IStateMachine stateMachine, double delta)
        {
        }

        public virtual void Exit(IStateMachine stateMachine)
        {
        }
    }
}