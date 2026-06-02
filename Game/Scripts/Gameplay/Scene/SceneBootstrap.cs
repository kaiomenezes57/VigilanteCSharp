using Game.Systems.Spawners;
using Godot;
using System.Linq;

namespace Game.Gameplay.Scene
{
    public sealed partial class SceneBootstrap : Node
    {
        public override void _Ready()
        {
            InitializeSpawners();
            GD.Print("[BOOT] The game has been started");
        }

        private void InitializeSpawners()
        {
            GetChildren()
                .OfType<ISpawner>()
                .ToList()
                .ForEach(s => s.Spawn());
        }
    }
}
