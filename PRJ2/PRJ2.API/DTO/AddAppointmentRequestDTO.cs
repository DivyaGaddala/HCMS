using System.ComponentModel.DataAnnotations;

namespace PRJ2.API.DTO
{
    public class AddAppointmentRequestDTO
    {


        [Required]
        [NotEmptyGuid(ErrorMessage ="patientId cannot be null")]
        public Guid PatientId { get; set; }

        [Required]
        [NotEmptyGuid(ErrorMessage ="DoctorId cannot be null")]
        public Guid DoctorId { get; set; }

        [Required]
        [FutureOrTodayDate(ErrorMessage ="Appontment date cant be in the past")]
        public DateTime AppointmentDate { get; set; }

        [Required]
        [StringLength(50)]
        [ValidAppointmentStatus(ErrorMessage ="Status must be Scheduled, Completed or Cancelled" )]
        public string Status { get; set; }
    }
}
