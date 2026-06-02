using Godot;
using System;

namespace Game.Systems.Combat
{
    public sealed partial class HealthComponent : Node
    {
        [Export(PropertyHint.Range, "0.1,100")] public float Max { get; private set; }
        public float Current { get; private set; }

        public override void _Ready()
        {
            Current = Max;
        }

        public void Add(float amount)
        {
            var result = Current + amount;
            Current = Math.Clamp(result, 0f, Max);
        }

        public void Remove(float amount)
        {
            var result = Current - amount;
            Current = Math.Clamp(result, 0f, Max);
        }
    }
}
