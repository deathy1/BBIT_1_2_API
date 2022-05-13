namespace BBIT_2_API
{
    public class Apartment
    {
        public int Id { get; set; }
        public int ApartmentNumber { get; set; }
        public int Floor { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfResidents { get; set; }
        public int Area { get; set; }       //dzivojama kvadratura
        public int LivingSpace { get; set; }    //kopeja kvadratura
        public int HomeId { get; set; }          
        public Home Home { get; set; }
        public List<Resident> Residents { get; set; }
    }
}
