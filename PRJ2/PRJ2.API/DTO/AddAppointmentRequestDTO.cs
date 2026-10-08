namespace PRJ2.API.DTO
{
    public class AddAppointmentRequestDTO
    {

       

        public Guid PatientId { get; set; }

        public Guid DoctorId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string Status { get; set; }
    }
}
