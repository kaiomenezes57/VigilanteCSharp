using Godot;

namespace Game.Systems.Spawners
{
    public sealed partial class TimedSpawn : BaseSpawner
    {
        [Export] private Timer _timer;
        
        public override void Spawn()
        {
            _timer.Start();
            _timer.Timeout += base.Spawn;
        }

        public override void _ExitTree() 
            => _timer.Timeout -= base.Spawn;
    }
}
