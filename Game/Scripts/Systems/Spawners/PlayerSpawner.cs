using Game.Gameplay.Vehicle;
using Game.Gameplay.Vehicle.Inputs;
using Godot;

namespace Game.Systems.Spawners
{
    public sealed partial class PlayerSpawner : BaseSpawner
    {
        public override void Spawn()
        {
            base.Spawn();
            
            if (LastSpawned is not VehicleController { } vehicle)
                return;

            vehicle.Setup(new PlayerVehicleInput());
            GD.Print("[SPAWNER] Player has been spawned");
        }
    }
}
