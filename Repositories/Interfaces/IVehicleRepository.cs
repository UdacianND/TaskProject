
using CollectionsProject.Models;

namespace CollectionsProject.Repositories.Interfaces;

public interface IVehicleRepository
{

    /// <summary>
    /// Gets all vehicles
    /// </summary>
    /// <returns>Vehicle list</returns>
    Task<IEnumerable<Vehicle>> GetAllAsync();

    /// <summary>
    /// Gets vehicle list by query
    /// </summary>
    /// <param name="expression">Query expression</param>
    /// <returns>Vehicle list</returns>
    Task<IEnumerable<Vehicle>> Get(Func<Vehicle, bool> expression);

    /// <summary>
    /// Gets vehicle by id
    /// </summary>
    /// <param name="id">Vehicle id</param>
    /// <returns>Vehicle entity</returns>
    Task<Vehicle> GetByIdAsync(long id);

    /// <summary>
    /// Adds new vehicle
    /// </summary>
    /// <param name="model">Vehicle model</param>
    /// <returns>Creation result</returns>
    Task<Vehicle> CreateAsync(Vehicle model);

    /// <summary>
    /// Updates vehicle by id
    /// </summary>
    /// <param name="id">Vehicle id being updated</param>
    /// <param name="model">Vehicle model</param>
    /// <returns>Update result</returns>
    Task<bool> UpdateByIdAsync(long id, Vehicle model);

    /// <summary>
    /// Delete vehicle by id
    /// </summary>
    /// <param name="id">Vehicle id being deleted</param>
    /// <returns>Delete result</returns>
    Task<bool> DeleteByIdAsync(long id);

    /// <summary>
    /// Determines wether vehicle exists by id
    /// </summary>
    /// <param name="id">Vehicle id being queried</param>
    /// <returns>If entity exists</returns>
    Task<bool> ExistsByIdAsync(long id);
}
