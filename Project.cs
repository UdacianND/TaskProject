using CollectionsProject.data;
using CollectionsProject.Models;
using CollectionsProject.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;



namespace CollectionsProject;


public  class Project
{
   public static async Task Main()
   {
        var services = new ServiceCollection();
        var vehicleData = new VehicleData();

        var serviceProvider = StartupProject.OnStartup(services);
        var vehicleService = serviceProvider.GetRequiredService<IVehicleService>();
        var fileManager = serviceProvider.GetRequiredService<IFileManager>();
        await fileManager.WriteAsync(vehicleData.TransportObjects());

        var vehicles = await vehicleService.GetVehiclesByParameterAsync("engine:power", "200");
        vehicles.ToList().ForEach(v=> Console.WriteLine(v.GetInfo()));

        Car car = new()
        {
            Chassis = new Chassis(4, 1, 500),
            Engine = new Engine("200", 3, "ESS", 654127),
            Transmission = new Transmission("Automatic", 6, "Eaton"),
            Weight = 200
        };
        car = (Car)await vehicleService.AddVehicleAsync(car);
        Console.WriteLine(car.GetInfo());
        car.Weight = 300;
        await vehicleService.UpdateByIdAsync(car.Id, car);
        car = (Car) await vehicleService.GetByIdAsync(car.Id);
        Console.WriteLine(car.GetInfo());
        await vehicleService.DeleteByIdAsync(1);

        //(await fileManager.ReadAsync()).ToList().ForEach(x => Console.WriteLine(x.GetInfo()));
    }
}