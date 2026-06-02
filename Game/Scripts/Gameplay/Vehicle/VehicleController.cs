using Game.Gameplay.Vehicle.Inputs;
using Godot;
using System.Linq;

namespace Game.Gameplay.Vehicle
{
    public partial class VehicleController : VehicleBody3D
    {
        [Export] private VehicleDataResource _data;

        private IVehicleInput _input;
        private VehicleWheel3D[] _wheels;

        private float _targetSteering;
        private float _throttle;

        public void Setup(IVehicleInput input)
        {
            _input = input;
            _wheels = GetChildren()
               .OfType<VehicleWheel3D>()
               .ToArray();
        }

        public override void _PhysicsProcess(double delta)
        {
            if (_input == null)
                return;

            HandleInput();

            float speed = LinearVelocity.Length();

            float speedFactor = Mathf.Clamp(
                1f - (speed / _data.MaxSpeed),
                0f,
                1f);

            EngineForce =
                _throttle *
                _data.EngineForce *
                speedFactor;

            Steering = Mathf.Lerp(
                (float)Steering,
                _targetSteering,
                _data.SteeringResponsiveness * (float)delta);

            if (!HasGroundContact())
            {
                Vector3 correction = Basis.Y.Cross(Vector3.Up);

                ApplyTorque(
                    -correction *
                    _data.AirStabilizationForce);
            }
        }

        private void HandleInput()
        {
            var command = _input.GetCommand();

            _throttle = command.Throttle;

            if (_throttle < 0f)
                _throttle *= _data.ReverseMultiplier;

            _targetSteering =
                command.Steering *
                _data.SteeringAngle;

            Brake = command.Brake
                ? _data.BrakeForce
                : 0f;
        }

        private bool HasGroundContact()
        {
            foreach (var wheel in _wheels)
            {
                if (wheel.IsInContact())
                    return true;
            }

            return false;
        }
    }
}