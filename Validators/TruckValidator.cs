using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionsProject.Models;

namespace CollectionsProject.Validators;

public class TruckValidator : VehicleValidator
{

    public override bool IsValid(Vehicle vehicle)
    {
        if (vehicle == null || vehicle.GetType() != typeof(Truck))
            return false;
        Truck truck = (Truck)vehicle;
        return truck.WheelSize > 0 && base.IsValid(vehicle);
    }
}
