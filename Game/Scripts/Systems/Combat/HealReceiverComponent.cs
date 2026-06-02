using Game.Systems.Combat.Data;
using Godot;

namespace Game.Systems.Combat
{
    public sealed partial class HealReceiverComponent : Node,
        IHealable
    {
        [Export] private HealthComponent _healthComponent;

        public void Heal(HealData data)
        {
            _healthComponent.Add(data.Amount);
        }
    }
}
