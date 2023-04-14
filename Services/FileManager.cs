using CollectionsProject.AppConstants;
using CollectionsProject.Models;
using CollectionsProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CollectionsProject.Services;

public class FileManager : IFileManager
{
    public Task<IEnumerable<Vehicle>> ReadAsync()
    {
        return Task.Run(() =>
        {
            XmlSerializer serializer = new(typeof(List<Vehicle>));
            var fs = new FileStream(FilePaths.dataUrl, FileMode.Open);
            var data = (IEnumerable<Vehicle>) (serializer.Deserialize(fs) ?? throw new InvalidOperationException());
            fs.Close();
            return data;
        });   
    }

    public Task WriteAsync(IEnumerable<Vehicle> vehicles)
    {
        ArgumentNullException.ThrowIfNull(vehicles);
        return Task.Run(() =>
        {
            XmlSerializer serializer = new(typeof(List<Vehicle>));
            using TextWriter writer = new StreamWriter(FilePaths.dataUrl);
            serializer.Serialize(writer, vehicles.ToList());
        });
    }
}
