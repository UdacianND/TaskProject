using CollectionsProject.Exceptions;
using CollectionsProject.Models;
using CollectionsProject.Repositories.Interfaces;
using CollectionsProject.Services.Interfaces;
using CollectionsProject.Validators;
using Common.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsProject.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly ValidatorFactory _validatorFactory;
    public VehicleService(IVehicleRepository vehicleRepository, ValidatorFactory validatorFactory)
    {
        _vehicleRepository = vehicleRepository;
        _validatorFactory = validatorFactory;
    }
    public async Task<IEnumerable<Vehicle>> GetVehiclesByParameterAsync(string name, string value)
    {
        ArgumentNullException.ThrowIfNull(name, nameof(name));
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        return await Task.Run(async () =>
        {
            if (!FilterValidator.IsValidPropertyNameAndValue(name, value))
                throw new GetAutoByParameterException();

            return await _vehicleRepository.Get(vehicle =>
                vehicle.GetType().GetProperties()
                .Any(prop => FilterValidator.IsMatchingVehicle(prop, vehicle, name, value)));
        });
    }

    public async Task<Vehicle> AddVehicleAsync(Vehicle vehicle)
    {
        return await Task.Run(async () =>
        {
            var validator = _validatorFactory.GetRequiredValidator(vehicle.GetType());
            if (validator == null ||!validator.IsValid(vehicle))
                throw new AddException();

            return await _vehicleRepository.CreateAsync(vehicle);
        });
    }

    public async Task<bool> UpdateByIdAsync(long id, Vehicle vehicle)
    {
        return await Task.Run(async () =>
        {
            var entity = await _vehicleRepository.GetByIdAsync(id);
            if (entity == null || entity.GetType() != vehicle.GetType())
                throw new UpdateAutoException();
            var validator = _validatorFactory.GetRequiredValidator(vehicle.GetType());
            if (validator == null || !validator.IsValid(vehicle))
                throw new UpdateAutoException();

            return await _vehicleRepository.UpdateByIdAsync(id, vehicle);
        });
    }

    public async Task<bool> DeleteByIdAsync(long id)
    {
        return await Task.Run(async () =>
        {
            if (!await _vehicleRepository.ExistsByIdAsync(id))
                throw new RemoveAutoException();

            return await _vehicleRepository.DeleteByIdAsync(id);
        });
    }

    public async Task<Vehicle> GetByIdAsync(long id)
    {
        return await _vehicleRepository.GetByIdAsync(id) ?? throw new ObjectNotFoundException();
    }
}
