using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionsProject.data;

namespace CollectionsProject.Validators;

public class ValidatorFactory
{
    private readonly IServiceProvider _servicesProvider;
    private List<Type> validatorTypes = new List<Type>()
    {
        typeof(CarValidator), typeof(BusValidator), typeof(TruckValidator), typeof(ScooterValidator)
    };
    public ValidatorFactory(IServiceProvider servicesProvider)
    {
        _servicesProvider = servicesProvider;
    }

    public VehicleValidator GetRequiredValidator(Type vehicleType)
    {
        if(!IsValidType(vehicleType)) 
            throw new ArgumentException(nameof(vehicleType));
        return (VehicleValidator) _servicesProvider.GetService(GetValidatorType(vehicleType));
    }

    private Type GetValidatorType(Type vehicleType)
    {
        return validatorTypes.First(x=> x.Name.StartsWith(vehicleType.Name)) ?? throw new InvalidOperationException();
    }
    private bool IsValidType(Type vehicleType)
    {
        return VehicleData.VehicleTypes.Any(x=> x == vehicleType);
    }
}
