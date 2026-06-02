using Game.Systems.Combat.Data;
using System;

namespace Game.Systems.Combat
{
    public interface IDamageable
    {
        void Damage(DamageData data, Action onDieCallback = null);
    }
}