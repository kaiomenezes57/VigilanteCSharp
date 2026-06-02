using Game.Gameplay.Vehicle.Inventory.Items;
using Godot;

namespace Game.Gameplay.Vehicle.Inventory
{
    public sealed class Slot
    {
        public BaseItemResource Item { get; private set; }
        public bool IsUsed => Item != null;
        private readonly Node _owner;

        public Slot(Node owner)
        {
            _owner = owner;
        }

        public void UseItem() 
            => Item?.Use(_owner);

        public void SetItem(BaseItemResource item) 
            => Item = item;
    }
}
