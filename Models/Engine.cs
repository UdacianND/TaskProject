namespace CollectionsProject.Models
{
    public class Engine
    {
        public string Power { get; set; }
        public double Capacity { get; set; }
        public string Type { get; set; }
        public int SerialNumber { get; set; }

        public Engine(string power, double capacity, string type, int serialNumber)
        {
            Power = power;
            Capacity = capacity;
            Type = type;
            SerialNumber = serialNumber;
        }

        public Engine() { }

        public override string ToString()
        {
            return $"Engine" +
                $"\n\t\tPower: {Power}" +
                $"\n\t\tCapacity: {Capacity}" +
                $"\n\t\tType: {Type}" +
                $"\n\t\tSerial Number: {SerialNumber}";
        }
    }
}
