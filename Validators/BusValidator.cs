

using CollectionsProject.Models;

namespace CollectionsProject.Validators;

public class BusValidator : VehicleValidator
{

    public override bool IsValid(Vehicle vehicle)
    {
        if (vehicle == null || vehicle.GetType() != typeof(Bus))
            return false;
        Bus bus = (Bus)vehicle;
        return bus.NumOfSeats > 0 && base.IsValid(vehicle);
    }
}
