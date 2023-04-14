using CollectionsProject.Models;

namespace CollectionsProject.data;

public class VehicleData
{
    public static List<Type> VehicleTypes = new List<Type> { typeof(Car), typeof(Bus), typeof(Truck), typeof(Scooter) };
    Car car = new Car
    {
        Id = 1,
        Chassis = new Chassis(4, 1, 500),
        Engine = new Engine("200", 3, "ESS", 654127),
        Transmission = new Transmission("Automatic", 6, "Eaton"),
        Weight = 400
    };

    Bus bus = new Bus
    {
        Id = 2,
        Chassis = new Chassis(4, 1, 700),
        Engine = new Engine("200", 3, "Diesel", 456174),
        NumOfSeats = 30,
        Transmission = new Transmission("Manual", 4, "ISUZU")
    };

    Truck truck = new Truck
    {
        Id = 3,
        Chassis = new Chassis(10, 2, 1500),
        Transmission = new Transmission("RTX", 6, "MAN"),
        Engine = new Engine("500", 10, "Diesel", 5479),
        WheelSize = 60
    };

    Scooter scooter = new Scooter
    {
        Id = 4,
        Chassis = new Chassis(2, 1, 40),
        Engine = new Engine("150", 1.5, "HEV", 4560014),
        Transmission = new Transmission("Manual", 5, "HONDA"),
        ExtraSeat = false
    };

    public List<Vehicle> TransportObjects()
    {
        var transportVehicles = new List<Vehicle> { car, scooter, truck, bus };
        return transportVehicles;
    }
}