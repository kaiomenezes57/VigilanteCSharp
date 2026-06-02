using Game.Systems.Combat.Data;
using Godot;
using System;

namespace Game.Systems.Combat
{
    public sealed partial class DamageReceiverComponent : Node, 
        IDamageable
    {
        [Export] private HealthComponent _healthComponent;

        public void Damage(DamageData data, Action onDieCallback = null)
        {
            _healthComponent.Remove(data.Amount);

            foreach (var effect in data.Effects)
            {
                if (Owner is Node3D owner)
                    effect.ApplyOnTarget(owner);
            }

            if (_healthComponent.Current <= 0)
                onDieCallback?.Invoke();
        }
    }
}
