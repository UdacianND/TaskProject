using CollectionsProject.Exceptions;
using CollectionsProject.Models;
using CollectionsProject.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsProject.Services.Interfaces;

public interface IVehicleService
{
    /// <summary>
    /// Gets vehicles by parameter 
    /// <para>if parameter type is primitive, write only its name, otherwise write it with semicolon.</para>
    /// <para>Ex: ("Weight", "200")</para>
    /// <para> But:("Engine:power", "200")</para>
    /// </summary>
    /// <param name="name">Parameter name</param>
    /// <param name="value">Parameter value</param>
    /// <returns>Vehicle list</returns>
    Task<IEnumerable<Vehicle>> GetVehiclesByParameterAsync(string name, string value);

    /// <summary>
    /// Gets vehicle by Id
    /// </summary>
    /// <param name="id">Vehicle id</param>
    /// <returns>Vehicle entity</returns>
    Task<Vehicle> GetByIdAsync(long id);

    /// <summary>
    /// Adds vehicle to data
    /// </summary>
    /// <param name="vehicle">Vehicle being added</param>
    /// <returns>Vehicle entity added</returns>
    Task<Vehicle> AddVehicleAsync(Vehicle vehicle);

    /// <summary>
    /// Updates vehicle by id
    /// </summary>
    /// <param name="id">Vehicle id being updated</param>
    /// <param name="vehicle">Vehicle model to update</param>
    /// <returns>Update result</returns>
    Task<bool> UpdateByIdAsync(long id, Vehicle vehicle);

    /// <summary>
    /// Deletes vehicle by id
    /// </summary>
    /// <param name="id">Vehicle id being deleted</param>
    /// <returns>Delete result</returns>
    Task<bool> DeleteByIdAsync(long id);
}
