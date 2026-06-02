using Game.Extensions;
using Godot;

namespace Game.Systems.Spawners
{
    public partial class BaseSpawner : Node3D, ISpawner
    {
        [Export] private Node3D[] _possibleSpawnPositions;
        [Export] private PackedScene _packedScene;

        public Node3D LastSpawned { get; private set; }

        public virtual void Spawn()
        {
            var spawnedObj = _packedScene.Instantiate();
            if (spawnedObj is not Node3D node)
            {
                GD.PrintErr("[SPAWNER] Spawned object is not a Node3D");
                return;
            }

            node.Position = GetSpawnPosition();

            GetTree()
                .CurrentScene
                .AddChild(spawnedObj);

            LastSpawned = node;
        }

        private Vector3 GetSpawnPosition()
        {
            var spawnPosition = GlobalPosition;

            if (_possibleSpawnPositions is { Length: > 0 } positions)
            {
                var node = positions.GetRandom();

                if (node != null)
                    spawnPosition = node.Position;
            }

            return spawnPosition;
        }
    }
}
