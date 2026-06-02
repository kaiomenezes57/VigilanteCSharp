using Game.Systems.Combat.Effects;

namespace Game.Systems.Combat.Data
{
    public readonly struct DamageData
    {
        public float Amount { get; }
        public IDamageEffect[] Effects { get; }
    }
}
