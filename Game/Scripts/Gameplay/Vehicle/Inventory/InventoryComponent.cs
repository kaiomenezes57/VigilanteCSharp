using Game.Gameplay.Vehicle.Inventory.Items;
using Godot;
using System.Collections.Generic;
using System.Linq;

namespace Game.Gameplay.Vehicle.Inventory
{
    public sealed partial class InventoryComponent : Node
    {
        private readonly List<Slot> _slots = new();
        [Export] private int _slotsAmount = 3;

        public override void _Ready()
        {
            for (int i = 0; i < _slotsAmount; i++)
                _slots.Add(new Slot(Owner));
        }

        public bool TryAddItem(BaseItemResource item)
        {
            if (!_slots.Any(slot => !slot.IsUsed))
                return false;

            _slots
                .First(slot => !slot.IsUsed)
                .SetItem(item);

            return true;
        }

        public bool TryRemoveItem(BaseItemResource item)
        {
            var slot = _slots.Find(slot => slot.Item == item);
            if (slot == null)
                return false;

            slot.SetItem(null);
            return true;
        }

        public IReadOnlyList<BaseItemResource> GetAllItems()
        {
            return _slots
                .Where(slot => slot.IsUsed)
                .Select(slot => slot.Item)
                .ToList();
        }
    }
}
