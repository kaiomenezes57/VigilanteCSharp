namespace Game.Gameplay.Vehicle.Inputs
{
    public readonly struct VehicleCommand(float throttle, float steering, bool brake)
    {
        public float Throttle { get; } = throttle;
        public float Steering { get; } = steering;
        public bool Brake { get; } = brake;
    }
}
