using Game.Systems.Combat.Data;
using Godot;
using System;

namespace Game.Systems.Combat
{
    public static class CombatProcessor
    {
        public static event Action<IDamageable, Node, DamageData> OnDamage;
        public static event Action<IDamageable, Node, DamageData> OnDie;
        public static event Action<IHealable, Node, HealData> OnHeal;

        public static void Damage(
            IDamageable target,
            Node caller, 
            DamageData data)
        {
            var onDieCallback =
                () => OnDie?.Invoke(target, caller, data);

            target.Damage(data, onDieCallback);
            OnDamage?.Invoke(target, caller, data);
        }

        public static void Heal(
            IHealable target,
            Node caller,
            HealData data)
        {
            target.Heal(data);
            OnHeal?.Invoke(target, caller, data);
        }
    }
}