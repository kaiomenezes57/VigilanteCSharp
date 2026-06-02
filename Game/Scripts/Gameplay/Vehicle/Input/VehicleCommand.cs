namespace Game.Gameplay.Vehicle.Inputs
{
    public readonly struct VehicleCommand
    {
        public float Throttle { get; }
        public float Steering { get; }
        public bool Brake { get; }

        public VehicleCommand(float throttle, float steering, bool brake)
        {
            Throttle = throttle;
            Steering = steering;
            Brake = brake;
        }
    }
}
