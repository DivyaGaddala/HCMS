using System.ComponentModel.DataAnnotations;

namespace PRJ2.API.DTO
{
    public class FutureOrTodayDateAttribute:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
           if(value is DateTime date)
            {
                return date.Date >= DateTime.Today;
            }
            return false;
        }


    }
}
