using Godot;

namespace Game.Systems.Trigger
{
    public readonly struct TriggerData(
        OnOverlapTrigger owner, Node3D enteredBody)
    {
        public OnOverlapTrigger Owner { get; } = owner;
        public Node3D EnteredBody { get; } = enteredBody;
    }
}
