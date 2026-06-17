using Game.Systems.Spawners;
using Godot;
using System;
using System.Linq;

namespace Vigilante8.Game.Scripts.Systems.Spawners
{
    public sealed partial class SpawnersBootstrap : Node
    {
        public void Initialize()
        {
            var spawners = GetChildren()
                .OfType<ISpawner>();

            if (spawners == null || 
                !spawners.Any())
                return;

            foreach (var spawner in spawners)
                spawner?.Spawn();
        }
    }
}
