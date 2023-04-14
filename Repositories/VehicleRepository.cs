using System.Linq.Expressions;
using System.Reflection;
using CollectionsProject.Exceptions;
using CollectionsProject.Models;
using CollectionsProject.Repositories.Interfaces;
using CollectionsProject.Services.Interfaces;

namespace Common.DAL.Repositories;

/// <summary>
/// Provides methods for generic entity repository base to manipulate data
/// </summary>

public class VehicleRepository : IVehicleRepository
{ 
    IEnumerable<Vehicle> Vehicles { get; set; }
    private readonly IFileManager _FileManager;

    public VehicleRepository(IFileManager fileManager)
    {
        Vehicles = new List<Vehicle>();
        _FileManager= fileManager;
    }

    /// <summary>
    /// Initializes vehicle data
    /// </summary>
    private async Task InitData()
    {
        try
        {
            Vehicles = await _FileManager.ReadAsync();
        }catch
        {
            throw new InitializationException();
        }
    }

    public Task<IEnumerable<Vehicle>> Get(Func<Vehicle, bool> expression)
    {
        return Task.Run(async () =>
        {
            await InitData();
            return Vehicles.Where(expression);
        });  
    }

    public Task<IEnumerable<Vehicle>> GetAllAsync()
    {
        return Task.Run(async () =>
        {
            await InitData();
            return Vehicles;
        });
    }

    public Task<Vehicle> GetByIdAsync(long id)
    {
        return Task.Run(async () =>
        {
            await InitData();
            return Vehicles.First(v=> v.Id == id) ?? throw new ObjectNotFoundException();
        }); ;
    }

    public async Task<Vehicle> CreateAsync(Vehicle model)
    {
        if(model == null)
            throw new AddException("model");
        return await Task.Run(async () =>
        {
            long id = 1;
            await InitData();
            if (Vehicles.Any())
                id = Vehicles.OrderByDescending(v => v.Id).First().Id+1;
            
            model.Id = id;
            Vehicles = Vehicles.Append(model);
            await SaveAsync();
            Console.WriteLine("Add");
            return model;
        });
    }

    public async Task<bool> UpdateByIdAsync(long id, Vehicle model)
    {
        if (id <= 0)
            return false;
        if(model == null)
            throw new UpdateAutoException();
        return await Task.Run(async () =>
        {
            try
            {
                if (!await ExistsByIdAsync(id))
                    throw new ObjectNotFoundException();
                model.Id = id;
                Vehicles = Vehicles.Select(v => v.Id == id ? model : v);
                await SaveAsync();
                Console.WriteLine("Edit");
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        });
    }

    public async Task<bool> DeleteByIdAsync(long id)
    {
        if(id<=0)
            return false;
        return await Task.Run(async () =>
        {
            try
            {
                if (!await ExistsByIdAsync(id))
                    throw new ObjectNotFoundException();
                Vehicles = Vehicles.Where(v => v.Id != id);
                await SaveAsync();
                Console.WriteLine("Delete");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        });
    }

    /// <summary>
    /// Saves changes
    /// </summary>
    private async Task<bool> SaveAsync()
    {
        return await Task.Run(async() =>
        {
            try
            {
                await _FileManager.WriteAsync(Vehicles);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        });
    }

    public async Task<bool> ExistsByIdAsync(long id)
    {
        return await Task.Run(async () =>
        {
            await InitData();
            return Vehicles.Any(vehicle => vehicle.Id == id);
        });
    }
}
