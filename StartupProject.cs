using CollectionsProject.Repositories.Interfaces;
using CollectionsProject.Services;
using CollectionsProject.Services.Interfaces;
using CollectionsProject.Validators;
using Common.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsProject;

public class StartupProject
{
    public static ServiceProvider OnStartup(ServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();

        services.AddSingleton<ValidatorFactory>(x => new ValidatorFactory(x));
        services.AddSingleton<CarValidator>();
        services.AddSingleton<BusValidator>();
        services.AddSingleton<TruckValidator>();
        services.AddSingleton<ScooterValidator>();

        services.AddSingleton<IFileManager, FileManager>();

        services.AddSingleton<IVehicleRepository, VehicleRepository>();
        services.AddSingleton<IVehicleService, VehicleService>();
        
        return services.BuildServiceProvider();
    }
}
