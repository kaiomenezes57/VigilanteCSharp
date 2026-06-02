using Godot;

namespace Game.Gameplay.Vehicle.Inputs
{
    public sealed class PlayerVehicleInput : IVehicleInput
    {
        public VehicleCommand GetCommand()
        {
            var throttle = Input.GetAxis(
                "move_backward",
                "move_forward");

            var steering = Input.GetAxis(
                "move_right",
                "move_left");

            var brake = 
                Input.IsActionPressed("brake");

            return new VehicleCommand(
                throttle, 
                steering, 
                brake);
        }
    }
}
