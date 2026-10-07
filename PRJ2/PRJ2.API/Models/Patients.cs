namespace PRJ2.API.Models
{
    public class Patients
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
    }
}
