using Game.Gameplay.Vehicle;
using Game.Gameplay.Vehicle.Inputs;
using Godot;

namespace Game.Systems.Spawners
{
    public sealed partial class EnemySpawner : BaseSpawner
    {
        public override void Spawn()
        {
            base.Spawn();

            if (LastSpawned is not VehicleController { } vehicle)
                return;

            vehicle.Setup(new TestVehicleInput());
            GD.Print("[SPAWNER] Enemy has been spawned");
        }
    }
}
