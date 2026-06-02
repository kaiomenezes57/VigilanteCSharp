using Game.Systems.Combat;
using Game.Systems.Combat.Data;
using Godot;
using System.Linq;

namespace Game.Gameplay.Vehicle.Inventory.Items
{
    public sealed partial class CurePot : BaseItemResource
    {
        [Export] private float _amount;

        public override void Use(Node owner)
        {
            var healable = owner
                .GetChildren()
                .OfType<IHealable>()
                .First();

            if (healable == null)
                return;

            CombatProcessor.Heal(
                healable,
                owner,
                new HealData(_amount));
        }
    }
}