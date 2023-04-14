namespace CollectionsProject.Models
{
    public class Bus : Vehicle
    {
        public int NumOfSeats { get; set; }



        public override string GetInfo()
        {
            return "Bus\n\t"
                + "\n\tId : " + Id + "\n\t"
                + Engine.ToString()
                + "\n\t" + Chassis.ToString()
                + "\n\t" + Transmission.ToString()
                + "\n\t" + "Number of seats: " + NumOfSeats;
        }
    }
}
