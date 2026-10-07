namespace PRJ2.API.DTO
{
    public class PatientsDTO
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
    }
}
