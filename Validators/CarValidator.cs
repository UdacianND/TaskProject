using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionsProject.Models;

namespace CollectionsProject.Validators;

public class CarValidator : VehicleValidator
{

    public override bool IsValid(Vehicle vehicle)
    {
        if(vehicle == null || vehicle.GetType() != typeof(Car))
            return false;
        Car car = (Car)vehicle;
        return car.Weight>0 && base.IsValid(vehicle);
    }
}
