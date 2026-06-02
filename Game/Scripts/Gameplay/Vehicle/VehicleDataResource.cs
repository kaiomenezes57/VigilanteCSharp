using Godot;

namespace Game.Gameplay.Vehicle
{
    [GlobalClass]
    public sealed partial class VehicleDataResource : Resource
    {
        [ExportGroup("Profile")]
        [Export] public string Name { get; private set; }
        [Export] public string Description { get; private set; }
        [Export] public PackedScene VehicleVisual { get; private set; }

        [ExportGroup("Attributes")]
        [Export] public float EngineForce { get; private set; } = 1500f;

        [Export] public float BrakeForce { get; private set; } = 30f;

        [Export] public float SteeringAngle { get; private set; } = 0.5f;

        [Export] public float MaxSpeed { get; private set; } = 30f;

        [Export] public float SteeringResponsiveness { get; private set; } = 8f;

        [Export] public float AirStabilizationForce { get; private set; } = 15f;

        [Export] public float ReverseMultiplier { get; private set; } = 0.5f;
    }
}