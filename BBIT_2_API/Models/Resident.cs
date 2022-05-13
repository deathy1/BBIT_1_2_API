namespace BBIT_2_API
{
    public class Resident
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostIndex { get; set; }
        public DateTime DateOfBirth { get; set; }      
        public string Email { get; set; }
        public string PhoneNumber { get; set; }  
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
    }
}
