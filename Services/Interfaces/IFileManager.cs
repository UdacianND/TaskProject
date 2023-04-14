using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionsProject.Models;

namespace CollectionsProject.Services.Interfaces;

public interface IFileManager
{
    /// <summary>
    /// Writes vehicle list to xml file
    /// </summary>
    /// <param name="vehicles">Vehicle list</param>
    /// <returns>Void</returns>
    Task WriteAsync(IEnumerable<Vehicle> vehicles);

    /// <summary>
    /// Reads vehicle data from xml file
    /// </summary>
    /// <returns>Vehicle list</returns>
    Task<IEnumerable<Vehicle>> ReadAsync();
}
