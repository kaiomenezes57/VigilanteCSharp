using Godot;

namespace Game.Systems.Combat.Effects
{
    public interface IDamageEffect
    {
        void ApplyOnTarget(Node3D target);
    }
}
