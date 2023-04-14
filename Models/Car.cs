namespace CollectionsProject.Models
{
    public class Car : Vehicle
    {
        public double Weight { get; set; }

        public override string GetInfo()
        {
            return "Car\n\t"
                + "\n\tId : " + Id + "\n\t"
                + Engine.ToString()
                + "\n\t" + Chassis.ToString()
                + "\n\t" + Transmission.ToString()
                + "\n\t" + "Weight: " + Weight;
        }
    }
}
