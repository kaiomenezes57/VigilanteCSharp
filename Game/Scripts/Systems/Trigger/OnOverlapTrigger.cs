using Game.Systems.Trigger.Actions;
using Godot;
using Game.Extensions;

namespace Game.Systems.Trigger
{
    public sealed partial class OnOverlapTrigger : Area3D
    {
        [Export] private TriggerTargetType _target;
        [Export] private bool _triggerOnce = true;
        private bool _triggered;

        public override void _EnterTree() 
            => BodyEntered += OnBodyEntered;

        public override void _ExitTree() 
            => BodyEntered -= OnBodyEntered;

        private void OnBodyEntered(Node3D body)
        {
            if ((_triggerOnce && _triggered) || body == null)
                return;

            var targetComponent = body.GetComponentInChildren<TriggerTargetComponent>();
            if (targetComponent == null || targetComponent.Type != _target)
                return;
            
            foreach (var action in this.GetComponentsInChildren<BaseTriggerAction>())
                action.Trigger(new TriggerData(this, body));

            _triggered = true;
        }
    }
}
