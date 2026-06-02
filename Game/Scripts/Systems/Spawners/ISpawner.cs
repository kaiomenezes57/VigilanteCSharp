using Godot;

namespace Game.Systems.Spawners
{
    public interface ISpawner
    {
        Node3D LastSpawned { get; }
        void Spawn();
    }
}
