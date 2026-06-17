using Game.Extensions;
using Game.Gameplay.Vehicle.Inventory;
using Game.Gameplay.Vehicle.Inventory.Items;
using Godot;

namespace Game.Systems.Trigger.Actions
{
    public sealed partial class AddItemToInventory : BaseTriggerAction
    {
        [Export] private BaseItemResource _itemResource;

        protected override void OnTrigger(TriggerData data)
        {
            if (data.EnteredBody.GetComponentInChildren<InventoryComponent>()
                is not { } inventoryComponent)
                return;

            var itemName = _itemResource
                .GetType()
                .Name;

            if (!inventoryComponent.TryAddItem(_itemResource))
            {
                GD.Print($"{itemName} item could not be added");
                return;
            }
            
            GD.Print($"{itemName} item has been added successfully");
            QueueFree();
        }
    }
}
