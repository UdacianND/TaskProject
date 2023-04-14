using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionsProject.Models;

namespace CollectionsProject.Validators;

public class ScooterValidator : VehicleValidator
{
    public override bool IsValid(Vehicle vehicle)
    {
        if (vehicle == null || vehicle.GetType() != typeof(Scooter))
            return false;
        return base.IsValid(vehicle);
    }
}
