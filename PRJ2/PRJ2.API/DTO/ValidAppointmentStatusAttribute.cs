using System.ComponentModel.DataAnnotations;

namespace PRJ2.API.DTO
{
    public class ValidAppointmentStatusAttribute:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if(value is string Status)
            {
                return Status == "Scheduled" || Status == "Completed" || Status == "Cancelled";
            }
            return false;
        }
    }
} 
