using Game.Systems.Combat.Data;

namespace Game.Systems.Combat
{
    public interface IHealable
    {
        void Heal(HealData data);
    }
}
