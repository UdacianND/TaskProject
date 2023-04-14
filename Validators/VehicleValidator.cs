using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionsProject.Models;

namespace CollectionsProject.Validators;

public class VehicleValidator
{

    public virtual bool IsValid(Vehicle vehicle)
    {
        ArgumentNullException.ThrowIfNull(vehicle, nameof(vehicle));
        return IsValidTransMission(vehicle.Transmission) &&
            IsValidChassic(vehicle.Chassis) && IsValidEngine(vehicle.Engine);
    }

    private bool IsValidTransMission(Transmission transmission)
    {
        return transmission != null &&  transmission.NumOfGears > 0 
            && !string.IsNullOrWhiteSpace(transmission.Manufacturer)
            && !string.IsNullOrWhiteSpace(transmission.Type);
    }

    private bool IsValidEngine(Engine engine)
    {
        return engine != null && !string.IsNullOrWhiteSpace(engine.Power) 
            && engine.Capacity>0
            && engine.SerialNumber>0;
    }

    private bool IsValidChassic(Chassis chassis)
    {
        return chassis != null &&  chassis.NumOfWheels > 0
            && chassis.LoadCapacity > 0
            && chassis.Number > 0;
    }
}
