namespace CollectionsProject.Models
{
    public class Transmission
    {
        public string Type { get; set; }
        public int NumOfGears { get; set; }
        public string Manufacturer { get; set; }

        public Transmission()
        {
        }

        public Transmission(string type, int gears, string manufacturer)
        {
            Type = type;
            NumOfGears = gears;
            Manufacturer = manufacturer;
        }

        public override string ToString()
        {
            return $"Transmission" +
                $"\n\t\tType: {Type}" +
                $"\n\t\tNumber of gears: {NumOfGears}" +
                $"\n\t\tManufacturer: {Manufacturer}";
        }
    }
}
