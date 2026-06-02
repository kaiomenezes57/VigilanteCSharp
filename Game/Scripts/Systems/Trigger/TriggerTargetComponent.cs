using Godot;

namespace Game.Systems.Trigger
{
    public sealed partial class TriggerTargetComponent : Node3D
    {
        [Export] public TriggerTargetType Type { get; private set; }
    }
}
