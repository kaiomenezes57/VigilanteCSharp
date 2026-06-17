using Game.Systems.Trigger.Actions;
using System.Linq;
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

            GD.Print("Component is null: " + targetComponent == null);

            if (targetComponent == null)
                return;

            GD.Print("Type: " + targetComponent.Type);
            GD.Print("Expected type: " + _target);

            if (targetComponent == null || targetComponent.Type != _target)
                return;
            
            foreach (var action in this.GetComponentsInChildren<BaseTriggerAction>())
                action.Trigger(new TriggerData(this, body));

            _triggered = true;
        }
    }
}
