namespace CollectionsProject.Models;

public class Truck : Vehicle
{
    public int WheelSize { get; set; }

    public override string GetInfo()
    {
        return "Truck\n\t"
            + "\n\tId : " + Id + "\n\t"
            + Engine.ToString()
            + "\n\t" + Chassis.ToString()
            + "\n\t" + Transmission.ToString()
            + "\n\t" + "Wheel size: " + WheelSize;
    }
}
