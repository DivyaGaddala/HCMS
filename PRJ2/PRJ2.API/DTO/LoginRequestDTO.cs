using System.ComponentModel.DataAnnotations;

namespace PRJ2.API.DTO
{
    public class LoginRequestDTO
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string password { get; set; }
    }
}
