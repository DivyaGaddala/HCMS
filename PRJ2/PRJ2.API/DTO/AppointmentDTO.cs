namespace PRJ2.API.DTO
{
    public class AppointmentDTO
    {

        public Guid AppointmentId { get; set; }

        public Guid PatientId { get; set; }

        public Guid DoctorId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string Status { get; set; }
    }
}
