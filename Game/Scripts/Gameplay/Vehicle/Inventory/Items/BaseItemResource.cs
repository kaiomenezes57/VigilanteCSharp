using Godot;

namespace Game.Gameplay.Vehicle.Inventory.Items
{
    [GlobalClass]
    public abstract partial class BaseItemResource : Resource
    {
        public abstract void Use(Node owner);
    }
}