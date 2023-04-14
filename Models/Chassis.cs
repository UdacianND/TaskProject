namespace CollectionsProject.Models
{
    public class Chassis
    {
        public int NumOfWheels { get; set; }
        public int Number { get; set; }
        public double LoadCapacity { get; set; }

        public Chassis()
        {
        }

        public Chassis(int numOfWheels, int number, double loadCapacity)
        {
            NumOfWheels = numOfWheels;
            Number = number;
            LoadCapacity = loadCapacity;
        }

        public override string ToString()
        {
            return $"Chassis" +
                $"\n\t\tNumber of Wheels: {NumOfWheels}" +
                $"\n\t\tNumber: {Number}" +
                $"\n\t\tLoad capacity: {LoadCapacity}";
        }
    }
}
