using System.ComponentModel.DataAnnotations;

namespace PRJ2.API.DTO
{
    public class PatientsDTO
    {
        [Required]   
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string Phonenumber { get; set; }
        public string Address { get; set; }
    }
}
