using Game.Systems.Combat.Effects;

namespace Game.Systems.Combat.Data
{
    public struct HealData
    {
        public float Amount { get; }
    }

    public struct DamageData
    {
        public float Amount { get; }
        public IDamageEffect[] Effects { get; }
    }
}
