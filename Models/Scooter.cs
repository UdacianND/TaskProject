namespace CollectionsProject.Models
{
    public class Scooter : Vehicle
    {
        public bool ExtraSeat { get; set; }

        public override string GetInfo()
        {
            return "Scooter\n\t"
                + "\n\tId : " + Id + "\n\t"
                + Engine.ToString()
                + "\n\t" + Chassis.ToString()
                + "\n\t" + Transmission.ToString()
                + "\n\t" + "Is extra seat exist: " + ExtraSeat;
        }
    }
}
