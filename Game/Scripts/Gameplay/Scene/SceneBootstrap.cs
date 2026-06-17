using Godot;
using Vigilante8.Game.Scripts.Systems.Spawners;

namespace Game.Gameplay.Scene
{
    public sealed partial class SceneBootstrap : Node
    {
        [Export] private SpawnersBootstrap _spawners;

        public override void _Ready()
        {
            _spawners?.Initialize();


            GD.Print("[BOOT] The game has been started");
        }
    }
}
