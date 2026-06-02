namespace Game.Gameplay.Vehicle.Inputs
{
    public sealed class TestVehicleInput : IVehicleInput
    {
        public VehicleCommand GetCommand()
        {
            return new VehicleCommand(1f, 0, false);
        }
    }
}
