using Godot;
using System.Runtime.CompilerServices;

namespace Game.Gameplay.Vehicle
{
    public partial class VehicleController : Node3D
    {
        [Export] private VehicleDataResource _data;
        private VehicleBody3D _body;

        private float _targetSteering;
        private float _throttle;

        public override void _Ready()
        {
            var vehicleVisual = _data.VehicleVisual.Instantiate();
            if (vehicleVisual is VehicleBody3D vehicleBody)
                _body = vehicleBody;

            AddChild(vehicleVisual);
        }

        public override void _PhysicsProcess(double delta)
        {
            HandleInput();

            float speed = _body.LinearVelocity.Length();

            // Reduz a força do motor próximo da velocidade máxima
            float speedFactor = Mathf.Clamp(
                1f - (speed / _data.MaxSpeed),
                0f,
                1f);

            _body.EngineForce = _throttle * _data.EngineForce * speedFactor;

            // Direção suavizada
            _body.Steering = Mathf.Lerp(
                (float)_body.Steering,
                _targetSteering,
                _data.SteeringResponsiveness * (float)delta);

            // Auto-endireitamento apenas no ar
            if (!HasGroundContact())
            {
                Vector3 correction = Basis.Y.Cross(Vector3.Up);
                _body.ApplyTorque(-correction * _data.AirStabilizationForce);
            }
        }

        private void HandleInput()
        {
            _throttle = Input.GetAxis(
                "move_backward",
                "move_forward");

            float steeringInput = Input.GetAxis(
                "move_right",
                "move_left");

            _targetSteering =
                steeringInput * _data.SteeringAngle;

            _body.Brake = Input.IsActionPressed("brake")
                ? _data.BrakeForce
                : 0f;

            // Ré mais fraca
            if (_throttle < 0f)
                _throttle *= _data.ReverseMultiplier;
        }

        private bool HasGroundContact()
        {
            foreach (Node child in GetChildren())
            {
                if (child is VehicleWheel3D wheel &&
                    wheel.IsInContact())
                {
                    return true;
                }
            }

            return false;
        }
    }
}